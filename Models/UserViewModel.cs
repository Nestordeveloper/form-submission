#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace form_submission;

public class User
{
    [Required(ErrorMessage = "First Name is required")]
    [MinLength(0, ErrorMessage = "First Name must be at least 4 characters")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(0, ErrorMessage = "Last Name must be at least 4 characters")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Age is required")]
    [PositiveAge]
    public int Age { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }
}

public class PositiveAgeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int age)
        {
            if (age >= 1)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("Age must be a positive number");
    }
}