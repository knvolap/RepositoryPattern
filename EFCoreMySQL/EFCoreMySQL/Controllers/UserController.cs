using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
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
    public class UserController : ControllerBase
    {
        private MyDBContext myDbContext;

        public UserController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<User> Get()
        {
            return (this.myDbContext.Users.ToList());
        }

        [HttpPost]
        public string Post(User obj)
        {
            return obj.Id + obj.Account + obj.Password + obj.CreationDateTime;
        }
        [HttpDelete]
        public string Delete(User data)
        {
            return data.Id + data.Account + data.Password + data.CreationDateTime;
        }


        ////http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        //[HttpGet("paging")]
        //public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        //{
        //    var products = await _userService.GetUsersPaging(request);
        //    return Ok(products);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var user = await _userService.GetById(id);
        //    return Ok(user);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var result = await _userService.Delete(id);
        //    return Ok(result);
        //}
    }
}
