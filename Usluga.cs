using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [Serializable]
    [DataContract]
    public abstract class Usluga : IEquatable<Usluga>
    {
        double koszt;
        string nazwa;

        [DataMember]
        public double Koszt { get => koszt; set => koszt = value; }
        [DataMember]
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