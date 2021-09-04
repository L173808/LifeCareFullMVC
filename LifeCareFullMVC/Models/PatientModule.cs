using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCareFullMVC.Models
{
    public class PatientModule
    {
        // patient Module login 
        // following are coumns of Patient Module
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }



        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Disease")]
        public string Disease { get; set; }

        public DoctorModule doctor { get; set; }

    }
}
