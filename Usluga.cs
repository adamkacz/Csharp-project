using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    abstract class Usluga : IEquatable<Usluga>
    {
        double koszt;
        string nazwa;

        public double Koszt { get => koszt; set => koszt = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }

        public Usluga()
        {
            Koszt = 0;
            Nazwa = "";
        }

        public Usluga(string nazwa, double koszt)
        {
            Nazwa = nazwa;
            Koszt = koszt;
        }

        public bool Equals(Usluga u)
        {
            return Nazwa.Equals(u.Nazwa);
        }
        
    }
}
