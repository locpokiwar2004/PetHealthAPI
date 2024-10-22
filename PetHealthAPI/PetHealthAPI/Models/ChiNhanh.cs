namespace PetHealthAPI.Models
{
    public class ChiNhanh
    {
        public int MaCN { get; set; }
        public string TenCN { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
        public ICollection<HoSoKB> HoSoKBs { get; set; }
    }

}
