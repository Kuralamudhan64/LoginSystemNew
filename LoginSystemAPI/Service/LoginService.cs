using LoginSystemAPI.Repository;
using Microsoft.AspNetCore.Identity;

namespace LoginSystemAPI.Service
{
    public class LoginService
    {
        private readonly LoginRepository loginRepository;
        private readonly PasswordHasher<string> passwordHasher;
        public LoginService(LoginRepository _loginRepository) 
        {
            loginRepository = _loginRepository;   
            passwordHasher = new PasswordHasher<string>();
        }

        public async Task<(bool,string)> Signup(string username, string password)
        { 
            string hashedPassword = passwordHasher.HashPassword("UserType",password);
            int status=await loginRepository.SignUp(username, hashedPassword);
            if (status == -1)
            {
                return (false,"Username already exists");
            }
            else if (status == 1)
            {
                return (true,"User created Successfully");
            }
            else
            {
                return (false,"Unknown error try again later");
            }
        }








    }
}
