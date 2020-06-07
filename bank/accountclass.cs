using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class accountclass
    {
        bankrekeningDataContext db = new bankrekeningDataContext();
        
       
        public List<Account> alleaccounts()
        {
            return db.Accounts.ToList();
        }
        public void nieuwerekening(string IBAN, string BSN, double Saldo, type Type, DateTime startdatum, DateTime stopdatum)
        {
            Account acc = new Account();
            acc.IBAN = IBAN;
            acc.Rekeningeigenaar = BSN;
            acc.Saldo = Saldo;
            acc.Type = Type.Naam;
            acc.Startdatum = startdatum;
            acc.afsluitdaten = stopdatum;

            db.Accounts.InsertOnSubmit(acc);
        }
       
        public void rekeningveranderen(string IBAN, string BSN, double Saldo, type Type, DateTime startdatum, DateTime stopdatum)
        {
            Account a  = (from account in db.Accounts where account.IBAN == IBAN select account).Single();
            a.Rekeningeigenaar = BSN;
            a.Saldo = Saldo;
            a.Type = Type.Naam;
        }
        public void rekeningverwijderen(string IBAN)
        {
            Account acc = (from account in db.Accounts where account.IBAN == IBAN select account).Single();
            db.Accounts.DeleteOnSubmit(acc);
        }
    }
}
