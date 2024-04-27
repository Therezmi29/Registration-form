using RegistrationForm.Models;

namespace RegistrationForm.IoC.Repository
{
    public interface ISignUpRepository
    {
        bool IsExistUserByEmail(string email);
        bool IsExistUserByUsername(string username);
        void AddUser(User user);
    }
}
