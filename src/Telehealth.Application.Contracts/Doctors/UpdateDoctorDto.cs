using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Telehealth.Doctors
{
    public class UpdateDoctorDto:EntityDto<Guid>
    {
        [Required]
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}