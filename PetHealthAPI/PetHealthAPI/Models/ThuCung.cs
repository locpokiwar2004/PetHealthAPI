namespace PetHealthAPI.Models
{
    public class ThuCung
    {
        public int MaTC { get; set; }
        public string TenTC { get; set; }
        public string Loai { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public int MaKH { get; set; }
        public KhachHang KhachHang { get; set; }
    }

}
