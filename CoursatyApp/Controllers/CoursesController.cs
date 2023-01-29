using CoursatyApp.Data;
using CoursatyApp.DTOs;
using CoursatyApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public ActionResult GetCourses([FromQuery] string category , [FromQuery]  string SearchQuery)
        {
            if(string.IsNullOrEmpty(category) && string.IsNullOrEmpty(SearchQuery)) { 

                return Ok(coursesDbContext.Courses.ToList());
            }
            var courses = coursesDbContext.Courses as IQueryable<Course>;
            if (!string.IsNullOrEmpty(category) )
            {

                courses = courses.Where(c => c.CategoryId == int.Parse(category));
            }

            if (!string.IsNullOrEmpty(SearchQuery))
            {

                courses = courses.Where(c => c.Name.Contains(SearchQuery) || c.Description.Contains(SearchQuery));
            }

            var coursesList =courses.ToList();

            var dtoCourses = new List<CourseDto>();

            foreach( var item in coursesList)
            {

                dtoCourses.Add(new CourseDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Creation = item.Creation_Date.ToShortDateString(),
                    Category = item.CategoryId,
                    Image = item.Image_Id
                });
                
            }


            return Ok(dtoCourses);
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
