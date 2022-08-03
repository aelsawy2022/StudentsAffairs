using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentsAffairs.Persistance.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Student Student { get; set; }
    }
}
