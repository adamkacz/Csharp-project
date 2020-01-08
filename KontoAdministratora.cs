using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class KontoAdministratora : Konto
    {
        public KontoAdministratora() : base() { }

        public KontoAdministratora(string login, string haslo, string imie, string nazwisko, string email) : base(login, haslo, imie, nazwisko, email) { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
