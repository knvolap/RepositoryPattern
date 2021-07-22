using AutoMapper;
using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using EFCoreMySQL.Repository;
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
    public class UserGroupController : ControllerBase
    {
        private readonly UserGroupRepository userGroupRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public UserGroupController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            userGroupRepository = new UserGroupRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroup>>> List()
        {
            var userGroups1 = await userGroupRepository.ListAsync();
            IEnumerable<UserGroup> usergr = new List<UserGroup>();
            _mapper.Map(userGroups1, usergr);
            return Ok(usergr);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserGroup userGroup)
        {
            UserGroup userGroup1 = new UserGroup();
            _mapper.Map(userGroup, userGroup1);
            await userGroupRepository.AddAsync(userGroup);
            return Ok(userGroup.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserGroup userGroup)
        {
            UserGroup userGroup1 = new UserGroup();
            _mapper.Map(userGroup, userGroup1);
            await userGroupRepository.UpdateAsync(userGroup);
            return Ok(userGroup.Id);
        }
        [HttpDelete("{id}")] //xóa đúng
        public async Task<IActionResult> Delete(int id)
        {
            UserGroup userGroup1 = await userGroupRepository.GetDetailAsync(id);
            if (userGroup1 == null)
            {
                return NotFound();
            }
            await userGroupRepository.DeleteAsync(userGroup1);
            return Ok();
        }





        //[HttpGet]
        //public IList<UserGroup> Get()
        //{
        //    return (this.myDbContext.UserGroups.ToList());
        //}
        //[HttpPost]
        //public string Post(UserGroup postGr)
        //{
        //    return postGr.Id + postGr.Name + postGr.CreationDateTime;
        //}



        //[HttpDelete]
        //public string Delete(UserGroup DelGr)
        //{
        //    return DelGr.Id + DelGr.Name + DelGr.CreationDateTime;
        //}

    }
}
