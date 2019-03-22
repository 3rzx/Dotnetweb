using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetWeb.Models
{
    public class DotnetWebContent : DbContext
    {
        public DotnetWebContent(DbContextOptions<DotnetWebContent> options)
            : base(options)
        {
        }

        public DbSet<ServiceMapping> ServiceMappings { get; set; }
    }
}
