using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetWeb.Models
{
    public class DotnetWebContext : DbContext
    {
        public DotnetWebContext(DbContextOptions<DotnetWebContext> options)
            : base(options)
        {
        }

        public DbSet<Memes> Memes { get; set; }
    }
}
