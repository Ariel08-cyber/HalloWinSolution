namespace HalloWinUI.Models
{
    public class Enfant
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Enfant(string nom)
        {
            Nom = nom;
        }

    }
}
