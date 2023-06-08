using Application.UseCases.Commands.Posts;
using Application.UseCases.Commands;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Queries.Categories;
using Implementation.UseCases.Queries.EF.Posts;
using Application.UseCases.DTO;
using FluentValidation;
using Application.Exeptions;
using Application.UseCases.DTO.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IDeleteCategoryCommand _deleteCategoryCommand;
        private readonly IGetCategoriesQuery _getCategoriesQuery;
        private readonly ICreateCategoryCommand _createCategoryCommand;
        private readonly IUpdateCategoryCommand _updateCategoryCommand;

        public CategoryController(UseCaseHandler handler, IDeleteCategoryCommand deleteCategoryCommand, IGetCategoriesQuery getCategoriesQuery, ICreateCategoryCommand createCategoryCommand, IUpdateCategoryCommand updateCategoryCommand)
        {
            _handler = handler;
            _deleteCategoryCommand = deleteCategoryCommand;
            _getCategoriesQuery = getCategoriesQuery;
            _createCategoryCommand = createCategoryCommand;
            _updateCategoryCommand = updateCategoryCommand;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchDto dto)
        {
            try
            {
                var res = _handler.HandleQuery(_getCategoriesQuery, dto);
                return Ok(res);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateEntityDto dto)
        {
            try
            {
                _handler.HandleCommand(_createCategoryCommand, dto);
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

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateEntityDto dto)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(_updateCategoryCommand, dto);
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

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _handler.HandleCommand(_deleteCategoryCommand, id);
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
