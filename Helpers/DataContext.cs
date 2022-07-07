using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : IdentityDbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		
        public DbSet<User> Users { get; set; }
		public DbSet<Agency> Agencies { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<CareHome> CareHomes { get; set; }
		public DbSet<Medication> Medications { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<WeeklyWorkingHour> WeeklyWorkingHours { get; set; }
	}
}