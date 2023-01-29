using CoursatyApp.Data.Repositories;
using CoursatyApp.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoursatyApp.Services
{
    public interface ICourseService
    {

        IEnumerable<Course> GetCourses();

         Course GetCourse(int id);
        //  Course GetCourseById(int id);

        bool IsCourseExists(string name);
        Course UpdateCourse(Course course , int id);
        Course DeleteCourse( int id);

        Course CreateCourse(Course course);


    }
    public class CourseServices : ICourseService
    {
        private readonly CourseRepository courseRepository;

        public CourseServices(CourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public Course CreateCourse(Course course)
        {
           if(course == null)
                throw new ArgumentNullException(nameof(course));

            if (IsCourseExists(course.Name))
                return null;
            course.Creation_Date = DateTime.UtcNow;    
            return courseRepository.Add(course);
        }

        public Course DeleteCourse(int id)
        {
           var course = GetCourse(id);

            if(course == null)
                return null;

            return courseRepository.Delete(id);
        }

        public Course GetCourse(int id)
        {
           return courseRepository.Get(id);
        }

        //public Course GetCourseById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public IEnumerable<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }

        public bool IsCourseExists(string name)
        {
            return courseRepository.Get(c => c.Name == name).Any();
        }

        public Course UpdateCourse(Course course, int id)
        {
            var exitsCourse = GetCourse(id);
            exitsCourse.Name = course.Name;
            exitsCourse.Description = course.Description;
            return courseRepository.Update(course);

        }
    }
}
