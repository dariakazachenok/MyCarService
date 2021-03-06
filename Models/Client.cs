﻿using System;

namespace Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public string Address { get; set; }

        public int? Phone { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }
    }
}
