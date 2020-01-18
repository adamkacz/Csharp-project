using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [Serializable]
    [DataContract]
    public class Recenzja : IComparable<Recenzja>, IEquatable<Recenzja>, ICloneable
    {
        string opis;
        KontoUzytkownika uzytkownik;
        DateTime czasDodania;

        [DataMember]
        public string Opis { get => opis; set => opis = value; }
        [DataMember]
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

        public object Clone()
        {
            BinaryFormatter bf = new BinaryFormatter();
            BinaryFormatter bffinal = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                ms.Position = 0;
                return bffinal.Deserialize(ms);
            }
        }


    }
}