using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Appdb : DbContext
    {
        public Appdb(DbContextOptions options) : base(options) { }  // db instnce

        public DbSet<Users> Users { get; set; } // table
        public DbSet<Tasks> Tasks { get; set; } // table
    }
}
