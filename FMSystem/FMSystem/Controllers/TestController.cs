using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using FMSystem.Entity;
using FMSystem.Entity.fms;
using FMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FMSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly fmsContext _context;
        private readonly ILogger<TestController> _logger;

        public TestController(fmsContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            //call fun;
            var obj = 3;
            return Ok(obj);
        }
        [HttpGet]
        public IActionResult GetCourse(int section,int from,int to)
        {
            var ResponseModel = new ResponseModel();
            return Ok(ResponseModel);
        }
    }
}
