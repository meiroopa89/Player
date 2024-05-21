using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllEnrollments();
            return Ok(enrollments);
        }

        [HttpGet("{enrollmentId}")]
        public async Task<ActionResult<Enrollment>> GetEnrollmentById(int enrollmentId)
        {
            var enrollment = await _enrollmentService.GetEnrollmentById(enrollmentId);

            if (enrollment == null)
                return NotFound(new { message = "Cannot find any enrollment" });

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<ActionResult> AddEnrollment([FromBody] Enrollment enrollment)
        {
            try
            {
                var success = await _enrollmentService.AddEnrollment(enrollment);
                if (success)
                    return Ok(new { message = "Enrollment added successfully" });
                else
                    return StatusCode(500, new { message = "Failed to add enrollment" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{enrollmentId}")]
        public async Task<ActionResult> UpdateEnrollment(int enrollmentId, [FromBody] Enrollment enrollment)
        {
            try
            {
                var success = await _enrollmentService.UpdateEnrollment(enrollmentId, enrollment);

                if (success)
                    return Ok(new { message = "Enrollment updated successfully" });
                else
                    return NotFound(new { message = "Cannot find any enrollment" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{enrollmentId}")]
        public async Task<ActionResult> DeleteEnrollment(int enrollmentId)
        {
            try
            {
                var success = await _enrollmentService.DeleteEnrollment(enrollmentId);

                if (success)
                    return Ok(new { message = "Enrollment deleted successfully" });
                else
                    return NotFound(new { message = "Cannot find any enrollment" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentsByCourseId(int courseId)
        {
            var enrollments = await _enrollmentService.GetEnrollmentsByCourseId(courseId);
            return Ok(enrollments);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentsByUserId(int userId)
        {
            var enrollments = await _enrollmentService.GetEnrollmentsByUserId(userId);
            return Ok(enrollments);
        }
    }
}
