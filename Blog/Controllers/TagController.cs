using Application.Exeptions;
using Application.UseCases.Commands.Tag;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Tags;
using FluentValidation;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly ICreateTagCommand _createTagCommand;
        private readonly IUpdateTagCommand _updateTagCommand;
        private readonly IDeleteTagCommand _deleteTagCommand;
        private readonly IGetTagsQuery _getTagsQuery;

        public TagController(UseCaseHandler handler, ICreateTagCommand createTagCommand, IUpdateTagCommand updateTagCommand, IDeleteTagCommand deleteTagCommand, IGetTagsQuery getTagsQuery)
        {
            _handler = handler;
            _createTagCommand = createTagCommand;
            _updateTagCommand = updateTagCommand;
            _deleteTagCommand = deleteTagCommand;
            _getTagsQuery = getTagsQuery;
        }

        // GET: api/<TagController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var data = _handler.HandleQuery(_getTagsQuery, dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<TagController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateEntityDto dto)
        {
            try
            {
                _handler.HandleCommand(_createTagCommand, dto);
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

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateEntityDto dto)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(_updateTagCommand, dto);
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

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deleteTagCommand, id);
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
