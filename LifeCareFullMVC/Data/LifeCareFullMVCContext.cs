using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LifeCareFullMVC.Models;

namespace LifeCareFullMVC.Data
{
    public class LifeCareFullMVCContext : DbContext
    {
        public LifeCareFullMVCContext (DbContextOptions<LifeCareFullMVCContext> options)
            : base(options)
        {
        }

        public DbSet<LifeCareFullMVC.Models.LiginModule> LiginModule { get; set; }

        public DbSet<LifeCareFullMVC.Models.DoctorModule> DoctorModule { get; set; }

        public DbSet<LifeCareFullMVC.Models.PatientModule> PatientModule { get; set; }

        public DbSet<LifeCareFullMVC.Models.TestModule> TestModule { get; set; }
    }
}
