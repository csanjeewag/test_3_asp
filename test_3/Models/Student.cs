using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_3.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter your Name")]
        [Display(Name = "Name")]
        [MinLength(4)]
        public String Name { get; set; }

        [Required(ErrorMessage = "please enter RegisterDate")]
        [Display(Name = "RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required(ErrorMessage = "please enter BirthdayDate")]
        [Display(Name = "BirthdayDate")]
        public DateTime BirthdayDate { get; set; }

        [Required(ErrorMessage = "please enter AL Stream")]
        [Display(Name = "AL Stream")]
        public String ALStream { get; set; }

    }
}
