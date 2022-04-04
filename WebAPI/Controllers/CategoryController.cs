using AutoMapper;
using Business.Abstract;
using Entity.Entities;
using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] CategoryDto category)
        {
            var result = _categoryService.AddCategory(_mapper.Map<Category>(category));
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            _categoryService.UpdateCategory(_mapper.Map<Category>(categoryUpdateDto));
            return Ok();
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] CategoryDeleteDto categoryDeleteDto)
        {
            _categoryService.DeleteCategory(_mapper.Map<Category>(categoryDeleteDto));
            return Ok();
        }
        [HttpGet("geybyid")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _categoryService.GetCategoryByCategoryId(id);
            return Ok(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }
    }
}
