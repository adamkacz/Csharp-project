using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [Serializable]
    [DataContract]
    public class Platforma
    {
        string nazwa;
        List<KontoUzytkownika> listaKont;
        List<Film> listaFilmow;
        List<Usluga> listaDoWyboru;

        [DataMember]
        public List<KontoUzytkownika> ListaKont { get => listaKont; set => listaKont = value; }
        [DataMember]
        public List<Film> ListaFilmow { get => listaFilmow; set => listaFilmow = value; }
        [DataMember]
        public string Nazwa { get => nazwa; set => nazwa = value; }

        public Platforma()
        {
            nazwa = "";
            ListaKont = new List<KontoUzytkownika>();
            ListaFilmow = new List<Film>();
        }

        public Platforma(string nazwa)
        {
            Nazwa = nazwa;
            ListaKont = new List<KontoUzytkownika>();
            ListaFilmow = new List<Film>();
        }

        public void DodawanieFilmow(Film film)
        {
            ListaFilmow.Add(film);
        }

        public void UsunUzytkownika(KontoUzytkownika uzyt)
        {
            ListaKont.Remove(uzyt);
        }

        public void UsunFilm(Film film)
        {
            ListaFilmow.Remove(film);
        }

        public override string ToString()
        {
            return $"PLATFORMA: {nazwa}";
        }

        public void ZapiszJSON(string nazwa)
        {
            DataContractJsonSerializer dcs = new DataContractJsonSerializer(typeof(Platforma));
            using (FileStream fs = new FileStream(nazwa, FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static Platforma OdczytajJSON(string nazwa)
        {
            DataContractJsonSerializer dcs = new DataContractJsonSerializer(typeof(Platforma));
            using (FileStream fs = new FileStream(nazwa, FileMode.Open))
            {
                return dcs.ReadObject(fs) as Platforma;
            }
        }

        
    }
}
