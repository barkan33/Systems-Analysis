﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class DivingClub
    {
        private string name;
        private string licenseNumber;
        private string contactPerson;
        private string address;
        private Country country;
        private string phone;
        private string email;
        private string website;
        private Signature signature;
        private List<DivingInstructor> instructors;
        private List<DiveSite> diveSites;
        private List<Dive> diveLog;


        public string GetName() { return name; }
        public string GetLicenseNumber() { return licenseNumber; }
        public string GetContactPerson() { return contactPerson; }
        public string GetAddress() { return address; }
        public Country GetCountry() { return country; }
        public string GetPhone() { return phone; }
        public string GetEmail() { return email; }
        public string GeWebsite() { return website; }
        public List<DivingInstructor> GetDivingInstructors() { return instructors; }
        public List<DiveSite> GetDiveSites() { return diveSites; }
        public List<Dive> GetDiveLogs() { return diveLog; }
        public Signature GetSignature() { return new Signature($"Signature: {name}", DateTime.Now); }

        private void SetName(string name) { this.name = name; }
        private void SetLicenseNumber(string licenseNumber) { this.licenseNumber = licenseNumber; }
        private void SetContactPerson(string contactPerson) { this.contactPerson = contactPerson; }
        private void SetAddress(string address) { this.address = address; }
        private void SetCountry(Country country) { this.country = country; }
        private void SetPhone(string phone) { this.phone = phone; }
        private void SetEmail(string email) { this.email = email; }
        private void SetWebsite(string website) { this.website = website; }
        private void AddDivingInstructors(DivingInstructor instructor) { instructors.Add(instructor); }
        private void AddDiveSites(DiveSite diveSite) { diveSites.Add(diveSite); }
        public void AddDive(Dive log) { diveLog.Add(log); }



        public DivingClub(string name, string licenseNumber, string contactPerson, string address, Country country, string phone, string email, string website)
        {
            SetName(name);
            SetLicenseNumber(licenseNumber);
            SetContactPerson(contactPerson);
            SetAddress(address);
            SetCountry(country);
            SetPhone(phone);
            SetEmail(email);
            SetWebsite(website);
            instructors = new List<DivingInstructor>();
            diveSites = new List<DiveSite>();
            diveLog = new List<Dive>();
        }



    }
}
