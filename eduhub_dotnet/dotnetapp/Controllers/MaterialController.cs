using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetAllMaterials()
        {
            var materials = await _materialService.GetAllMaterials();
            return Ok(materials);
        }

        [HttpGet("{materialId}")]
        public async Task<ActionResult<Material>> GetMaterialById(int materialId)
        {
            var material = await _materialService.GetMaterialById(materialId);

            if (material == null)
                return NotFound(new { message = "Cannot find any material" });

            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult> AddMaterial([FromBody] Material material)
        {
            try
            {
                var success = await _materialService.AddMaterial(material);
                if (success)
                    return Ok(new { message = "Material added successfully" });
                else
                    return StatusCode(500, new { message = "Failed to add material" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{materialId}")]
        public async Task<ActionResult> UpdateMaterial(int materialId, [FromBody] Material material)
        {
            try
            {
                var success = await _materialService.UpdateMaterial(materialId, material);

                if (success)
                    return Ok(new { message = "Material updated successfully" });
                else
                    return NotFound(new { message = "Cannot find any material" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{materialId}")]
        public async Task<ActionResult> DeleteMaterial(int materialId)
        {
            try
            {
                var success = await _materialService.DeleteMaterial(materialId);

                if (success)
                    return Ok(new { message = "Material deleted successfully" });
                else
                    return NotFound(new { message = "Cannot find any material" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterialsByCourseId(int courseId)
        {
            var materials = await _materialService.GetMaterialsByCourseId(courseId);
            return Ok(materials);
        }
    }
}
