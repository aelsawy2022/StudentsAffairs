using StudentsAffairs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.ViewModels
{
    public class StudentViewModel
    {
        public StudentFilter StudentFilter { get; set; }
        public List<StudentModel> Students { get; set; }
        public StudentModel Student { get; set; }
        public List<ClassModel> Classes { get; set; }
    }
}
