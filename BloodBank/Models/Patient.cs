using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Models
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

      public override bool Equals(System.Object otherPatient)
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
      public void SetUrgent(bool newUrgent)
      {
        _urgent = newUrgent;
      }
      public void SetNeedBlood(bool newNeedBlood)
      {
        _needBlood = newNeedBlood;
      }
      public void AddDonor(Donor newDonor)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO patients_donors (donor_id, patient_id) VALUES (@DonorId, @PatientId);";

          MySqlParameter donor_id = new MySqlParameter();
          donor_id.ParameterName = "@DonorId";
          donor_id.Value = newDonor.GetId();
          cmd.Parameters.Add(donor_id);

          MySqlParameter patient_id = new MySqlParameter();
          patient_id.ParameterName = "@PatientId";
          patient_id.Value = _id;
          cmd.Parameters.Add(patient_id);

          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }
      public List<Donor> GetDonors()
      {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT donors.* FROM patients
             JOIN patients_donors ON (patients.id = patients_donors.patient_id)
             JOIN donors ON (patients_donors.donor_id = donors.id)
             WHERE patients.id = @PatientId;";

         MySqlParameter patientIdParameter = new MySqlParameter();
         patientIdParameter.ParameterName = "@PatientId";
         patientIdParameter.Value = _id;
         cmd.Parameters.Add(patientIdParameter);

         MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
         List<Donor> donors = new List<Donor>{};

         while(rdr.Read())
         {
           int donorId = rdr.GetInt32(0);
           string donorName = rdr.GetString(1);
           string donorContact = rdr.GetString(2);
           string donorDateOfBirth = rdr.GetString(3);
           string donorBloodType = rdr.GetString(4);
           string donorMedicalRecord = rdr.GetString(5);

           Donor newDonor = new Donor(donorName, donorContact, donorDateOfBirth, donorBloodType, donorMedicalRecord, donorId);
           donors.Add(newDonor);
         }
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
         return donors;
     }
      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO patients (name, contact, dateOfBirth, bloodType, ds, urgent, needBlood) VALUES (@name, @contact, @dateOfBirth, @bloodType, @diagnosis, @urgent, @needBlood);";

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);

        MySqlParameter contact = new MySqlParameter();
        contact.ParameterName = "@contact";
        contact.Value = this._contact;
        cmd.Parameters.Add(contact);

        MySqlParameter dateOfBirth = new MySqlParameter();
        dateOfBirth.ParameterName = "@dateOfBirth";
        dateOfBirth.Value = this._dateOfBirth;
        cmd.Parameters.Add(dateOfBirth);

        MySqlParameter bloodType = new MySqlParameter();
        bloodType.ParameterName = "@bloodType";
        bloodType.Value = this._bloodType;
        cmd.Parameters.Add(bloodType);

        MySqlParameter diagnosis = new MySqlParameter();
        diagnosis.ParameterName = "@diagnosis";
        diagnosis.Value = this._diagnosis;
        cmd.Parameters.Add(diagnosis);

        MySqlParameter urgent = new MySqlParameter();
        urgent.ParameterName = "@urgent";
        urgent.Value = this._urgent;
        cmd.Parameters.Add(urgent);

        MySqlParameter needBlood = new MySqlParameter();
        needBlood.ParameterName = "@needBlood";
        needBlood.Value = this._needBlood;
        cmd.Parameters.Add(needBlood);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }
      public static List<Patient> GetAll()
      {
          List<Patient> allPatients = new List<Patient> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM patients;";
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int patientId = rdr.GetInt32(0);
            string patientName = rdr.GetString(1);
            string patientContact = rdr.GetString(2);
            string patientDateOfBirth = rdr.GetString(3);
            string patientBloodType = rdr.GetString(4);
            string patientDiagnosis = rdr.GetString(5);
            bool patientUrgent = rdr.GetBoolean(6);
            bool patientNeedBlood = rdr.GetBoolean(7);

            Patient newPatient = new Patient(patientName, patientContact, patientDateOfBirth, patientBloodType, patientDiagnosis, patientUrgent, patientNeedBlood, patientId);
            allPatients.Add(newPatient);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allPatients;
      }
      public static Patient Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM patients WHERE id = (@searchId);";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int patientId = 0;
        string patientName = "";
        string patientContact = "";
        string patientDateOfBirth = "";
        string patientBloodType = "";
        string patientDiagnosis = "";
        bool patientUrgent = true;
        bool patientNeedBlood = true;

        while(rdr.Read())
        {
          patientId = rdr.GetInt32(0);
          patientName = rdr.GetString(1);
          patientContact = rdr.GetString(2);
          patientDateOfBirth = rdr.GetString(3);
          patientBloodType = rdr.GetString(4);
          patientDiagnosis = rdr.GetString(5);
          patientUrgent = rdr.GetBoolean(6);
          patientNeedBlood = rdr.GetBoolean(7);
        }

        Patient newPatient = new Patient(patientName, patientContact, patientDateOfBirth, patientBloodType, patientDiagnosis, patientUrgent, patientNeedBlood, patientId);

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }

        return newPatient;
      }
      public void Delete()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM patients WHERE id = @PatientId; DELETE FROM patients_donors WHERE patient_id = @PatientId;";

          MySqlParameter patientIdParameter = new MySqlParameter();
          patientIdParameter.ParameterName = "@PatientId";
          patientIdParameter.Value = this.GetId();
          cmd.Parameters.Add(patientIdParameter);

          cmd.ExecuteNonQuery();
          if (conn != null)
          {
              conn.Close();
          }
      }
      public static void DeleteAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM patients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }
  }
}
