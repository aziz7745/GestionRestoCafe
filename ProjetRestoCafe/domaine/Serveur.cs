using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
public class Serveur
    {
        public int ServeurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Numtel { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Vente> Vents { get; set; }

        public Serveur(string nom, string prenom, string adresse, string numtel)
        {
     
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Numtel = numtel;
            Password = numtel;
        }
    }
}
