using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
     public class ProduitVente
    {
        public int id { get; set; }
        public int VenteId { get; set; }
        public Vente Vente { get; set; }
       
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }

        public ProduitVente()
        {

         
        }
    }
}
