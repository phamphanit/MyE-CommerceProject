using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DataModels
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Loai> loais { get; set; }
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<HinhSanPham> hinhSanPhams { get; set; }
        public DbSet<ChiTietDonHang> chiTietDonHangs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
            modelBuilder.Entity<HangHoa>()
                .Property(p => p.MaHH)
                .IsRequired();
            modelBuilder.Entity<Loai>()
                .HasIndex(p => p.MaLoai)
                .IsUnique();
            
                

        }
    }
}
