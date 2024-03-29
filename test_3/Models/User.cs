﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_3.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter your Name")]
        [Display(Name = "Name")]
        [MinLength(4)]
        public String Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
