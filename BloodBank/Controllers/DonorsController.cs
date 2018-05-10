using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;

namespace BloodBankApp.Controllers
{
  public class DonorsController : Controller
  {
    [HttpGet("/donors/new")]
    public ActionResult DonorForm()
    {
      return View();
    }

    [HttpGet("/patient/{id}/donors/match")]
    public ActionResult Match(int id)
    {
      Patient newPatient = Patient.Find(id);
      List<Donor> matches = Donor.Find(newPatient.GetBloodType());
      return View(matches);
    }

    [HttpGet("/donors/list")]
    public ActionResult DonorList()
    {
      List<Donor> allDonors = Donor.GetAll();
      return View (allDonors);
    }

    [HttpGet("/donor/{id}/details")]
    public ActionResult DonorDetails(int id)
    {
      Donor newDonor = Donor.Find(id);
      return View(newDonor);
    }
  }
}
