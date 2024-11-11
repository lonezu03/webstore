﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entity
{
    public class User
    {
        public int Id { get; set; }         // Mã người dùng (Primary Key)
        public string Username { get; set; } // Tên đăng nhập
        public string Email { get; set; }    // Email người dùng
        public string Password { get; set; } // Mật khẩu (cần hash trong thực tế)
        public ICollection<Address> Addresses { get; set; }

    }
}

