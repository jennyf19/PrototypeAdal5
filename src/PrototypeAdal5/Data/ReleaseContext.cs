using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrototypeAdal5.Models;
using Microsoft.EntityFrameworkCore;

namespace PrototypeAdal5.Data
{
    public class ReleaseContext : DbContext
    {
        public ReleaseContext(DbContextOptions<ReleaseContext> options ) : base(options)
        { }

        public DbSet<Release> Releases { get; set; }
    }
}
