using AutoMapper;
using CoursatyApp.Data;
using CoursatyApp.DTOs;
using CoursatyApp.Entities;
using CoursatyApp.Services;
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
       
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public CoursesController(ICourseService courseService , IMapper mapper)
        {
            
            this.courseService = courseService;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetCourses([FromQuery] string category , [FromQuery]  string SearchQuery)
        {
            if(string.IsNullOrEmpty(category) && string.IsNullOrEmpty(SearchQuery)) {

                var coursesList2 = courseService.GetCourses().ToList();
                var dtoCourses1 = mapper.Map<List<Course>, List<CourseDto>>(coursesList2);




                return Ok(mapper.Map<List<Course>, List<CourseDto>>(coursesList2));
               
            }
            var courses = courseService.GetCourses(); 
            if (!string.IsNullOrEmpty(category) )
            {

                courses = courses.Where(c => c.CategoryId == int.Parse(category));
            }

            if (!string.IsNullOrEmpty(SearchQuery))
            {

                courses = courses.Where(c => c.Name.Contains(SearchQuery) || c.Description.Contains(SearchQuery));
            }

            var coursesList =courses.ToList();

            var dtoCourses = mapper.Map<List<Course> , List<CourseDto>>(coursesList);

         


            return Ok(mapper.Map<List<Course>, List<CourseDto>>(coursesList));
        }  
        [HttpGet("{courseId}")]

        public ActionResult GetCourse(int courseId)
        {
            var course = courseService.GetCourse(courseId);

            if (course == null)
                return BadRequest("Course not found !");

            return Ok(mapper.Map<Course , CourseDto>(course));
        }


        [HttpPost]
        public ActionResult CreateCourse(Course CourseInfo)
        {
          
            courseService.CreateCourse(CourseInfo);

            return Ok(mapper.Map<Course, CourseDto>(CourseInfo));
        }


        [HttpDelete("{courseId}")]

        public ActionResult DeleteCourse(int courseId)
        {
            var course = courseService.GetCourse(courseId);

            if (course == null)
                return BadRequest("Course not found !");

            courseService.DeleteCourse(courseId);
            


            return Ok(mapper.Map<Course, CourseDto>(course));
        }



        [HttpPut("{courseId}")]

        public ActionResult UpdateCourse(Course CourseInfo)
        {
            var course = courseService.GetCourse(CourseInfo.Id);

            if (course == null)
                return BadRequest("Course not found !");

            courseService.UpdateCourse(CourseInfo , CourseInfo.Id);




            return Ok(mapper.Map<Course, CourseDto>(course));
        }


    }
}
