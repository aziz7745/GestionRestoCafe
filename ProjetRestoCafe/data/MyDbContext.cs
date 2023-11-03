using Microsoft.EntityFrameworkCore;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits{ get; set; }
        public DbSet<Serveur> Serveurs { get; set; }
        public DbSet<Depense> Depenses { get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProduitVente> ProduitVentes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=CafeRestoProject;user=root;password=");
        }
        

    }






}
