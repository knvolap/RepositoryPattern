using AutoMapper;
using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using EFCoreMySQL.Repository;
using EFCoreMySQL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository categoryRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public CategoryController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            categoryRepository = new CategoryRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> List()
        {
            var customers = await categoryRepository.ListAsync();
            IEnumerable<Category> categories = new List<Category>();
            _mapper.Map(customers, categories);
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            Category category1 = new Category();
            _mapper.Map(category, category1);
            await categoryRepository.AddAsync(category);
            return Ok(category.IDCategory);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            Category category1 = new Category();
            _mapper.Map(category, category1);
            await categoryRepository.UpdateAsync(category);
            return Ok(category.IDCategory);
        }
        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            Category category1 = await categoryRepository.GetDetailAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }
            await categoryRepository.DeleteAsync(category1);
            return Ok();
        }

        //[HttpDelete] // xóa sai
        //public async Task<IActionResult> Delete(Category category)
        //{
        //    Category category1 = await categoryRepository.GetDetailAsync(category);
        //    if (category1 == null)
        //    {
        //        return BadRequest();
        //    }
        //    await categoryRepository.DeleteAsync(category);
        //    return Ok();
        //}



    }
}
