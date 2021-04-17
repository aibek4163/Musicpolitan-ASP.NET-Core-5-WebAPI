using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musicpolitan.Models;

namespace Musicpolitan.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Releases> Releases { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Songs> Songs { get; set; }

    }
}
