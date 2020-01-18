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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Platforma platforma;
        

        public MainWindow()
        {
            InitializeComponent();
            platforma = Platforma.OdczytajJSON("platforma.json");
            //platforma = new Platforma("Halina");
        }

        

        private void BTZaloguj_Click(object sender, RoutedEventArgs e)
        {
            string login;
            string haslo;

            Projekt.KontoUzytkownika uzytkownik = new Projekt.KontoUzytkownika();
            if (TBLogin.Text == "" || TBPassword.Password == "")
            {
                MessageBox.Show("Uzupełnij login lub hasło");
                return;
            }

            login = TBLogin.Text;
            haslo = TBPassword.Password;

            try
            {
                uzytkownik = platforma.ListaKont.Find(k => k.Login.Equals(login));
            }
            catch
            {
                MessageBox.Show("Błędny login!");
            }
            

            if (uzytkownik.Haslo == haslo)
            {
                KontoUzytkownika okno = new KontoUzytkownika(uzytkownik);
                okno.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błędne hasło");
            }

        }

        private void BTZarejestruj__Click(object sender, RoutedEventArgs e)
        {
            Projekt.KontoUzytkownika Ku = new Projekt.KontoUzytkownika();
            RejestracjaWindow rej = new RejestracjaWindow(Ku, platforma.ListaKont);
            rej.ShowDialog();
            platforma.ListaKont.Add(Ku);
            platforma.ZapiszJSON("platforma.json");
        }        
    }
}
