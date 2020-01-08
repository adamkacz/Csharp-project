using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [DataContract]
    class NaPozniej : Usluga
    {
        internal NaPozniej() : base("Na później", 5.5)
        {

        }

        public static void DodajDoObejrzenia(Film film, List<Film> lista)
        {
            lista.Add(film);
            lista.Sort();
        }

        public static void Usun(Film f, List<Film> lista)
        {
            lista.Remove(f);
        }
    }
}