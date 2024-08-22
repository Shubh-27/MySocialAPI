using MySocialAppAPI.BAL.Interface;
using MySocialAppAPI.RequestModel;
using MySocialAppAPI.ResponnceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySocialAppAPI.Controllers
{
    [Route("v1/MySocial/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginRegister loginRegister;
        public AuthController(ILoginRegister _loginRegister)
        {
            this.loginRegister = _loginRegister;
        }

        [HttpPost("Login")]
        public string Login(ResLogin login)
        {
            return loginRegister.Login(login);
        }

        [HttpPost("Register")]
        public bool Register(ReqRegister register)
        {  
            return loginRegister.Register(register);
        }

    }
}
