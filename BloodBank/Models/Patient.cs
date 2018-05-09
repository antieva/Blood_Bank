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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO patients (name, contact, dateOfBirth, bloodType, diagnosis, urgent, needBlood) VALUES (@name, @contact, @dateOfBirth, @bloodType, @diagnosis, @urgent, @needBlood);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;contact
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

      Patient newPatient = new Patient(patientName, patientContact, patientDateOfBirth, patientBloodType, patientDiagnosis, patient, patientUrgent, patientNeedBlood, patientId);
      
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return newPatient;
    }



  }
}
