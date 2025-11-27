namespace TasksProject._03_Services.Interfaces
{
    public interface IEmailServices
    {

        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
