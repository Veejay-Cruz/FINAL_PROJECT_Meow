using System;
namespace FINAL_PROJECT_Meow.Models
{
    public static class SystemRoles
    {
        public const string Admin = "Admin";
        public const string Supervisor = "Supervisor";
        public const string Officer = "Officer";
        public const string JuniorOfficer = "Junior Officer";
        public const string NormalUser = "Normal User";

        public static readonly string[] AllRoles = new[]
        {
            Admin,
            Supervisor,
            Officer,
            JuniorOfficer,
            NormalUser
        };
    }
}
