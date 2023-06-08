using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Permissions;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Permissions;
using FluentValidation;
using Implementation;
using Implementation.UseCases.Commands.EF.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly ICreatePermissionCommand _createPermissionCommand;
        private readonly IDeletePermissionCommand _deletePermissionCommand;
        private readonly IGetPermissionsQuery _getQuery;
        private readonly IUpdatePermissionCommand _updatePermissionCommand;

        public PermissionController(UseCaseHandler handler, ICreatePermissionCommand createPermissionCommand, IDeletePermissionCommand deletePermissionCommand, IUpdatePermissionCommand updatePermissionCommand, IGetPermissionsQuery getQuery)
        {
            _handler = handler;
            _createPermissionCommand = createPermissionCommand;
            _deletePermissionCommand = deletePermissionCommand;
            _updatePermissionCommand = updatePermissionCommand;
            _getQuery = getQuery;
        }

        //private readonly ICre
        // GET: api/<PermissionController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var response = _handler.HandleQuery(_getQuery, dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<PermissionController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePermissionDto dto)
        {
            try
            {
                _handler.HandleCommand(_createPermissionCommand, dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<PermissionController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdatePermissionDto dto)
        {
            try
            {
                _handler.HandleCommand(_updatePermissionCommand, dto);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deletePermissionCommand, id);
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
