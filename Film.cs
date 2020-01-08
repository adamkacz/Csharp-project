using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    enum Gatunek { komedia, horror, romantyczny, dokumentalny, fantasy, thriller }
    [DataContract]
    class Film : IComparable<Film>
    {
        string tytul;
        Gatunek gatunek;
        int ograniczenieWiekowe;
        List<Recenzja> listaRecenzji;

        [DataMember]
        public string Tytul { get => tytul; set => tytul = value; }
        [DataMember]
        public int OgraniczenieWiekowe { get => ograniczenieWiekowe; set => ograniczenieWiekowe = value; }
        [DataMember]
        public Gatunek Gatunek { get => gatunek; set => gatunek = value; }
        [DataMember]
        public List<Recenzja> ListaRecenzji { get => listaRecenzji; set => listaRecenzji = value; }

        public Film()
        {
            Tytul = "";
            ograniczenieWiekowe = 0;
            ListaRecenzji = new List<Recenzja>();
        }

        public Film(string tytul, Gatunek gatunek, int ograniczenieWiekowe)
        {
            Tytul = tytul;
            OgraniczenieWiekowe = ograniczenieWiekowe;
            ListaRecenzji = new List<Recenzja>();
        }

        public override string ToString()
        {
            return $"FILM: '{tytul}', Gatunek: {gatunek}, Ograniczenie wiekowe: {ograniczenieWiekowe}";
        }


        public int CompareTo(Film f)
        {
            return Tytul.CompareTo(f.Tytul);
        }
    }

}