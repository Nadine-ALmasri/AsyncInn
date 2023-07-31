using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnManagementSystem.Models
{
    public class RoomAmenity
    {
        // Foreign key property names should match the related class property names exactly
        public int AmenityId { get; set; }
        public int RoomId { get; set; }

        // Navigation properties
        public Room? Room { get; set; }

        public Amenity? Amenity { get; set; }
    }
}
