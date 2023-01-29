using CoursatyApp.Data;
using CoursatyApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public ActionResult GetCourses(string category , string SearchQuery)
        {
            var courses = coursesDbContext.Courses.ToList();

            return Ok(courses);
        }
        [HttpGet("{courseId}")]

        public ActionResult GetCourse(int courseId)
        {
            var course = coursesDbContext.Courses.Find(courseId);

            return Ok(course);
        }


        [HttpPost]
        public ActionResult CreateCourse(Course CourseInfo)
        {
            CourseInfo.Creation_Date = DateTime.UtcNow;
            coursesDbContext.Courses.Add(CourseInfo);
            coursesDbContext.SaveChanges();
         

            return Ok(CourseInfo);
        }


        [HttpDelete("{courseId}")]

        public ActionResult DeleteCourse(int courseId)
        {
            var course = coursesDbContext.Courses.Find(courseId);

            if(course == null)
            {
                return BadRequest("Course Doesn't Exist !");
            }
            
            coursesDbContext.Courses.Remove(course);
            coursesDbContext.SaveChanges();


            return Ok(course);
        }



        [HttpPut("{courseId}")]

        public ActionResult UpdateCourse(Course CourseInfo)
        {
            var course = coursesDbContext.Courses.Find(CourseInfo.Id);

            if (course == null)
            {
                return BadRequest("Course Doesn't Exist !");
            }

            course.Description = CourseInfo.Description;
            course.Name = CourseInfo.Name;  
                coursesDbContext.Entry(course).State = EntityState.Modified;
            coursesDbContext.SaveChanges();


            return Ok(course);
        }


    }
}
