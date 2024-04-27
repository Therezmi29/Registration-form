namespace RegistrationForm.Models
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
