using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeekBox.DTOs;
using SeekBox.Services;
using System;
using System.Security.Claims;

namespace SeekBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<ClientDto> _validator;

        public ClientController(IUserService userService, IValidator<ClientDto> validator)
        {
            _userService = userService;
            _validator = validator;
        }
        [HttpPost("AddNewUser")]
        public async Task<ActionResult<bool>> AddUser(ClientDto clientDto)
        {
            ValidationResult result = await _validator.ValidateAsync(clientDto);
            if (!result.IsValid) 
            {
                return StatusCode(300, "Wrong Data");
            }
           await  _userService.AddUser(clientDto);
            return Ok(true);
        }
    }
}
