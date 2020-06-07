using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Typesclass
    {
        bankrekeningDataContext db = new bankrekeningDataContext();

        public void nieuwetypes(string Naam, double Rente, double MaxOpname)
        {
            type Ty = new type();
            Ty.Naam = Naam;
            Ty.Rente = Rente;
            Ty.MaxOpname = MaxOpname;

            db.types.InsertOnSubmit(Ty);
        }
        public List<type> AllTypen()
        {
            return db.types.ToList();
        }
       
        public void EditType(string Naam, double Rente, double MaxOpname)
        {
            type T = (from Typen in db.types where Typen.Naam == Naam select Typen).Single();
            T.Rente = Rente;
            T.MaxOpname = MaxOpname;
        }
        public void DeleteType(string Naam)
        {
            type T = (from Type in db.types where Type.Naam == Naam select Type).Single();
            db.types.DeleteOnSubmit(T);
        }

    }
}
