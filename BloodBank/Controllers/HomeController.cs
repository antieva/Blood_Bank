using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;

namespace BloodBankApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/home")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
