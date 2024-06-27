using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeaker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevEvent>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(k => k.Title).IsRequired(false);
                e.Property(k => k.Description).HasMaxLength(200).HasColumnType("varchar(200)");
                e.Property(k => k.StartDate).HasColumnName("Start_Date");
                e.Property(k => k.EndDate).HasColumnName("End_Date");
                e.HasMany(k => k.Speakers).WithOne().HasForeignKey(fk => fk.DevEventId);
            });

            modelBuilder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(k => k.Id);
            });
        }
    }
}
