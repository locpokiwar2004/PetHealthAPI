namespace PetHealthAPI.Models
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int MaCN { get; set; }
        public ChiNhanh ChiNhanh { get; set; }
    }

}
