using Stormis_Portfolio.Models;

namespace Stormis_Portfolio.Templates.Email;

public static class ContactFormEmailTemplate
{
    public static string ContactFormEmail(ContactForm form)
    {
        return $@"
            <html>
                <head>
                    <style>
                        body {{
                            font-family: Quicksand, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f4f4f4;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background-color: #ffffff;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            border-radius: 8px;
                        }}
                        .header {{
                            background-color: #62A4EC;
                            color: white;
                            padding: 10px 0;
                            text-align: center;
                            border-top-left-radius: 8px;
                            border-top-right-radius: 8px;
                        }}
                        .content {{
                            padding: 20px;
                        }}
                        .content p {{
                            margin: 10px 0;
                        }}
                        .content strong {{
                            color: #333;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Contact Form Submission</h1>
                        </div>
                        <div class='content'>
                            <p><strong>Contact Reason:</strong> {form.ContactReason}</p>
                            <p><strong>Name:</strong> {form.Name}</p>
                            <p><strong>Email:</strong> {form.Email}</p>
                            <p><strong>Phone Number:</strong> {form.PhoneNumber}</p>
                            <p><strong>Message:</strong> {form.Message}</p>
                        </div>
                    </div>
                </body>
            </html>
        ";
    }
}