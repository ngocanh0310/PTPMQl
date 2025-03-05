namespace BT3HD.Models
{
    public class HoaDonModel
    {
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
    }
}
