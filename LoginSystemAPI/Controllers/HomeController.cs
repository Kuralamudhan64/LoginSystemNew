using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System;
using System.Threading.Tasks;
using LoginSystemAPI.Service;
using LoginSystemAPI.Models;

namespace LoginSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly LoginService loginService;
        public HomeController(LoginService _loginService) 
        {
            loginService = _loginService;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest model)
        {
           var status =await loginService.Signup(model.username,model.password);
           return Ok(new {isSuccessfull=status.Item1, message=status.Item2 });
        }
    }
}