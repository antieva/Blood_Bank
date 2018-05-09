using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Tests
{
  [TestClass]
  public class PatientTest : IDisposable
  {
    public PatientTest()
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
    public void Equals_TrueForSameProperties_Patient()
    {
      //Arrange, Act
      Patient firstPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
      Patient secondPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");

      //Assert
      Assert.AreEqual(firstPatient, secondPatient);
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Patient.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void AddDonor_AddsDonorToPatient_DonorList()
    {
      //Arrange
      Patient testPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
      testPatient.Save();

      Donor testDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
      testDonor.Save();

      //Act
      testPatient.AddDonor(testDonor);

      List<Donor> result = testPatient.GetDonors();
      Console.WriteLine(result.Count);
      List<Donor> testList = new List<Donor>{testDonor};
      Console.WriteLine(testList.Count);

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_PatientID_True()
    {
        //Arrange
        Patient testPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
        testPatient.Save();

        //Act
        Patient result = Patient.Find(testPatient.GetId());

        //Assert
        Assert.AreEqual(testPatient, result);
    }

    [TestMethod]
    public void Delete_DeletesPatientAssociationsFromDatabase_PatientList()
    {
      //Arrange
      Donor testDonor = new Donor("Tim", "3333333", "08/11/93", "IIIRh+", "Healthy");
      testDonor.Save();

      Patient testPatient = new Patient("Tim", "9999999", "03/05/75", "IIRh-", "Ds");
      testPatient.Save();

      //Act
      testPatient.AddDonor(testDonor);
      testPatient.Delete();

      List<Patient> resultDonorPatients = testDonor.GetPatients();
      List<Patient> testDonorPatients = new List<Patient> {};

      //Assert
      CollectionAssert.AreEqual(testDonorPatients , resultDonorPatients);
    }
  }
}
