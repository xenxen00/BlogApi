using Application.Exeptions;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Commands.SavedPosts;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Application.UseCases.Queries.Categories;
using Application.UseCases.Queries.SavedPosts;
using FluentValidation;
using Implementation;
using Implementation.UseCases.Commands.EF.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingListController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IRemovePostFromSavedCommand _deleteFromSavedList;
        private readonly IGetSavedPostsQuery _getSavedPostsQuery;
        private readonly ISavePostCommand _savePostCommand;

        public ReadingListController(UseCaseHandler handler, IRemovePostFromSavedCommand deleteFromSavedList, IGetSavedPostsQuery getSavedPostsQuery, ISavePostCommand savePostCommand)
        {
            _handler = handler;
            _deleteFromSavedList = deleteFromSavedList;
            _getSavedPostsQuery = getSavedPostsQuery;
            _savePostCommand = savePostCommand;
        }

        // GET: api/<ReadingListController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var res = _handler.HandleQuery(_getSavedPostsQuery, dto);
                return Ok(res);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ReadingListController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] SavedPostDto dto)
        {
            try
            {
                _handler.HandleCommand(_savePostCommand, dto);
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


        // DELETE api/<ReadingListController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete([FromBody] SavedPostDto dto)
        {
            try
            {
                _handler.HandleCommand(_deleteFromSavedList, dto);
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
