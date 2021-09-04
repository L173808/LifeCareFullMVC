using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCareFullMVC.Models
{
    public class DoctorModule
    {
        // doctor module section 
        // coloumns are setted according to 
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }



        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Speciality")]
        public string Speciality { get; set; }



    }
}
