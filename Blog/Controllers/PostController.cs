using Application.Exeptions;
using Application.UseCases.Commands;
using Application.UseCases.Commands.Posts;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries;
using Domain.Entities;
using FluentValidation;
using Implementation;
using Implementation.UseCases.Commands.EF.Posts;
using Implementation.UseCases.Queries.EF.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IDeletePostCommand _deletePostCommand;
        private readonly ISearchPostsQuery _searchPostsQuery;
        private readonly ICreatePostCommand _createPostCommand;
        private readonly IUpdatePostCommand _updatePostCommand;
        private readonly IGetPostDetailsQuery _getPostDetailsQuery;

        public PostController(UseCaseHandler handler,
            IDeletePostCommand deletePostCommand,
            ISearchPostsQuery searchPostsQuery,
            ICreatePostCommand createUpdatePostCommand,
            IGetPostDetailsQuery getPostDetailsQuery,
            IUpdatePostCommand updatePostCommand)
        {
            _handler = handler;
            _deletePostCommand = deletePostCommand;
            _searchPostsQuery = searchPostsQuery;
            _createPostCommand = createUpdatePostCommand;
            _getPostDetailsQuery = getPostDetailsQuery;
            _updatePostCommand = updatePostCommand;
        }

        // GET: api/<PostController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var res = _handler.HandleQuery(_searchPostsQuery, dto);
                return Ok(res);
            }
            catch(System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _handler.HandleQuery(_getPostDetailsQuery, id);
                return Ok(res);
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

        // POST api/<PostController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePostDto dto)
        {
            try
            {
                _handler.HandleCommand(_createPostCommand, dto);
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

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdatePostDto dto)
        {
            try
            {
                _handler.HandleCommand(_updatePostCommand, dto);
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

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deletePostCommand, id);
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
