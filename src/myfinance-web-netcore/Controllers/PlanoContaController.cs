﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers;

public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;

    public PlanoContaController(ILogger<PlanoContaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
