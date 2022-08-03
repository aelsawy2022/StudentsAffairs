using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.Models
{
    public class Enums
    {
        public enum SystemRoles
        {
            SuperAdmin,
            Admin
        }
    }

    public class Roles
    {
        public const string SUPER_ADMIN = "SuperAdmin";
        public const string ADMIN = "Admin";
    }
}
