using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
    public class Credit
    {
        public int CreditId { get; set; }
        public Double montant { get; set; }
        public int? ServeurId { get; set; }

        public Credit(double montant)
        {
            this.montant = montant;
        }
    }
}
