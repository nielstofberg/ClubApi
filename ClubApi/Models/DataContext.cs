using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubApi.Models;

namespace ClubApi.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberType> MemberType { get; set; }
        public DbSet<Locker> Locker { get; set; }
        public DbSet<Rifle> Rifle { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Activity> Activity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=PI4-A;database=clubmembersdb;user=exampleuser;password=lollas");
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
