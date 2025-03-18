﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserDTO(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
