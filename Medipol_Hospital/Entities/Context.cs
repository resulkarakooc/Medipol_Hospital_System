using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSoft.Entities
{
    public class Context : DbContext
    {
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Peak> Peaks { get; set; }
        public DbSet<Patinets> Patches { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}