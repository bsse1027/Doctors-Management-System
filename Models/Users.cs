﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
