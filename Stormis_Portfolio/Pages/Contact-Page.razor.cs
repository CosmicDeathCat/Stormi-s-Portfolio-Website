using Microsoft.AspNetCore.Components;

namespace Stormis_Portfolio.Pages;

public partial class Contact_Page : ComponentBase
{
    ContactForm contactForm = new();
}
public class ContactForm
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}