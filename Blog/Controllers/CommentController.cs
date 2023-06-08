using Application.Exeptions;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Commands.Comments;
using Application.UseCases.DTO;
using FluentValidation;
using Implementation;
using Implementation.UseCases.Commands.EF.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly ICreateCommentCommand _createCommentCommand;
        private readonly IUpdateCommentCommand _updateCommentCommand;
        private readonly IDeleteCommentCommand _deleteCommentCommand;

        public CommentController(UseCaseHandler handler, ICreateCommentCommand createCommentCommand, IUpdateCommentCommand updateCommentCommand, IDeleteCommentCommand deleteCommentCommand)
        {
            _handler = handler;
            _createCommentCommand = createCommentCommand;
            _updateCommentCommand = updateCommentCommand;
            _deleteCommentCommand = deleteCommentCommand;
        }

        // POST api/<CommentController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateCommentDto dto)
        {
            try
            {
                _handler.HandleCommand(_createCommentCommand, dto);
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

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(_updateCommentCommand, dto);
                return StatusCode(StatusCodes.Status200OK);
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

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deleteCommentCommand, id);
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
