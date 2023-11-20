using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ILogger<TransactionController> _logger;
    private readonly ITransactionService _transactionService;
    private readonly IFinancialRecordService _financialRecordService;

    public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService, IFinancialRecordService financialRecordService)
    {
        _logger = logger;
        _transactionService = transactionService;
        _financialRecordService = financialRecordService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listTransaction = _transactionService.ListTransactions();
        ViewBag.ListTransactions = listTransaction;

        return View();
    }

    [HttpGet]
    [Route("Register")]
    [Route("Register/{id}")]
    public IActionResult Register(int? id)
    {
        var transactionModel = new TransactionModel();

        if (id != null)
        {
            transactionModel = _transactionService.ReturnRegister((int)id);
        }

        var listFinancialRecord = _financialRecordService.ListFinancialRecords();
        var financialRecordSelectItems = new SelectList(listFinancialRecord, "Id", "Description");
        transactionModel.FinancialRecords = financialRecordSelectItems;

        return View(transactionModel);
    }

    [HttpPost]
    [Route("Register")]
    [Route("Register/{id}")]
    public IActionResult Register(TransactionModel model)
    {
        _transactionService.Save(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        _transactionService.Delete(id);
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
