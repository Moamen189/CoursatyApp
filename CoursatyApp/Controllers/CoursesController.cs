using CoursatyApp.Data;
using CoursatyApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoursatyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesDbContext coursesDbContext;

        public CoursesController(CoursesDbContext coursesDbContext)
        {
            this.coursesDbContext = coursesDbContext;
        }
        [HttpGet]
        public ActionResult GetCourse()
        {
            var course = coursesDbContext.Courses.ToList();

            return Ok(course);
        }

        [HttpPost]
        public ActionResult CreateCourse(Course CourseInfo)
        {
         

            return Ok();
        }

    }
}
