using System.ComponentModel.DataAnnotations;
using Stormis_Portfolio.Enums;

namespace Stormis_Portfolio.Models;

public class ContactForm
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter a message.")]
    public string Message { get; set; }
    [Required(ErrorMessage = "Please enter a subject that is not empty.")]
    public string Subject { get; set; }
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Please select a contact reason.")]
    public ContactReasons ContactReason { get; set; }
}