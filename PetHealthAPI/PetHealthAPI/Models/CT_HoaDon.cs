namespace PetHealthAPI.Models
{
    public class CT_HoaDon
    {
        public int ID_CTHD { get; set; }
        public int MaHD { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal TongTien { get; set; }

        public HoaDon HoaDon { get; set; }
        public Thuoc Thuoc { get; set; }
    }

}
