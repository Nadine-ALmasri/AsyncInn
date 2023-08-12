using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models;
using AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.VisualBasic;
using AsyncInnManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AsyncInnManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenity ;

        public AmenitiesController(IAmenities amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
         
            return await _amenity.GetAllAmenities();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
        var amenity = await _amenity.GetAmenityById(id);

            return amenity;
        }
        [Authorize(Roles = "District Manager, Property Manager")]
        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            var updatedAmenity = await _amenity.UpdateAmenity(id, amenity);

            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        [Authorize(Roles = "District Manager, Property Manager")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
          await _amenity.CreateAmenity(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        [Authorize(Roles = "District Manager, Property Manager")]// DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            
            await _amenity.DeleteAmenity(id);

            return NoContent();
        }

        
    }
}
