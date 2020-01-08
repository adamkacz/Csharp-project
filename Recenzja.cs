using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Recenzja
    {
        string opis;
        KontoUzytkownika uzytkownik;

        public string Opis { get => opis; set => opis = value; }
        internal KontoUzytkownika Uzytkownik { get => uzytkownik; set => uzytkownik = value; }

        public Recenzja()
        {
            Opis = "";
            Uzytkownik = new KontoUzytkownika();

        }

        public Recenzja(string opis, KontoUzytkownika uzytkownik)
        {
            Opis = opis;
            Uzytkownik = uzytkownik;
        }

        public override string ToString()
        {
            return $" Użytkownik: {uzytkownik} RECENZJA: {opis}";
        }
    }
}
