using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.Models
{
    public class ResponseModel
    {
        public bool isSucceded { get; set; }
        public List<string> errors { get; set; }
    }
}
