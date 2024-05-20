$(function () {
    var editModal = new abp.ModalManager(abp.appPath + 'Doctors/EditModal');
    var modal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Doctors/Skills/SkillModal',
        scriptUrl: '/Pages/Doctors/Skills/skill.js'
    });
    $('#sublvl').click(function () {
        modal.open();
    });
    var l = abp.localization.getResource('Telehealth');
    var dataTable = $('#DoctorTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            ajax: abp.libs.datatables.createAjax(telehealth.doctors.doctor.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: 'Doctor dashboard',
                                    action: function (data) {
                                        console.log(data)
                                        var route = abp.appPath + `LiveCoaching?Id=${data.record.id}&Name=${data.record.name + ' ' + data.record.surname}`;
                                        window.location.href = route;
                                    }
                                },
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted("Doctor.Doctors.Edit"),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'DoctorDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    visible: abp.auth.isGranted('Doctor.Doctors.Delete'),
                                    action: function (data) {
                                        telehealth.doctors.doctor
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Surname'),
                    data: "surname"
                },
                {
                    title: l('PhoneNumber'),
                    data: "phoneNumber"
                },
                {
                    title: l('Email'),
                    data: "email"
                }
            ]
        })
    );
    var createModal = new abp.ModalManager(abp.appPath + 'Doctors/CreateModal')
    $("#NewDoctorButton").on("click", function (e) {
        e.preventDefault();
        createModal.open();
    })
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
})