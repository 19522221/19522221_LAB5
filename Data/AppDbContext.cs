using Microsoft.EntityFrameworkCore;
using LAB5.Models;

namespace LAB5.Data {

    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder
       modelBuilder) {
            modelBuilder.Entity<CongNhan>().ToTable("congnhan");

            modelBuilder.Entity<TrieuChung>().ToTable("trieuchung");

            modelBuilder.Entity<DiemCachLy>().ToTable("diemcachly");
            modelBuilder.Entity<CN_TC>().ToTable("cn_tc").HasKey(c => new { c.MaCongNhan, c.MaTrieuChung });
        }

        public DbSet<LAB5.Models.DiemCachLy> DiemCachLy { get; set; }

        public DbSet<LAB5.Models.TrieuChung> TrieuChung { get; set; }

        public DbSet<LAB5.Models.CN_TC> CN_TC { get; set; }
    }
}