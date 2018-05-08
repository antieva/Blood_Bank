using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBank.Models;
using System;

namespace BloodBank.Models
{
  public class Donor
    {
      private string _name;
      private string _contact;
      private string _dateOfBirth;
      private string _bloodType;
      private string _medicalRecord;
      private int _id;

      public Donor(string name, string contact, string dateOfBirth, string bloodType, string medicalRecord, int id = 0)
      {
        _name = name;
        _contact = contact;
        _dateOfBirth = dateOfBirth;
        _bloodType = bloodType;
        _medicalRecord = medicalRecord;
        _id = id;
      }

      public override bool Equals(System.Object otherItem)
        {
          if (!(otherDonor is Donor))
          {
            return false;
          }
          else
          {
             Donor newDonor = (Donor) otherDonor;
             bool idEquality = this.GetId() == newDonor.GetId();
             bool nameEquality = this.GetName() == newDonor.GetName();
             bool contactEquality = this.GetContact() == newDonor.GetContact();
             bool dateOfBirthEquality = this.GetDateOfBirth() == newDonor.GetDateOfBirth();
             bool bloodTypeEquality = this.GetBloodType() == newDonor.GetBloodType();
             bool medicalRecordEquality = this.GetMedicalRecord() == newDonor.GetMedicalRecord();

             return (idEquality && nameEquality && contactEquality && dateOfBirthEquality && bloodTypeEquality && medicalRecordEquality);
           }
        }
      public override int GetHashCode()
      {
           return this.GetName().GetHashCode();
      }
      public string GetName()
      {
        return _name;
      }
      public string GetContact()
      {
        return _contact;
      }
      public string GetDateOfBirth()
      {
        return _dateOfBirth;
      }
      public string GetBloodType()
      {
        return _bloodType;
      }
      public string GetMedicalRecord()
      {
        return _medicalRecord;
      }
      public int GetId()
      {
        return _id;
      }
      public void SetName(string newName)
      {
        _name = newName;
      }
      public void SetContact(string newContact)
      {
        _contact = newContact;
      }
      public void SetDateOfBirth(string newDateOfBirth)
      {
        _dateOfBirth = newDateOfBirth;
      }
      public void SetBloodType(string newBloodType)
      {
        _bloodType = newBloodType;
      }
      public void SetMedicalRecord(string newMedicalRecord)
      {
        _medicalRecord = newMedicalRecord;
      }
    }
}
