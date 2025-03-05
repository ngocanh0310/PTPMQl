namespace BT2DMH.Models
{
    public class DiemModel
    {
        public string MonHoc { get; set; } = string.Empty;
        public double DiemA { get; set; }
        public double DiemB { get; set; }
        public double DiemC { get; set; }
        public double DiemTongKet { get; set; }
        public string KetLuan { get; set; } = string.Empty;

        public void TinhDiem()
        {
            DiemTongKet = (DiemA * 0.6) + (DiemB * 0.3) + (DiemC * 0.1);

            if (DiemTongKet >= 8.5)
                KetLuan = "Giỏi";
            else if (DiemTongKet >= 7)
                KetLuan = "Khá";
            else if (DiemTongKet >= 5)
                KetLuan = "Trung bình";
            else
                KetLuan = "Yếu";
        }
    }
}

