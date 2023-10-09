using BOL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DAL
{   



    public class BCDbContext : DbContext
    {

        public DbSet<BCUser>? Users { get; set; }

        public BCDbContext(DbContextOptions<BCDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=INSPIRON580S;Database=BCDb; Trusted_Connection = True; TrustServerCertificate = True");
        }
        
    }

    
}