using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeekBox.Services;

namespace SeekBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IBoxService _boxService;

        public PackageController(IBoxService boxService)
        {
            _boxService = boxService;
        }
    }
}
