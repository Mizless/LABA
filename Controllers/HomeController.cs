using LABA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;

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
        CookieOptions option = new CookieOptions();
        option.Expires = DateTime.Now.AddMinutes(10);
        Response.Cookies.Append("OperationInfo", model.FirstOperand.ToString() + model.Operator.ToString() + model.SecondOperand.ToString() + " = " + model.Result.ToString(), option);
        // Возвращаем представление Index.cshtml
        return View("Index", model);
        
    }

    public IActionResult Equation()
    {
        if (Request.Cookies["OperationInfo"] != null)
        {
            string result = Request.Cookies["OperationInfo"];
            int index = result.LastIndexOfAny(new char[] { '=' });
            string resultInfo = result.Remove(index, result.Length - index) + " равно " + result.Substring(index + 1);
            ViewBag.Equat = resultInfo;
            Console.WriteLine(resultInfo);
        }
        return View();

    }
    public IActionResult Result()
    {
        return View("Result", ViewBag.Equat);
    }

}
