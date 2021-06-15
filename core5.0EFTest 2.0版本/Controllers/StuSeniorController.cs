using EFMethodInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core5._0EFTest_2._0版本.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StuSeniorController : ControllerBase
    {
        private readonly IEFHelper _helper;
        public StuSeniorController(IEFHelper helper) {
            this._helper = helper;
        }



        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Query() {
            var info = _helper.Query<Student>(t=>1 == 1);

            return Ok(info);
        }
    }
}
