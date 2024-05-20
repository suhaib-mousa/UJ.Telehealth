using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Application.Dtos;

namespace Telehealth.Doctors
{
    public class CreateDoctorDto 
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}