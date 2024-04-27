using RegistrationForm.Models;

namespace RegistrationForm.IoC.Repository
{
    public interface ILogInRepository
    {
        User GetUser(string email, string password);
    }
}
