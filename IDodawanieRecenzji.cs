using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    interface IDodawanieRecenzji
    {
        void DodajRecenzje(Recenzja rec, Film f);
        void UsunRecenzje(Recenzja rec, Film f);
    }
}
