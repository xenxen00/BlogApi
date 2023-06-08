using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Roles;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Roles;
using FluentValidation;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly ICreateRoleCommand _createRoleCommand;
        private readonly IGetRolesQuery _getRolesQuery;
        private readonly IDeleteRoleCommand _deleteRoleCommand;
        private readonly IUpdateRoleCommand _updateCommand;

        public RoleController(UseCaseHandler handler, ICreateRoleCommand createRoleCommand, IGetRolesQuery getRolesQuery, IDeleteRoleCommand deleteRoleCommand, IUpdateRoleCommand updateCommand)
        {
            _handler = handler;
            _createRoleCommand = createRoleCommand;
            _getRolesQuery = getRolesQuery;
            _deleteRoleCommand = deleteRoleCommand;
            _updateCommand = updateCommand;
        }

        // GET: api/<RoleController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var data = _handler.HandleQuery(_getRolesQuery, dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateEntityDto dto)
        {
            try
            {
                _handler.HandleCommand(_createRoleCommand, dto);
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

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateEntityDto dto)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(_updateCommand, dto);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
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

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deleteRoleCommand, id);
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
