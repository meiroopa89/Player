// ScheduleController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [Authorize(Roles = "Organizer")]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }
        [Authorize(Roles = "Organizer")]

        [HttpGet("{scheduleId}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int scheduleId)
        {
            var schedule = await _scheduleService.GetScheduleById(scheduleId);

            if (schedule == null)
            {
                return NotFound(new { message = "Cannot find any schedule" });
            }

            return Ok(schedule);
        }
        
        [Authorize(Roles = "Organizer")]

        [HttpPost]
        public async Task<ActionResult> AddSchedule([FromBody] Schedule schedule)
        {
            try
            {
                var success = await _scheduleService.AddSchedule(schedule);

                if (success)
                {
                    return Ok(new { message = "Schedule added successfully" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to add schedule" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize(Roles = "Organizer")]

        [HttpPut("{scheduleId}")]
        public async Task<ActionResult> UpdateSchedule(int scheduleId, [FromBody] Schedule schedule)
        {
            try
            {
                var success = await _scheduleService.UpdateSchedule(scheduleId, schedule);

                if (success)
                {
                    return Ok(new { message = "Schedule updated successfully" });
                }
                else
                {
                    return NotFound(new { message = "Cannot find any schedule" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize(Roles = "Organizer")]

        [HttpDelete("{scheduleId}")]
        public async Task<ActionResult> DeleteSchedule(int scheduleId)
        {
            try
            {
                var success = await _scheduleService.DeleteSchedule(scheduleId);

                if (success)
                {
                    return Ok(new { message = "Schedule deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "Cannot find any schedule" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
