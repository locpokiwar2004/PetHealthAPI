namespace PetHealthAPI.Models
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        public KhachHang KhachHang { get; set; }

        public ICollection<CT_HoaDon> CTHoaDons { get; set; }
    }
}
