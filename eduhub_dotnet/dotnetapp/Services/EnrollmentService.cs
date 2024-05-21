using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Services
{
    public class EnrollmentService
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments
                                 .Include(e => e.User)
                                 .Include(e => e.Course)
                                 .ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int enrollmentId)
        {
            return await _context.Enrollments
                                 .Include(e => e.User)
                                 .Include(e => e.Course)
                                 .FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId);
        }

        public async Task<bool> AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEnrollment(int enrollmentId, Enrollment enrollment)
        {
            var existingEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId);

            if (existingEnrollment == null)
                return false;

            enrollment.EnrollmentId = enrollmentId;
            _context.Entry(existingEnrollment).CurrentValues.SetValues(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEnrollment(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId);
            if (enrollment == null)
                return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int courseId)
        {
            return await _context.Enrollments
                                 .Where(e => e.CourseId == courseId)
                                 .Include(e => e.User)
                                 .Include(e => e.Course)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByUserId(int userId)
        {
            return await _context.Enrollments
                                 .Where(e => e.UserId == userId)
                                 .Include(e => e.User)
                                 .Include(e => e.Course)
                                 .ToListAsync();
        }
    }
}
