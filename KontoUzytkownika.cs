using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [DataContract]
    class KontoUzytkownika : Konto, INaPozniej, IDodawanieRecenzji
    {
        DateTime dataUrodzenia;
        List<Usluga> listaUslug;
        List<Film> listaNaPozniej;
        List<Usluga> listaDoWyboru;
        static double abonament;

        [DataMember]
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        [DataMember]
        public List<Usluga> ListaUslug { get => listaUslug; set => listaUslug = value; }
        [DataMember]
        internal List<Film> ListaNaPozniej { get => listaNaPozniej; set => listaNaPozniej = value; }
        [DataMember]
        internal List<Usluga> ListaDoWyboru { get => listaDoWyboru; set => listaDoWyboru = value; }
        public static double Abonament { get => abonament; }

        static KontoUzytkownika()
        {
            abonament = 29.99;
        }

        public KontoUzytkownika() : base()
        {
            dataUrodzenia = DateTime.Now;
            ListaUslug = new List<Usluga>();
            ListaNaPozniej = new List<Film>();
            ListaDoWyboru = new List<Usluga>();
        }

        public KontoUzytkownika(string login, string haslo, string imie, string nazwisko, string dataUrodzenia, string email) : base(login, haslo, imie, nazwisko, email)
        {
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, System.Globalization.DateTimeStyles.None, out this.dataUrodzenia);
            ListaUslug = new List<Usluga>();
            ListaNaPozniej = new List<Film>();
            ListaDoWyboru = new List<Usluga>();
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

        public double ObliczOplate()
        {
            return Abonament + ListaUslug.Sum(u => u.Koszt);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Data urodzenia: {dataUrodzenia.ToShortDateString()}, Koszt: {ObliczOplate():C}";
        }

        public void DodajDoObejrzenia(Film f)
        {
            NaPozniej u = new NaPozniej();
            if (listaUslug.Contains(u))
            {
                NaPozniej.DodajDoObejrzenia(f, ListaNaPozniej);
            }
            else
            {
                throw new BrakUprawnienException("Błąd. Nie masz uprawnień.");
            }
        }

        public void UsunZListyDoObejrzenia(Film f)
        {
            NaPozniej u = new NaPozniej();
            if (listaUslug.Contains(u))
            {
                NaPozniej.Usun(f,ListaNaPozniej);
            }
            else
            {
                throw new BrakUprawnienException("Błąd. Nie masz uprawnień.");
            }
        }

        public void Wybor(Usluga usluga)
        {
            ListaUslug.Add(usluga);
        }

        public void DodajRecenzje(Recenzja rec, Film f)
        {
            DodawanieRecenzji r = new DodawanieRecenzji();
            if(ListaUslug.Contains(r))
            {
                DodawanieRecenzji.DodajRecenzje(rec, f);
            }
            else
            {
                throw new BrakUprawnienException("Błąd. Nie masz uprawnień.");
            }
        }

        public void EdytujRecenzje(Recenzja rec, Film f)
        {

            DodawanieRecenzji r = new DodawanieRecenzji();
            if (ListaUslug.Contains(r))
            {
                DodawanieRecenzji.EdytujRecenzje(rec, f);
            }
            else
            {
                throw new BrakUprawnienException("Błąd. Nie masz uprawnień.");
            }
        }

        public void UsunRecenzje(Recenzja rec, Film f)
        {

            DodawanieRecenzji r = new DodawanieRecenzji();
            if (ListaUslug.Contains(r))
            {
                DodawanieRecenzji.UsunRecenzje(rec,f);
            }
            else
            {
                throw new BrakUprawnienException("Błąd. Nie masz uprawnień.");
            }
        }
    }


}
