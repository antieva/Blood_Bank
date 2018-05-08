using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BloodBank.Models;
using System;

namespace BloodBank.Models
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

      public override bool Equals(System.Object otherItem)
        {
          if (!(otherBloodBank is BloodBank))
          {
            return false;
          }
          else
          {
             BloodBank newBloodBank = (BloodBank) otherDonor;
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
    }
}
