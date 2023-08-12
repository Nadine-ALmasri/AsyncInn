namespace AsyncInnManagementSystem.Models.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string  Token { get; set; }
        public IList<string>  Roles { get; set; }
    }
}
