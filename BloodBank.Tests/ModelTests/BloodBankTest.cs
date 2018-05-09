using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Tests
{
  [TestClass]
  public class BloodBankTest : IDisposable
  {
    public BloodBankTest()
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
    public void Equals_TrueForSameProperties_BloodBank()
    {
      //Arrange, Act
      BloodBank firstBloodBank = new BloodBank("Puget Sound", "Seattle", "7777777");
      BloodBank secondBloodBank = new BloodBank("Puget Sound", "Seattle", "7777777");

      //Assert
      Assert.AreEqual(firstBloodBank, secondBloodBank);
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = BloodBank.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Find_BloodBankID_True()
    {
        //Arrange
        BloodBank testBloodBank = new BloodBank("Puget Sound", "Seattle", "7777777");
        testBloodBank.Save();

        //Act
        Console.WriteLine(testBloodBank.GetId());
        BloodBank result = BloodBank.Find(testBloodBank.GetId());
        Console.WriteLine(result.GetId());

        //Assert
        Assert.AreEqual(testBloodBank, result);
    }
  }
}
