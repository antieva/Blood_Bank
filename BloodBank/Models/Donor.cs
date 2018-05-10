using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Models
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

    public override bool Equals(System.Object otherDonor)
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
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO donors (name, contact, dateOfBirth, bloodType, medicalRecord) VALUES (@name, @contact, @dateOfBirth, @bloodType, @medicalRecord);";

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

      MySqlParameter medicalRecord = new MySqlParameter();
      medicalRecord.ParameterName = "@medicalRecord";
      medicalRecord.Value = this._medicalRecord;
      cmd.Parameters.Add(medicalRecord);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddPatient(Patient newPatient)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO patients_donors (donor_id, patient_id) VALUES (@DonorId, @PatientId);";

        MySqlParameter donor_id = new MySqlParameter();
        donor_id.ParameterName = "@DonorId";
        donor_id.Value = _id;
        cmd.Parameters.Add(donor_id);

        MySqlParameter patient_id = new MySqlParameter();
        patient_id.ParameterName = "@PatientId";
        patient_id.Value = newPatient.GetId();
        cmd.Parameters.Add(patient_id);

        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public List<Patient> GetPatients()
    {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT patients.* FROM donors
           JOIN patients_donors ON (donors.id = patients_donors.donor_id)
           JOIN patients ON (patients_donors.patient_id = patients.id)
           WHERE donors.id = @DonorId;";

       MySqlParameter donorIdParameter = new MySqlParameter();
       donorIdParameter.ParameterName = "@DonorId";
       donorIdParameter.Value = _id;
       cmd.Parameters.Add(donorIdParameter);

       MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
       List<Patient> patients = new List<Patient>{};

       while(rdr.Read())
       {
         int patientId = rdr.GetInt32(0);
         string patientName = rdr.GetString(1);
         string patientContact = rdr.GetString(2);
         string patientDateOfBirth = rdr.GetString(3);
         string patientBloodType = rdr.GetString(4);
         string patientDs= rdr.GetString(5);
         bool patientUrgent = rdr.GetBoolean(6);
         bool patientNeedBlood = rdr.GetBoolean(7);

         Patient newPatient = new Patient(patientName, patientContact, patientDateOfBirth, patientBloodType, patientDs, patientUrgent, patientNeedBlood, patientId);
         patients.Add(newPatient);
       }
       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }
       return patients;
     }
     public void AddBloodBank(BloodBank newBloodBank)
     {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"INSERT INTO donors_bloodbanks (bloodBank_id, donor_id) VALUES (@BloodBankId, @DonorId);";

         MySqlParameter bloodBank_id = new MySqlParameter();
         bloodBank_id.ParameterName = "@BloodBankId";
         bloodBank_id.Value = newBloodBank.GetId();
         cmd.Parameters.Add(bloodBank_id);

         MySqlParameter donor_id = new MySqlParameter();
         donor_id.ParameterName = "@DonorId";
         donor_id.Value = _id;
         cmd.Parameters.Add(donor_id);

         cmd.ExecuteNonQuery();
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
     }

     public List<BloodBank> GetBloodBanks()
     {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT blood_banks.* FROM donors
            JOIN donors_bloodBanks ON (donors.id = donors_bloodBanks.donor_id)
            JOIN blood_banks ON (donors_bloodBanks.bloodBank_id = blood_banks.id)
            WHERE donors.id = @DonorId;";

        MySqlParameter donorIdParameter = new MySqlParameter();
        donorIdParameter.ParameterName = "@DonorId";
        donorIdParameter.Value = _id;
        cmd.Parameters.Add(donorIdParameter);

        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<BloodBank> bloodBanks = new List<BloodBank>{};

        while(rdr.Read())
        {
          int bloodBankId = rdr.GetInt32(0);
          string bloodBankName = rdr.GetString(1);
          string bloodBankAddress = rdr.GetString(3);
          string bloodBankContact = rdr.GetString(2);

          BloodBank newBloodBank = new BloodBank(bloodBankName, bloodBankAddress, bloodBankContact, bloodBankId);
          bloodBanks.Add(newBloodBank);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return bloodBanks;
    }
    public static List<Donor> GetAll()
    {
        List<Donor> allDonors = new List<Donor> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM donors;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int donorId = rdr.GetInt32(0);
          string donorName = rdr.GetString(1);
          string donorContact = rdr.GetString(2);
          string donorDateOfBirth = rdr.GetString(3);
          string donorBloodType = rdr.GetString(4);
          string donorMedicalRecord = rdr.GetString(5);

          Donor newDonor = new Donor(donorName, donorContact, donorDateOfBirth, donorBloodType, donorMedicalRecord, donorId);
          allDonors.Add(newDonor);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allDonors;
    }
    public static Donor Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM donors WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int donorId = 0;
      string donorName = "";
      string donorContact = "";
      string donorDateOfBirth = "";
      string donorBloodType = "";
      string donorMedicalRecord = "";

      while(rdr.Read())
      {
        donorId = rdr.GetInt32(0);
        donorName = rdr.GetString(1);
        donorContact = rdr.GetString(2);
        donorDateOfBirth = rdr.GetString(3);
        donorBloodType = rdr.GetString(4);
        donorMedicalRecord = rdr.GetString(5);
      }

      Donor newDonor = new Donor(donorName, donorContact, donorDateOfBirth, donorBloodType, donorMedicalRecord, donorId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return newDonor;
    }
    public static List<Donor> Find(string bloodType)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM donors WHERE bloodType = (@searchBloodType);";

      MySqlParameter searchBloodType = new MySqlParameter();
      searchBloodType.ParameterName = "@searchBloodType";
      searchBloodType.Value = bloodType;
      cmd.Parameters.Add(searchBloodType);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int donorId = 0;
      string donorName = "";
      string donorContact = "";
      string donorDateOfBirth = "";
      string donorBloodType = "";
      string donorMedicalRecord = "";
      List<Donor> donors = new List<Donor>{};

      while(rdr.Read())
      {
        donorId = rdr.GetInt32(0);
        donorName = rdr.GetString(1);
        donorContact = rdr.GetString(2);
        donorDateOfBirth = rdr.GetString(3);
        donorBloodType = rdr.GetString(4);
        donorMedicalRecord = rdr.GetString(5);

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
    public void Delete()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM donors WHERE id = @DonorId; DELETE FROM patients_donors WHERE donor_id = @DonorId;";

        MySqlParameter donorIdParameter = new MySqlParameter();
        donorIdParameter.ParameterName = "@DonorId";
        donorIdParameter.Value = this.GetId();
        cmd.Parameters.Add(donorIdParameter);

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
      cmd.CommandText = @"DELETE FROM donors;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
