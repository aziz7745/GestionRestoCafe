using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
    public  class Vente
    {
        public int VenteId { get; set; }
        public int? ServeurId { get; set; }
        public DateTime Date { get; set; }
      //  public ICollection<Produit> Produits { get; set; }
        public ICollection<ProduitVente> VenteProduits { get; set; }

        public Vente(DateTime date)
        {
           
            Date = date;
            VenteProduits = new HashSet<ProduitVente>();
        }
    }
}
