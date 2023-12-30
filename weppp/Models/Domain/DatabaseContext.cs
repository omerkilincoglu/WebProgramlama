using B201210597.Models.DTO;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace B201210597.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
		public DatabaseContext()
		{
		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
		public DbSet<Department> Departments { get; set; }

		public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Kullanici> Kullaniciler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Clinics)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Kullanici)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.KullaniciId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>();


        }

    }
}