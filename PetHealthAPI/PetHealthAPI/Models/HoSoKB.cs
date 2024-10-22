namespace PetHealthAPI.Models
{
    public class HoSoKB
    {
        public int MaHS { get; set; }
        public int MaTC { get; set; }
        public int MaKH { get; set; }
        public int MaCN { get; set; }
        public DateTime NgayKham { get; set; }
        public string DichVu { get; set; }
        public string ChuanDoan { get; set; }
        public string DieuTri { get; set; }

        public ThuCung ThuCung { get; set; }
        public KhachHang KhachHang { get; set; }
        public ChiNhanh ChiNhanh { get; set; }
    }

}
