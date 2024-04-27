using RegistrationForm.Data;
using RegistrationForm.IoC.Repository;
using RegistrationForm.Models;

namespace RegistrationForm.IoC.Services
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly AccountContext _context;
        public SignUpRepository(AccountContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(c => c.Email == email);
        }

        public bool IsExistUserByUsername(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
    }
}
