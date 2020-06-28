using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Student.CRUD.Model;

namespace WebApi.Student.CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class _DetailController : ControllerBase
    {
        private readonly DemoContext _demoContext;

        public _DetailController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        [HttpPost]
        public IActionResult GetList()
        {
            List<Student_Group_Detail> de = _demoContext.DB.Queryable<Student_Group_Detail>().ToList();
            var json = new
            {
                code = 0,
                msg = "",
                count = de.Count,
                data = de
            };
            return Ok(json);

        }
    }
}
