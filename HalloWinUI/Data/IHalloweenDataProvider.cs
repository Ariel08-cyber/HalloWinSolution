using HalloWinUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Data
{
    public interface IHalloweenDataProvider
    {
        List<Maison> GetMaisons();
        void AjouterMaison(Maison maison);
        void SupprimerMaison(int maisonId);
        void ModifierMaison(Maison maison);

    }
}
