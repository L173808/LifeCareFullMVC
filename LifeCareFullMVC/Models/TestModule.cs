using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCareFullMVC.Models
{
    public class TestModule
    {

        // Test module
        public int id { get; set; }

        [Display(Name = "Test Name")]
        public string TestName { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }



        [Display(Name = "Date ")]
        public DateTime dTime { get; set; }

        public PatientModule patient { get; set; }
    }
}
