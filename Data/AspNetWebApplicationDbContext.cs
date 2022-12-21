using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetWebApplication.Models;

namespace AspNetWebApplication.Data
{
    public class AspNetWebApplicationDbContext : DbContext
    {
        public AspNetWebApplicationDbContext (DbContextOptions<AspNetWebApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetWebApplication.Models.OfficeSpace> OfficeSpace { get; set; }
    }
}
