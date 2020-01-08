using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class KontoUzytkownika : Konto
    {
        DateTime dataUrodzenia;
        List<Usluga> listaUslug;

        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public List<Usluga> ListaUslug { get => listaUslug; set => listaUslug = value; }

        public KontoUzytkownika() : base()
        {
            dataUrodzenia = DateTime.Now;
            ListaUslug = new List<Usluga>();
        }

        public KontoUzytkownika(string login, string haslo, string imie, string nazwisko, string dataUrodzenia, string email) : base(login, haslo, imie, nazwisko, email)
        {
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataUrodzenia);
            ListaUslug = new List<Usluga>();
        }

        //public int Wiek()
        //{
        //    return DateTime.Now.Year - DataUrodzenia.Year;
        //}

        public void DodajUsluge(Usluga usluga)
        {
            ListaUslug.Add(usluga);
        }

        public void Rezygnuj(Usluga usluga)
        {
            ListaUslug.Remove(usluga);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Data urodzenia: {dataUrodzenia.ToShortDateString()}";
        }
    }

    //-------------------------------------------------
    //DO LISTY KONT 
    //foreach(Uzytkownik u in Listakont)
    //{
    //    if (haslo == u.Haslo || login == u.Login)
    //        {
    //            return true;
    //        }
    //    else
    //        {
    //            return false;
    //        }

    //}
   
}
