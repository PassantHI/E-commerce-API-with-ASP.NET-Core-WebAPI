using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            if (categories.Any())
            {
                List<CategoryDTO> list = new List<CategoryDTO>();
                foreach (var category in categories)
                {
                    CategoryDTO categoryDTO = new CategoryDTO()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryDescription = category.CategoryDescription
                    };
                    list.Add(categoryDTO);

                }
                return Ok(list);


            }
            return NoContent();

        }
        [AllowAnonymous]

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var category=_unitOfWork.Category.GetById(id);
            if(category != null) 
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.CategoryId = category.CategoryId;
                categoryDTO.CategoryName = category.CategoryName;
                categoryDTO.CategoryDescription = category.CategoryDescription;

                return Ok(categoryDTO);

            }

            return BadRequest();
        
        }

        [AllowAnonymous]

        [HttpGet("{name:alpha}")] 
        public IActionResult GetByName(string name)
        { 
            var category=_unitOfWork.Category.GetBy(a=>a.CategoryName==name);
            if (category != null) 
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.CategoryId = category.CategoryId;
                categoryDTO.CategoryName = category.CategoryName;
                categoryDTO.CategoryDescription = category.CategoryDescription;

                return Ok(categoryDTO);

            } 
            return BadRequest();
        
        }

        [HttpPost("Add")]
        public IActionResult Add(CategoryDTO categoryDTO) 
        {
            if (ModelState.IsValid) 
            {
                Category category = new Category();
                category.CategoryName = categoryDTO.CategoryName;
                category.CategoryDescription = categoryDTO.CategoryDescription;
                 
                _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                return Ok(category);

            }
            return BadRequest();      
        
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoryDTO categoryDTO,int id) 
        {
            if (ModelState.IsValid) 
            {
                var category=_unitOfWork.Category.GetById(id);
                if (category != null&&category.CategoryId==id) 
                {
                    category.CategoryName = categoryDTO.CategoryName;
                    category.CategoryDescription=categoryDTO.CategoryDescription;
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Complete();
                    return Ok("Updated");

                }

            }
            return BadRequest();
        
        
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var category=_unitOfWork.Category.GetById(id);
            if (category != null)
            {
                _unitOfWork.Category.DeleteById(category.CategoryId);
                _unitOfWork.Complete();
                return Ok("deleted");
            }
            return BadRequest();
        
        }

    }
}
