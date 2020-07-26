using System;
using System.ComponentModel.DataAnnotations;

namespace DevWebsCourseProjectApp.Models
{
    public class Register
    {
        [Key]
        public Guid Registerid { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
