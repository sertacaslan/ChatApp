using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        [HttpGet("Register")]
        public bool Register()
        {
            return false;
        }   
        

        [HttpGet("Login")]
        public bool Login()
        {
            return true;
        }

    }
}
