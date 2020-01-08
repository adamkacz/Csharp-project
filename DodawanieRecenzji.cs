using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class DodawanieRecenzji : Usluga
    {
        internal DodawanieRecenzji() : base("Dodawanie recenzji", 10.0)
        {

        }


        public static void DodajRecenzje(Recenzja rec, Film f)
        {
            f.ListaRecenzji.Add(rec);
            f.ListaRecenzji.Sort();
        }

        public static void UsunRecenzje(Recenzja rec, Film f)
        {
            f.ListaRecenzji.Remove(rec);
        }
    }
}
