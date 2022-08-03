using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentsAffairs.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public Guid StudentGuid { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter date of birth")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Photo { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please choose class")]
        public int ClassId { get; set; }
        public ClassModel Class { get; set; }
    }

    public class StudentFilter : PagingModel
    {
        public string ClassName { get; set; }
    }
}
