using Microsoft.EntityFrameworkCore;

namespace PetHealthAPI.Models
{
    public class QLThuYContext : DbContext
    {
        public QLThuYContext(DbContextOptions<QLThuYContext> options) : base(options) { }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ThuCung> ThuCungs { get; set; }
        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Thuoc> Thuocs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CT_HoaDon> CTHoaDons { get; set; }
        public DbSet<HoSoKB> HoSoKBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThuCung>()
                .HasOne(tc => tc.KhachHang)
                .WithMany(kh => kh.ThuCungs)
                .HasForeignKey(tc => tc.MaKH);

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.ChiNhanh)
                .WithMany(cn => cn.NhanViens)
                .HasForeignKey(nv => nv.MaCN);

            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.KhachHang)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(hd => hd.MaKH);

            modelBuilder.Entity<CT_HoaDon>()
                .HasOne(cthd => cthd.HoaDon)
                .WithMany(hd => hd.CTHoaDons)
                .HasForeignKey(cthd => cthd.MaHD);

            modelBuilder.Entity<CT_HoaDon>()
                .HasOne(cthd => cthd.Thuoc)
                .WithMany(t => t.CTHoaDons)
                .HasForeignKey(cthd => cthd.MaThuoc);

            modelBuilder.Entity<HoSoKB>()
                .HasOne(hskb => hskb.ThuCung)
                .WithMany()
                .HasForeignKey(hskb => hskb.MaTC);

            modelBuilder.Entity<HoSoKB>()
                .HasOne(hskb => hskb.KhachHang)
                .WithMany()
                .HasForeignKey(hskb => hskb.MaKH);

            modelBuilder.Entity<HoSoKB>()
                .HasOne(hskb => hskb.ChiNhanh)
                .WithMany()
                .HasForeignKey(hskb => hskb.MaCN);
        }
    }

}
