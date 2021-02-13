using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubApi.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;


namespace ClubApi.Models
{
    public class DataContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Fac> Facs { get; set; }
        public DbSet<Locker> Locker { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberLevel> MemberLevel { get; set; }
        public DbSet<MemberType> MemberType { get; set; }
        public DbSet<Rifle> Rifle { get; set; }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Configuration.GetConnectionString("membersdb") + "password=inverness07");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Member>(entity =>
        //    {
        //        entity.Property(e => e.MemberNo).IsRequired();
        //        entity.Property(e => e.FirstName).IsRequired();
        //        entity.Property(e => e.Surname).IsRequired();
        //    });
        //}
    }
}
