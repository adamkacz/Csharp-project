using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy RejestracjaWindow.xaml
    /// </summary>
    public partial class RejestracjaWindow : Window
    {
        Projekt.KontoUzytkownika konto;
        List<Projekt.KontoUzytkownika> listaK;

        public RejestracjaWindow() 
        {
            InitializeComponent();
        }

        public RejestracjaWindow(Projekt.KontoUzytkownika k, List<Projekt.KontoUzytkownika> listaK) : this()
        {
            this.konto = k;
            this.listaK = listaK;
        }

        private void BTZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string imie = TBImię.Text;
            string nazwisko = TBNazwisko.Text;
            string haslo = PBHaslo.Password;
            string email = TBEmail.Text;
            string login = TBLogin.Text;
            DateTime dataUrodzenia = DPDataUr.DisplayDate;

            foreach(Konto k in listaK)
            {
                if(k.Login == login)
                {
                    MessageBox.Show($"Istnieje już konto o podanym loginie.{Environment.NewLine}Wybierz inny login.");
                    return;
                }
            }

            if (PBHaslo.Password != PBPowtorzHaslo.Password)
            {
                MessageBox.Show("Hasło i powtórzone hasło różnią się od siebie.");
                return;
            }

            if (dataUrodzenia > DateTime.Now)
            {
                MessageBox.Show("Niepoprawna data urodzenia.");
                return;
            }

            if(email.Contains("@"))
            {
                string[] s = email.Split('@');
                if(s.Length > 2)
                {
                    MessageBox.Show("Niepoprawny email.");
                    return;
                }
                if(!s[1].Contains('.') || s[1][0] == '.' )
                {
                    MessageBox.Show("Niepoprawny email.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Niepoprawny email.");
                return;
            }

            if(haslo.Length < 6)
            {
                MessageBox.Show("Hasło jest zbyt krótkie. Powinno mieć więcej niż 6 znaków!");
                return;
            }

            if ((login.Length < 3) && (login.Length > 19))
            {
                MessageBox.Show("Login powinien zwierać od 4 do 19 znaków!");
                return;
            }
            
            this.konto.Email = email;
            this.konto.Imie = imie;
            this.konto.Nazwisko = nazwisko;
            this.konto.DataUrodzenia = dataUrodzenia;
            this.konto.Haslo = haslo;
            this.konto.Login = login;

            
            this.Close();
        }
    }
}
