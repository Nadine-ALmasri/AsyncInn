﻿namespace AsyncInnManagementSystem.Models.DTO
{
    public class RegisterDTO
    {
        public string  UserName  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<string> Roles { get; set; }
    }
}
