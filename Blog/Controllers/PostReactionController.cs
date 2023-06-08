using Application.Exeptions;
using Application.UseCases.Commands.PostReactions;
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
    public class PostReactionController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly ICreatePostReaction _createPostReaction;
        private readonly IDeletePostReactionCommand _deletePostReaction;

        // POST api/<PostReactionController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] PostReactionDto dto)
        {
            try
            {
                _handler.HandleCommand(_createPostReaction, dto);
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

        // DELETE api/<PostReactionController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deletePostReaction, id);
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
