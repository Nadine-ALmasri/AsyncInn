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
using AsyncInnManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AsyncInnManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotels  _hotel;

        public HotelsController(IHotels Hotel)
        {
            _hotel = Hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
         
           var list = await _hotel.GetAll();
            return Ok(list);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
          
            var hotel = await _hotel.GetById(id);

            return hotel;
        }
        [Authorize(Roles = "District Manager")]

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotelDTO)
        {
            if (id != hotelDTO.ID)
            {
                return BadRequest();
            }

            var updatedCourse = await _hotel.UpdateHotels(id, hotelDTO);
            return Ok(updatedCourse);
        }
        [Authorize(Roles = "District Manager")]

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDTO hotelDTO)
        {
        await _hotel.Create(hotelDTO);

            return CreatedAtAction("GetHotel", new { id = hotelDTO.ID }, hotelDTO);
        }
        [Authorize(Roles = "District Manager")]

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.Delete(id);

            return NoContent();
        }

        
    }
}
