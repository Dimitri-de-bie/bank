using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class klantenclass
    {
        bankrekeningDataContext db = new bankrekeningDataContext();

        public List<Customer> giveAllCustomers()
        {
            return db.Customers.ToList();
        }
        public bool klantopslaan(string sBsn, string sVoorletters, string sVoornaam, string sAchternaam, string sAdres,
            string sPostcode, string sWoonplaats, string sTelefoonnummer, string sEmail)
        {
            bool bResult = false;
            if (sBsn != "" && sVoorletters != "" && sVoornaam != "" && sAchternaam != "" && sAdres != "" && sPostcode != "" && sWoonplaats != null && sTelefoonnummer != "" && sEmail != "")
            {
                Customer deCustomer = new Customer();
                deCustomer.BSN = sBsn;
                deCustomer.voorletters = sVoorletters;
                deCustomer.voornaam = sVoornaam;
                deCustomer.achternaam = sAchternaam;
                deCustomer.adres = sAdres;
                deCustomer.postcode = sPostcode;
                deCustomer.woonplaats = sWoonplaats;
                deCustomer.telefoonnummer = sTelefoonnummer;
                deCustomer.email = sEmail;

                db.Customers.InsertOnSubmit(deCustomer);
                db.SubmitChanges();
                bResult = true;
            }

            return bResult;
        }
        public void verwijderklant(Customer deklant)
        {
            db.Customers.DeleteOnSubmit(deklant);
            db.SubmitChanges();
        }
        public void EditKlant(string BSN, string Voorletters, string Voornaam, string Achternaam, string Adres, string Postcode, string Woonplaats, string Telefoonnummer, string Email)
        {
            Customer c = (from Klant in db.Customers where Klant.BSN == BSN select Klant).Single();
             c.voorletters = Voorletters;
             c.voornaam = Voornaam;
             c.achternaam = Achternaam;
             c.adres = Adres;
             c.postcode = Postcode;
             c.woonplaats = Woonplaats;
             c.telefoonnummer = Telefoonnummer;
             c.email = Email;
        }
       
        public List<Customer> AllKlanten()
        {
            return db.Customers.ToList();
        }
        public void Klantenverwijderen(string BSN)
        {
            Customer c = (from Klant in db.Customers where Klant.BSN == BSN select Klant).Single();
            db.Customers.DeleteOnSubmit(c);
        }
    }
}
