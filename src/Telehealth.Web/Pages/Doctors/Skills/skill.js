$(function () {

    const service = telehealth.skills.skill;
    // Function to render subjects and levels
    async function render() {
        // Retrieve SubjectsInJson and LevelsInJson values
        var data = {
            mains: await service.getMains(),
            subs: await service.getSubs()
        };
        data.mains.sort((a, b) => a.order - b.order);
        data.subs.sort((a, b) => a.order - b.order);
        // Render subjects
        var subjectsContainer = $('#sortable-subjects');
        subjectsContainer.empty();
        data.mains.forEach(function (subject) {
            subjectsContainer.append('<li id="' + subject.id + '" class="subject-item sortable-item" data-order="' + subject.order + '">' + subject.title + '<div style="cursor:pointer" data-value="' + subject.title + '" class="delete-subject float-end badge bg-danger"><i class="fa fa-close"></i></div>' + '</li>');
        });

        // Render levels
        var levelsContainer = $('#sortable-levels');
        levelsContainer.empty();
        data.subs.forEach(function (level) {
            levelsContainer.append('<li id="' + level.id + '" class="level-item sortable-item" data-order="' + level.order + '">' + level.title + '<div style="cursor:pointer" data-value="' + level.title + '" class="delete-level float-end badge bg-danger"><i class="fa fa-close"></i></div>' + '</li>');
        });

        var subjects = document.getElementById('sortable-subjects');
        new Sortable(subjects, {
            animation: 200,
            ghostClass: 'drag',
            onUpdate: function (evt) {
                $(subjects).find('li').each(function (index) {
                    $(this).attr('data-order', index);
                });
                service.changeSubjectsOrder(getOrderArray('#sortable-subjects .subject-item'))
                    .then(function () {
                        abp.notify.warn('Subjects re-sorted');
                    });
            }
        });
        var levels = document.getElementById('sortable-levels');
        new Sortable(levels, {
            animation: 200,
            ghostClass: 'drag',
            onUpdate: function (evt) {
                $(levels).find('li').each(function (index) {
                    $(this).attr('data-order', index);
                });
                service.changeLevelsOrder(getOrderArray('#sortable-levels .level-item'))
                    .then(function () {
                        abp.notify.warn('Levels re-sorted');
                    });
            }
        });
    }

    // Initial rendering
    render();

    function getOrderArray(selector) {
        var orderArray = [];
        $(selector).each(function () {
            orderArray.push(
                {
                    id: $(this).attr('id'),
                    title: $(this).text(),
                    order: $(this).attr('data-order')
                }
            );
        });
        return orderArray;
    }

    // Add subject event
    $('#add-subject').click(function (e) {
        e.preventDefault();
        var newSubject = $('#subject').val();
        if (newSubject === '') {
            abp.notify.warn('Add value!');
            return;
        }
        if (newSubject) {

            service.createMain(newSubject).then(function (result) {
                if (result) {
                    $('#subject').val('')
                    abp.notify.warn('Main added');
                    render();
                }
            });
        }
    });

    // Add level event
    $('#add-level').click(function (e) {
        e.preventDefault();

        var newLevel = $('#level').val();
        if (newLevel === '') {
            abp.notify.warn('Add value!');
            return;
        }
        if (newLevel) {
            service.createSub(newLevel).then(function (result) {
                if (result) {
                    $('#level').val('')
                    abp.notify.warn('Sub added');
                    render();
                }
            });
        }
    });

    // Delete item event
    $(document).on('click', '.delete-subject', async function () {
        var value = $(this).data('value');
        abp.message.confirm(
            `${value} will be deleted`,
            'are you sure?',
            function (isConfirmed) {
                if (isConfirmed) {
                    service.deleteMain(value).then(function (result) {
                        if (result) {
                            render();
                        }
                    });
                }
            }
        );
    });

    $(document).on('click', '.delete-level', async function () {
        var value = $(this).data('value');
        abp.message.confirm(
            `${value} will be deleted`,
            'are you sure?',
            function (isConfirmed) {
                if (isConfirmed) {
                    service.deleteSub(value).then(function (result) {
                        if (result) {
                            render();
                        }
                    });
                }
            }
        );
    });

});
