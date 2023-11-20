using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class FinancialRecordController : Controller
{
    private readonly ILogger<FinancialRecordController> _logger;
    private readonly IFinancialRecordService _financialRecordService;

    public FinancialRecordController(ILogger<FinancialRecordController> logger, IFinancialRecordService financialRecordService)
    {
        _logger = logger;
        _financialRecordService = financialRecordService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listFinancialRecord = _financialRecordService.ListFinancialRecords();
        ViewBag.ListFinancialRecords = listFinancialRecord;

        return View();
    }

    [HttpGet]
    [Route("Register")]
    [Route("Register/{id}")]
    public IActionResult Register(int? id)
    {
        if (id != null)
        {
            var register = _financialRecordService.ReturnRegister((int)id);
            return View(register);
        }
        return View();
    }

    [HttpPost]
    [Route("Register")]
    [Route("Register/{id}")]
    public IActionResult Register(FinancialRecordModel model)
    {
        _financialRecordService.Save(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        _financialRecordService.Delete(id);
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
