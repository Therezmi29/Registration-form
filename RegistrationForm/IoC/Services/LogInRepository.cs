using RegistrationForm.Data;
using RegistrationForm.IoC.Repository;
using RegistrationForm.Models;

namespace RegistrationForm.IoC.Services
{
    public class LogInRepository : ILogInRepository
    {
        private readonly AccountContext _context;
        public LogInRepository(AccountContext context)
        {
            _context = context;
        }
        public User GetUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
