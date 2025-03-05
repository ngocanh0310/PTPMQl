using Microsoft.AspNetCore.Mvc;
using BT1BMI.Models; // 🔥 Thêm dòng này

public class BMIController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new BMIModel());
    }

    [HttpPost]
    public IActionResult Index(BMIModel model)
    {
        if (model.Weight > 0 && model.Height > 0)
        {
            double bmi = model.CalculateBMI();
            string category = model.GetCategory();

            ViewBag.Name = model.Name;
            ViewBag.BMI = bmi.ToString("0.00");
            ViewBag.Category = category;
        }
        else
        {
            ViewBag.BMI = "0.00";
            ViewBag.Category = "Không xác định";
        }

        return View(model);
    }
}
