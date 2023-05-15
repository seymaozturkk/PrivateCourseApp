namespace PrivateClassApp.MVC.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
