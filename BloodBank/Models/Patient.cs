using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBank.Models;
using System;

namespace BloodBank.Models
{
  public class Patient
    {
      private string _name;
      private string _contact;
      private string _dateOfBirth;
      private string _bloodType;
      private string _diagnosis;
      private bool _urgent;
      private bool _needBlood;
      private int _id;

      public Patient(string name, string contact, string dateOfBirth, string bloodType, string diagnosis, bool urgent = true, bool needBlood = true, int id = 0)
      {
        _name = name;
        _contact = contact;
        _dateOfBirth = dateOfBirth;
        _bloodType = bloodType;
        _diagnosis = diagnosis;
        _urgent = urgent;
        _needBlood = needBlood;
        _id = id;
      }

      public override bool Equals(System.Object otherItem)
        {
          if (!(otherPatient is Patient))
          {
            return false;
          }
          else
          {
             Patient newPatient = (Patient) otherPatient;
             bool idEquality = this.GetId() == newPatient.GetId();
             bool nameEquality = this.GetName() == newPatient.GetName();
             bool contactEquality = this.GetContact() == newPatient.GetContact();
             bool dateOfBirthEquality = this.GetDateOfBirth() == newPatient.GetDateOfBirth();
             bool bloodTypeEquality = this.GetBloodType() == newPatient.GetBloodType();
             bool diagnosisEquality = this.GetDiagnosis() == newPatient.GetDiagnosis();
             bool urgentEquality = this.GetUrgent() == newPatient.GetUrgent();
             bool needBloodEquality = this.GetNeedBlood() == newPatient.GetNeedBlood();

             return (idEquality && nameEquality && contactEquality && dateOfBirthEquality && bloodTypeEquality && diagnosisEquality && urgentEquality && needBloodEquality);
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
      public string GetDiagnosis()
      {
        return _diagnosis;
      }
      public bool GetUrgent()
      {
        return _urgent;
      }
      public bool GetNeedBlood()
      {
        return _needBlood;
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
      public void SetDiagnosis(string newDiagnosis)
      {
        _diagnosis = newDiagnosis;
      }
      public void SetUrgent(bool maybeUrgent)
      {
        _urgent = newUrgent;
      }
      public void SetNeedBlood(bool maybeNeedBlood)
      {
        _needBlood = newNeedBlood;
      }



    }
}
