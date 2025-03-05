namespace BT1BMI.Models
{
    public class BMIModel
    {
        public string? Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public double CalculateBMI()
        {
            return (Height > 0) ? Weight / (Height * Height) : 0;
        }

        public string GetCategory()
        {
            double bmi = CalculateBMI();
            if (bmi < 18.5) return "Gầy";
            if (bmi < 24.9) return "Bình thường";
            if (bmi < 29.9) return "Thừa cân";
            return "Béo phì";
        }
    }
}
