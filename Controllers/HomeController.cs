using LABA.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new CalculatorViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Calculate(CalculatorViewModel model, string submitButton)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }
        if (submitButton == "Clear")
        {
            model.Result = 0;
            return View("Index", model);
        }

        switch (model.Operator)
        {
            case "+":
                model.Result = model.FirstOperand + model.SecondOperand;
                break;
            case "-":
                model.Result = model.FirstOperand - model.SecondOperand;
                break;
            case "*":
                model.Result = model.FirstOperand * model.SecondOperand;
                break;
            case "/":
                model.Result = model.FirstOperand / model.SecondOperand;
                break;

        }

        ViewBag.TargetResult = 42.0m;

        return View("Index", model);
    }

}
