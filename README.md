# _Bloodbank_

#### _Bloodbank, 05/10/18_

#### By _**Eva Antipina**_

## Description

_Bloodbank is a web site created to coordinate work of bloodbanks._

* _As a Bloodbank employee, you can add/delete donors and patients to the database._
* _As a Bloodbank employee, you can list all donors or patients added to the database._ 
* _As a Bloodbank employee, you can see every donors/patients ditails._ 
* _As a Bloodbank employee, you can find donors by blood type or name._
* _As a Bloodbank employee, you can find patients by name or ergancy of blood transfusion._
* _As a Bloodbank employee, you can find all matching donors for particular patient._
* _As a Bloodbank employee, you can update particular donor/patient details._ 


## Setup/Installation Requirements

* _Clone or download the repository._
* _Unzip the files into a single directory._
* _Open the Windows PowerShell and move to the directory_
* _Run "dotnet restore" command in the PowerShell._
* _Run "dotnet build" command in the PowerShell._
* _Run "dotnet run" command in the PowerShell._
* _Open a web browser of choice._
* _Enter "localhost:5000/home" into the address bar._

# Add Database to the Project

* _> CREATE DATABASE bloodbank;_
* _> USE blaoodbank;_
* _> CREATE TABLE blood_banks (id serial PRIMARY KEY, name VARCHAR(255), address VARCHAR(255), contact VARCHAR(255));_
* _> CREATE TABLE donors (id serial PRIMARY KEY, name VARCHAR(255), contact VARCHAR(255), dateOfBirth VARCHAR(255), bloodType VARCHAR(255), medicalRecord VARCHAR(255));_
* _> CREATE TABLE patients (id serial PRIMARY KEY, name VARCHAR(255), contact VARCHAR(255), dateOfBirth VARCHAR(255), bloodType VARCHAR(255), ds VARCHAR(255), urgent TINYINT(1), needblood TINYINT(1);_
* _> CREATE TABLE patients_donors (id serial PRIMARY KEY, donor_id VARCHAR(255), patient_id VARCHAR(255));_
* _> CREATE TABLE donors_bloodbanks (id serial PRIMARY KEY, bloodBank_id VARCHAR(255), donor_id VARCHAR(255));_

## Known Bugs

_Project not finished._

## Support and contact details

_If You run into any issues or have questions, ideas, concerns or would like to make a contribution to the code, please contact me via email: eva.antipina@gmail.com_

## Technologies Used

_.Net, MySQL, MAMP, C#, HTML, Bootstrap_

### License

*Not licensed.*

Copyright (c) 2018 **_Eva Antipina_**
