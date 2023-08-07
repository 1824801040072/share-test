using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//lớp bối cảnh hoạt động 
namespace WebAPI.Models
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions options):base(options) 
        { 

        }

        public DbSet<DonViVanTai> DonViVanTais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViVanTai>().ToTable("DonViVanTai");
            modelBuilder.Entity<DonViVanTai>().HasKey(t => t.Uuid);
        }
    }
}
