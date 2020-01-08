using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Recenzja : IComparable<Recenzja>, IEquatable<Recenzja>
    {
        string opis;
        KontoUzytkownika uzytkownik;
        DateTime czasDodania;

        public string Opis { get => opis; set => opis = value; }
        internal KontoUzytkownika Uzytkownik { get => uzytkownik; set => uzytkownik = value; }

        public Recenzja()
        {
            Opis = "";
            Uzytkownik = new KontoUzytkownika();
            czasDodania = DateTime.Now;
        }

        public Recenzja(string opis, KontoUzytkownika uzytkownik)
        {
            Opis = opis;
            Uzytkownik = uzytkownik;
            czasDodania = DateTime.Now;
        }

        public override string ToString()
        {
            return $" Użytkownik: {uzytkownik} RECENZJA: {opis}";
        }

        public int CompareTo(Recenzja rec)
        {
            if (!Equals(rec))
                return czasDodania.CompareTo(rec.czasDodania);
            else
                return 0;
        }

        public bool Equals(Recenzja rec)
        {
            if (czasDodania.Equals(rec.czasDodania) && Uzytkownik.Equals(rec.Uzytkownik))
                return true;
            else
                return false;
        }
    }
}
