using Application.UseCases.Commands;
using Application.UseCases.DTO;
using FluentValidation;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    { 
        private IRegisterUserCommand _command;
        private UseCaseHandler _handler;

        public RegisterController(UseCaseHandler handler,
            IRegisterUserCommand command)
        {
            _handler = handler;
            _command = command;
        }

        // POST api/<RegisterController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateUserDto dto)
        {
            try
            {
            _handler.HandleCommand(_command, dto);
            return StatusCode(StatusCodes.Status201Created);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Errors);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
