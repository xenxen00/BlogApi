using Application.Exeptions;
using Application.UseCases.Commands.Reaction;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries;
using FluentValidation;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IDeleteReactionCommand _deleteReactionCommand;
        private readonly IGetReactionsQuery _getReactionsQuery;
        private readonly ICreateReactionCommand _createReactionCommand;
        private readonly IUpdateReactionCommand _updateReactionCommand;

        public ReactionController(UseCaseHandler handler, IDeleteReactionCommand deleteReactionCommand, IGetReactionsQuery getCategoriesQuery, ICreateReactionCommand createReactionCommand, IUpdateReactionCommand updateReactionCommand)
        {
            _handler = handler;
            _deleteReactionCommand = deleteReactionCommand;
            _getReactionsQuery = getCategoriesQuery;
            _createReactionCommand = createReactionCommand;
            _updateReactionCommand = updateReactionCommand;
        }

        // GET: api/<ReactionController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var data = _handler.HandleQuery(_getReactionsQuery, dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ReactionController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateEntityDto dto)
        {
            try
            {
                _handler.HandleCommand(_createReactionCommand, dto);
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

        // PUT api/<ReactionController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateEntityDto dto)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(_updateReactionCommand, dto);
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

        // DELETE api/<ReactionController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deleteReactionCommand, id);
                return StatusCode(StatusCodes.Status201Created);
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
