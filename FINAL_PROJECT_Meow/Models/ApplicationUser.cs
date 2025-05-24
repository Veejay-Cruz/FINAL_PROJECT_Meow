using Microsoft.AspNetCore.Identity;

namespace FINAL_PROJECT_Meow.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        // for displaying the full name in the view by combining the first name, last name and middle name
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        

    }
}
