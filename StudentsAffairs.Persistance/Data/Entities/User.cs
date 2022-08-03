using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.Persistance.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public Guid UserGuid { get; set; }
    }
}
