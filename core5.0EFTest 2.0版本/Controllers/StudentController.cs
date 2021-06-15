using ContextRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace core5._0EFTest_2._0版本.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context) {
            _context = context;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] Student s)
        {
            try
            {
                _context.Add(s);
                int rows = _context.SaveChanges();
                return Ok(rows); 
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }


        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBatch([FromBody] List<Student> ss)
        {
            try
            {
                _context.Set<Student>().AddRange(ss);
                int rows = _context.SaveChanges();
                return Ok(rows);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }



        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateName(int id, string name)
        {
            try
            {
                var info = _context.Students.First(s => s.id == id);
                info.name = name;
                int rows = _context.SaveChanges();
                return Ok(rows);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateBatch([FromBody] List<Student> ss)
        {
            try
            {
                _context.Students.UpdateRange(ss);
                int rows = _context.SaveChanges();
                return Ok(rows);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }


        /// <summary>
        /// 查询内容是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult IsExist(string name, string sex)
        {
            try
            {
                //bool b= context.表名.Any(c=> c.主键 == 对比的数字);
                bool b = _context.Students.Any(s => s.name == name && s.sex == sex);

                return Ok(b);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Query(string name)
        {
            try
            {
                Expression<Func<Student, bool>> where = t => 1 == 1;
                if (!string.IsNullOrEmpty(name))
                {
                    where = s => s.name == name;


                }



                //var where = PredicateBuilder.New<Student>(true);
                //where.And(t => 1 == 1);
                //if (!string.IsNullOrEmpty(name))
                //{
                //    where.And(t => t.name == name);
                //}
                var info = _context.Students.Where(where).ToList();
                return Ok(info);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageNum">页码</param>
        /// <param name="PageSize">页容量</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PagingQuery(int PageNum, int PageSize)
        {
            try
            {
                var info = _context.Students.OrderBy(t => t.id).Skip(PageSize * (PageNum - 1)).Take(PageSize);

                int totalNumber = _context.Students.Count();  //总条数

                int pageCount = (int)Math.Ceiling(totalNumber / (PageSize * 1.0));

                PageData pd = new PageData()
                {
                    pageSize = PageSize,
                    pageCount = pageCount,
                    pageNum = PageNum,
                    totalNumber = totalNumber,
                    data = info
                };


                return Ok(pd);
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }

        }




    }
}
