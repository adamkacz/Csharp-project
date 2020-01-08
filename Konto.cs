using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [DataContract]
    class Konto : IEquatable<Konto>
    {
        string login;
        string haslo;
        string email;
        string imie;
        string nazwisko;

        [DataMember]
        public string Login { get => login; set => login = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public string Imie { get => imie; set => imie = value; }
        [DataMember]
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        [DataMember]
        public string Haslo { get => haslo; set => haslo = value; }

        public Konto()
        {
            Login = "";
            Haslo = "";
            Email = "";
            Imie = "";
            Nazwisko = "";
        }

        public Konto(string login, string haslo, string imie, string nazwisko, string email)
        {
            try { setLogin(login); }
            catch (LoginException f)
            {
                Console.WriteLine(f.Message);
            }

            try { setHaslo(haslo); }
            catch (HasloException e)
            {
                Console.WriteLine(e.Message);
            }
            Email = email;
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public void setHaslo(string haslo)
        {
            if (haslo.Length < 6)
            {
                throw new HasloException("Za krótkie hasło.");
            }
            else { Haslo = haslo; }
        }

        public void setLogin(string login)
        {
            if ((login.Length < 3) && (login.Length > 19))
            {
                throw new LoginException("Login nie może być krótszy niż 3 znaki ani dłuższy niż 19. ");
            }
            else { Login = login; }
        }

        public override string ToString()
        {
            return $"UŻYTKOWNIK: {login}, {imie} {nazwisko}, {email}";
        }

        public bool Equals(Konto k)
        {
            return Login.Equals(k.Login);
        }
    }
}