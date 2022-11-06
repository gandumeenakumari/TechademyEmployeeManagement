using Microsoft.EntityFrameworkCore;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
         public DbSet<Designation> Designation { get; set; }
        public DbSet<EmployeeDTO> employeeDTOs { get; set; }
        public DbSet<RequestLeave> requestLeaves { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeeManagement;Trusted_Connection=True;");
            }
        }
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
