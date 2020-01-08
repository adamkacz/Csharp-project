using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    abstract class Konto
    {
        string login;
        string haslo;
        string email;
        string imie;
        string nazwisko;

        public string Login { get => login; set => login = value; }
        public string Email { get => email; set => email = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Haslo { get => haslo; set => haslo = value; }

        public Konto()
        {
            Login = "";
            Haslo = "";
            Email = "";
            Imie = "";
            Nazwisko = "";
        }

        public Konto(string login, string haslo, string email, string imie, string nazwisko)
        {
            Login = login;


            try { setHaslo(haslo); }
            catch (Exception e)
            {
                Console.WriteLine("Za krótkie hasło. "+e.Message);
            }
            Email = email;
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public void setHaslo(string haslo)
        {
            if(haslo.Length<6)
            { 
              throw new Exception();
            }
            else { Haslo = haslo; }
        }
      
        public override string ToString()
        {
            return $"UŻYTKOWNIK: {imie} {nazwisko}, {email}";
        }
    }
}
