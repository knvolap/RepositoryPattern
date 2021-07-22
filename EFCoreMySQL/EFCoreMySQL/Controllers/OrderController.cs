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
    public class OrderController : ControllerBase
    {
        private readonly OderRepository oderRepository;
        private readonly IMapper _mapper;
        private MyDBContext myDbContext;
        public OrderController(MyDBContext _context, IMapper mapper)
        {
            _mapper = mapper;
            oderRepository = new OderRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oder>>> List()
        {
            var oders1 = await oderRepository.ListAsync();
            IEnumerable<Oder> oders = new List<Oder>();
            _mapper.Map(oders1, oders);
            return Ok(oders);
        }

    }
}
