using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [DataContract]
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

        public static void EdytujRecenzje(Recenzja rec, Film f) //GUI
        {
            Recenzja nowaRecenzja = rec.Clone() as Recenzja;

        }
    }
}