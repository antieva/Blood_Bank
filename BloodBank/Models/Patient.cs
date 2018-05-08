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
      private int _id;

      public Patient(string name, string contact, string dateOfBirth, string bloodType, string diagnosis, bool urgent = true, int id = 0)
      {
        _name = name;
        _contact = contact;
        _dateOfBirth = dateOfBirth;
        _bloodType = bloodType;
        _diagnosis = diagnosis;
        _urgent = urgent;
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

             return (idEquality && nameEquality && contactEquality && dateOfBirthEquality && bloodTypeEquality && diagnosisEquality && urgentEquality);
           }
        }
    }
}
