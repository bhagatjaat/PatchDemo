using Microsoft.EntityFrameworkCore;
using PatchManagementApi.Models;
using System.Collections.Generic;

namespace PatchManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Patch> Patches { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PatchStatus> PatchStatuses { get; set; }
    }
}
