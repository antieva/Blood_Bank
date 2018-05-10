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

    [TestMethod]
    public void AddPatient_AddsPatientToDonor_PatientList()
    {
      //Arrange
      Donor testDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
      testDonor.Save();

      Patient testPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
      testPatient.Save();

      //Act
      testDonor.AddPatient(testPatient);

      List<Patient> result = testDonor.GetPatients();
      Console.WriteLine(result.Count);
      List<Patient> testList = new List<Patient>{testPatient};
      Console.WriteLine(testList.Count);

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_DonorID_True()
    {
        //Arrange
        Donor testDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
        testDonor.Save();

        //Act
        Donor result = Donor.Find(testDonor.GetId());

        //Assert
        Assert.AreEqual(testDonor, result);
    }

    [TestMethod]
    public void Find_DonorBloodType_True()
    {
        //Arrange
        Donor firstDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
        firstDonor.Save();
        Donor secondDonor = new Donor("Mary", "555555", "10/22/94", "IIIRh+", "Healthy");
        secondDonor.Save();

        //Act
        List<Donor> testList = new List<Donor> {};
        testList.Add(firstDonor);
        testList.Add(secondDonor);
        List<Donor> result = Donor.Find("IIIRh+");

        //Assert
        CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesDonorAssociationsFromDatabase_DonorList()
    {
      //Arrange
      Patient testPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
      testPatient.Save();

      Donor testDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
      testDonor.Save();

      //Act
      testDonor.AddPatient(testPatient);
      testDonor.Delete();

      List<Donor> resultDonorPatients = testPatient.GetDonors();
      List<Donor> testDonorPatients = new List<Donor> {};

      //Assert
      CollectionAssert.AreEqual(testDonorPatients , resultDonorPatients);
    }

  }
}
