using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
    public class Depense
    {
        public int DepenseId { get; set; }
        public string Libelle { get; set; }
        public Double Montant { get; set; }
        public DateTime Date { get; set; }

        public Depense(string libelle, double montant, DateTime date)
        {
            Libelle = libelle;
            Montant = montant;
            Date = date;
        }
    }
}
