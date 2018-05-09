using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;
using System;

namespace BloodBankApp.Models
{
  public class BloodBank
    {
      private string _name;
      private string _address;
      private string _contact;
      private int _id;

      public BloodBank(string name, string address, string contact, int id = 0)
      {
        _name = name;
        _address = address;
        _contact = contact;
        _id = id;
      }

      public override bool Equals(System.Object otherBloodBank)
        {
          if (!(otherBloodBank is BloodBank))
          {
            return false;
          }
          else
          {
             BloodBank newBloodBank = (BloodBank) otherBloodBank;
             bool idEquality = this.GetId() == newBloodBank.GetId();
             bool nameEquality = this.GetName() == newBloodBank.GetName();
             bool contactEquality = this.GetContact() == newBloodBank.GetContact();
             bool addressEquality = this.GetAddress() == newBloodBank.GetAddress();


             return (idEquality && nameEquality && contactEquality && addressEquality);
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
      public string GetAddress()
      {
        return _address;
      }
      public string GetContact()
      {
        return _contact;
      }
      public int GetId()
      {
        return _id;
      }
      public void SetName(string newName)
      {
        _name = newName;
      }
      public void SetAddress(string newAddress)
      {
        _address = newAddress;
      }
      public void SetContact(string newContact)
      {
        _contact = newContact;
      }

      public void Save()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO blood_banks (name, address, contact) VALUES (@name, @address, @contact);";

          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@name";
          name.Value = this._name;
          cmd.Parameters.Add(name);

          MySqlParameter address = new MySqlParameter();
          address.ParameterName = "@address";
          address.Value = this._address;
          cmd.Parameters.Add(address);

          MySqlParameter contact = new MySqlParameter();
          contact.ParameterName = "@contact";
          contact.Value = this._contact;
          cmd.Parameters.Add(contact);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
        }
      public static List<BloodBank> GetAll()
      {
          List<BloodBank> allBloodBanks = new List<BloodBank> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM blood_banks;";
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int bloodbankId = rdr.GetInt32(0);
            string bloodbankName = rdr.GetString(1);
            string bloodbankAddress = rdr.GetString(2);
            string bloodbankContact = rdr.GetString(3);

            BloodBank newBloodBank = new BloodBank(bloodbankName, bloodbankAddress, bloodbankContact, bloodbankId);
            allBloodBanks.Add(newBloodBank);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allBloodBanks;
      }

      public static BloodBank Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM blood_banks WHERE id = (@searchId);";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int bloodbankId = 0;
        string bloodbankName = "";
        string bloodbankContact = "";
        string bloodbankAddress = "";

        while(rdr.Read())
        {
          bloodbankId = rdr.GetInt32(0);
          bloodbankName = rdr.GetString(1);
          bloodbankAddress = rdr.GetString(2);
          bloodbankContact = rdr.GetString(3);
        }

        BloodBank newBloodBank = new BloodBank(bloodbankName, bloodbankAddress, bloodbankContact, bloodbankId);

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }

        return newBloodBank;
      }
      
      public static void DeleteAll()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM blood_banks;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }
    }
}
