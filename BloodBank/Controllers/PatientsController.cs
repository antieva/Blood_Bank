using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;

namespace BloodBankApp.Controllers
{
  public class PatientController : Controller
  {
    [HttpGet("/patients/list")]
    public ActionResult PatientList()
    {
      List<Patient> patients = Patient.GetAll();
      return View(patients);
    }

    [HttpGet("/patients/new")]
    public ActionResult PatientForm()
    {
      return View();
    }

    [HttpPost("/patients/new")]
    public ActionResult Create()
    {
      Patient newPatient = new Patient(Request.Form["patientName"],Request.Form["patientContact"],Request.Form["patientDateOfBirth"],Request.Form["patientBloodType"],Request.Form["patientDiagnosis"],Convert.ToBoolean(Request.Form["patientUrgent"]),Convert.ToBoolean(Request.Form["patientNeedBlood"]));
      newPatient.Save();
      List<Patient> patients = Patient.GetAll();
      return View("PatientList", patients);
    }

    [HttpGet("/{id}/details")]
    public ActionResult PatientDetails(int id)
    {
      Patient newPatient = Patient.Find(id);
      return View(newPatient);
    }

    [HttpPost("/patients/search")]
    public ActionResult Search()
    {
      List<Patient> searchedPatients = Patient.Find(Request.Form["searchPatients"]);
      return View("PatientList", searchedPatients);
    }
  }
}
