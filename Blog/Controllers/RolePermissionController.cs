using Application.Exeptions;
using Application.UseCases.Commands.Roles;
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
    public class RolePermissionController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IAddPermissionToRole _addPermissionToRole;
        private readonly IDeleteRolePermission _deleteRolePermission;

        public RolePermissionController(UseCaseHandler handler, IAddPermissionToRole addPermissionToRole, IDeleteRolePermission deleteRolePermission)
        {
            _handler = handler;
            _addPermissionToRole = addPermissionToRole;
            _deleteRolePermission = deleteRolePermission;
        }

        // POST api/<RolePermissionController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] RolePermissionDto dto)
        {
            try
            {
                _handler.HandleCommand(_addPermissionToRole, dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<RolePermissionController>/5
        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromBody] RolePermissionDto dto)
        {
            try
            {
                _handler.HandleCommand(_deleteRolePermission, dto);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
