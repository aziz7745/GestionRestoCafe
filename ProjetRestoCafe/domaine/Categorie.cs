using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
   public class Categorie
    {
        public int CategorieId { get; set; }
        public string Name{ get; set; }
        public virtual ICollection<Produit> Produits { get; set; }

        public Categorie(string name)
        {
            Name = name;
        }
       
    }
}
