namespace PetHealthAPI.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public ICollection<ThuCung> ThuCungs { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }

}
