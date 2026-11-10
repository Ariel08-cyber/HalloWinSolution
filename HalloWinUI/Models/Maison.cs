using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Models
{
    public class Maison
    {
        public int Id { get; set; }
        public string NumeroCivique { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public bool EstSignalee { get; set; }

        public Maison(string numeroCivique, string rue, string ville,
                      string codePostal = "", bool estSignalee = false)
        {
            NumeroCivique = numeroCivique;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            EstSignalee = estSignalee;
        }

    }
}
