using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Libelle { get; set; }

        public string Description { get; set; }
        public int Prix { get; set; }
        public int? CategorieId { get; set; }
        public byte[] Image { get; set; }
    

        //public ICollection<Vente> Ventes { get; set; }

        public ICollection<ProduitVente> VenteProduits { get; set; }


        public Produit(string libelle, string description,byte[] image,int prix)
        {
            Libelle = libelle;
            Description = description;
            Image = image;
            this.Prix = prix;
         
          
        }
        public Produit() { }
    }
}
