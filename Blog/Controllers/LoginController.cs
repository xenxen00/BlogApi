using Api.Core;
using Application.UseCases.DTO;
using FluentValidation;
using Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtManager _jwtManager;
        private readonly LoginValidator _validator;

        public LoginController(JwtManager jwtManager, LoginValidator validator)
        {
            _jwtManager = jwtManager;
            _validator = validator;
        }

        // POST api/<LoginController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] LoginCredentialsDto dto)
        {
            try
            {
                _validator.ValidateAndThrow(dto);
                var token = this._jwtManager.MakeToken(dto.Email, dto.Password);
                return Ok(new { token });
             }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Errors);
            }
            catch (SystemException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
