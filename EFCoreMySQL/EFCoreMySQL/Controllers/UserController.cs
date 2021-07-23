using AutoMapper;
using connectMySQL.Interface;
using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using EFCoreMySQL.Repository;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IIdentityService identityService;
        private readonly UserRepository userRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;

        public UserController(IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            _mapper = mapper;
        }
   
        //// GET: api/<UserController>
        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> List()
        //{
        //    var user1 = await userRepository.ListAsync();
        //    IEnumerable<User> users = new List<User>();
        //    _mapper.Map(user1, users);
        //    return Ok(users);
        //}

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] LoginModels loginModel)
        {
            ResponseToken authenResponse = identityService.Authentication(loginModel);

            return Ok(authenResponse);

        }
        // GET: api/<UserController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = userRepository.ListAsync();

            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }












        //public UserController(MyDBContext _context, IMapper mapper)
        //{
        //    _mapper = mapper;
        //    userRepository = new UserRepository(_context);
        //}

        //[HttpGet]
        //public IList<User> Get()
        //{
        //    return (this.myDbContext.Users.ToList());
        //}

        //[HttpPost]
        //public string Post(User obj)
        //{
        //    return obj.Id + obj.Account + obj.Password + obj.CreationDateTime;
        //}
        //[HttpDelete]
        //public string Delete(User data)
        //{
        //    return data.Id + data.Account + data.Password + data.CreationDateTime;
        //}


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
