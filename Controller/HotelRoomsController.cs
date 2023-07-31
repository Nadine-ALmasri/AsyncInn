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
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int hotelId)
        {
         
            return await _HotelRoom.GetAllHotelRoom(hotelId);
        }

        // GET: api/Hotels/{hotelId}/Rooms/5
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]

        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNumber)
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
        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoomDTO roomDTO)
        {
            if (roomNumber != roomDTO.RoomNumber)
            {
                return BadRequest();
            }

            var updatedRoom = await _HotelRoom.UpdateHotelsRoom(hotelId, roomNumber, roomDTO);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return NoContent();

        }

        // POST: api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(int hotelId, HotelRoomDTO HotelRoomDTO)
        {
         var addedRoom = await _HotelRoom.CreateHotelRoom(hotelId, HotelRoomDTO);
            if (addedRoom == null)
            {
                return NotFound();
            }
            return Ok (addedRoom);

        }

        // DELETE: api/Hotels/{hotelId}/Rooms/5
        [HttpDelete()]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]

        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            if (_HotelRoom == null)
            {
                return NotFound();
            }

            await   _HotelRoom.DeleteHotelRoom(hotelId, roomNumber);

            return NoContent();
        }

       
    }
}
