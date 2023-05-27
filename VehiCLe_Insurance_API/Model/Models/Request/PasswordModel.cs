﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Request
{
    public class ResetPasswordModel
    {
        public long UserId { get; set; }
        public string Password { get; set; }
    };
    public class UpdatePasswordModel
    {
        public long UserId { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        = string.Empty;
    }
}
