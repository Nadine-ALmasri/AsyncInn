namespace AsyncInnManagementSystem.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFrindly  { get; set; }
        public Hotel Hotel { get; set; }
       public Room Room { get; set; }
       
    }
}
