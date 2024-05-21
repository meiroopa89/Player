using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<Course>> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseById(courseId);

            if (course == null)
                return NotFound(new { message = "Cannot find any course" });

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse([FromBody] Course course)
        {
            try
            {
                var success = await _courseService.AddCourse(course);
                if (success)
                    return Ok(new { message = "Course added successfully" });
                else
                    return StatusCode(500, new { message = "Failed to add course" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult> UpdateCourse(int courseId, [FromBody] Course course)
        {
            try
            {
                var success = await _courseService.UpdateCourse(courseId, course);

                if (success)
                    return Ok(new { message = "Course updated successfully" });
                else
                    return NotFound(new { message = "Cannot find any course" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{courseId}")]
        public async Task<ActionResult> DeleteCourse(int courseId)
        {
            try
            {
                var success = await _courseService.DeleteCourse(courseId);

                if (success)
                    return Ok(new { message = "Course deleted successfully" });
                else
                    return NotFound(new { message = "Cannot find any course" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
