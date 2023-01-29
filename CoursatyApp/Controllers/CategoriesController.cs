using CoursatyApp.Data;
using CoursatyApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursatyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CoursesDbContext coursesDbContext;

        public CategoriesController(CoursesDbContext coursesDbContext)
        {
            this.coursesDbContext = coursesDbContext;
        }
        [HttpGet]
        public ActionResult GetCourses()
        {
            var Categories = coursesDbContext.Categories.ToList();

            return Ok(Categories);
        }
        [HttpGet("{categoryId}")]

        public ActionResult GetCourse(int categoryId)
        {
            var category = coursesDbContext.Categories.Find(categoryId);

            return Ok(category);
        }


        [HttpPost]
        public ActionResult CreateCourse(Category CategoryInfo)
        {
            
            coursesDbContext.Categories.Add(CategoryInfo);
            coursesDbContext.SaveChanges();


            return Ok(CategoryInfo);
        }


        [HttpDelete("{categoryId}")]

        public ActionResult DeleteCourse(int categoryId)
        {
            var Category = coursesDbContext.Categories.Find(categoryId);

            if (Category == null)
            {
                return BadRequest("Category Doesn't Exist !");
            }

            coursesDbContext.Categories.Remove(Category);
            coursesDbContext.SaveChanges();


            return Ok(Category);
        }



        [HttpPut("{categoryId}")]

        public ActionResult UpdateCourse(Category CategoryInfo)
        {
            var category = coursesDbContext.Categories.Find(CategoryInfo.Id);

            if (category == null)
            {
                return BadRequest("category Doesn't Exist !");
            }


            category.Name = CategoryInfo.Name;

            coursesDbContext.Entry(category).State = EntityState.Modified;
            coursesDbContext.SaveChanges();


            return Ok(category);
        }
    }
}
