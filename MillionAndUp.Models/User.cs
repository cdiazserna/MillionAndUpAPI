﻿namespace MillionAndUp.Models
{
    public class User : AuditBase
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
