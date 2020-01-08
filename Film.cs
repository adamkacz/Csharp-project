using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class WrongAgeException : Exception
    {

    }

    enum Gatunek { komedia, horror, romantyczny, dokumentalny, fantasy, thriller }
    class Film
    {
        string tytul;
        Gatunek gatunek;
        int ograniczenieWiekowe;
        List<Recenzja> listaRecenzji;

        public string Tytul { get => tytul; set => tytul = value; }
        public int OgraniczenieWiekowe { get => ograniczenieWiekowe; set => ograniczenieWiekowe = value; }
        public Gatunek Gatunek { get => gatunek; set => gatunek = value; }
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

    }


}
