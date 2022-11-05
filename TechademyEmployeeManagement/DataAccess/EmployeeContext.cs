using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.DataAccess.Models;

namespace TechademyEmployeeManagement.DataAccess
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
         public DbSet<Designation> Designation { get; set; }
        public DbSet<EmployeeDTO> employeeDTOs { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<EmployeeDetails>(entity =>
        //    {
        //        entity.ToTable("EmployeeDetails");
        //        entity.HasOne(d => d.Designation)
        //        .WithMany(d => d.EmployeeDetails)
        //        .HasForeignKey(d => d.DesignationID)
        //        .HasConstraintName("FK_EmployeeDetails_Designation");
        //    });
        //    builder.Entity<Designation>(entity =>
        //    {
        //        entity.ToTable("Designation");
        //    });
        //    base.OnModelCreating(builder);
        //}
    }
}
