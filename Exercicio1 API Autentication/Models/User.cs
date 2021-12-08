﻿using System;

namespace Exercicio1_API_Autentication.Models
{
    public class User : Base
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int FailedAttempts { get; set; }
        public bool  IsLockout { get; set; }
        public DateTime? LockoutDate { get; set; }
    }
}
