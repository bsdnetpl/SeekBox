using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeekBox.Services;
using System.Security.Claims;

namespace SeekBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUserService _userService;

        public ClientController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
