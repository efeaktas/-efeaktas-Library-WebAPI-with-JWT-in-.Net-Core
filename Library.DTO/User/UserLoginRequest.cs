using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DTO.User
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
