namespace PetHealthAPI.Models
{
    public class Thuoc
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public ICollection<CT_HoaDon> CTHoaDons { get; set; }
    }

}
