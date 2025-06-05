using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMvc.Models;

namespace ProjectMvc.Data
{
    public class ProjectMvcContext : DbContext
    {
        public ProjectMvcContext (DbContextOptions<ProjectMvcContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectMvc.Models.Departament> Departament { get; set; } = default!;
        public DbSet<Saller> Saller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
