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

namespace AsyncInnManagementSystem.Controller
{
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _HotelRoom;

        public HotelRoomsController(IHotelRoom hotelroom)
        {
            _HotelRoom = hotelroom;
        }

        // GET: api/Hotels/{hotelId}/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
         
            return await _HotelRoom.GetAllHotelRoom(hotelId);
        }

        // GET: api/Hotels/{hotelId}/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var room = await _HotelRoom.GetRoomDetails(hotelId, roomNumber);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        // PUT: api/Hotels/{hotelId}/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom room)
        {
            if (roomNumber != room.RoomNumber)
            {
                return BadRequest();
            }

            var updatedRoom = await _HotelRoom.UpdateHotelsRoom(hotelId, roomNumber, room);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return NoContent();

            return NoContent();
        }

        // POST: api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoom HotelRoom)
        {
         var addedRoom = await _HotelRoom.CreateHotelRoom(hotelId, HotelRoom);
            if (addedRoom == null)
            {
                return NotFound();
            }
            return CreatedAtAction(("GetRoomDetails"), new { hotelId, roomNumber = addedRoom.RoomNumber }, addedRoom);

        }

        // DELETE: api/Hotels/{hotelId}/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
           

           _HotelRoom.DeleteHotelRoom(hotelId, roomNumber);

            return NoContent();
        }

       
    }
}
