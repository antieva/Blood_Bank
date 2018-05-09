using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Tests
{
  [TestClass]
  public class DonorTest : IDisposable
  {
    public DonorTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blood_bank_test;";
    }

    public void Dispose()
    {
      Patient.DeleteAll();
      Donor.DeleteAll();
      BloodBank.DeleteAll();
    }

    [TestMethod]
    public void Equals_TrueForSameProperties_Donor()
    {
      //Arrange, Act
      Donor firstDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
      Donor secondDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");

      //Assert
      Assert.AreEqual(firstDonor, secondDonor);
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Donor.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }
  }
}
