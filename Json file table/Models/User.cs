using System.ComponentModel.DataAnnotations;

namespace Systems.Internship_.Net_task_2.WEB.MVC.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[^a-zA-Z]+$", ErrorMessage = "Invalid phone number format.")]
        public required string Phone { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }


        public string Image { get; set; }
        public string Role { get; set; }
    }
}
