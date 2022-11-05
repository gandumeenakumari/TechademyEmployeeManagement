using Microsoft.EntityFrameworkCore;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
         public DbSet<Designation> Designation { get; set; }
        public DbSet<EmployeeDTO> employeeDTOs { get; set; }
        public DbSet<RequestLeave> requestLeaves { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

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
