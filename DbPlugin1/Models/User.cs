﻿namespace DbPlugin1.Models
{
    class User
    {
        public long UserId { get; set; }

        public string Login { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string? City { get; set; } = null;
    }
}
