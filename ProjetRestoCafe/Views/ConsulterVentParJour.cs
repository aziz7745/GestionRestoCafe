using CafeResto;
using Microsoft.EntityFrameworkCore;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetRestoCafe.Views
{
    public partial class ConsulterVentParJour : Form
    {

        int somme, credit = 0;
        int serveurid;
        public ConsulterVentParJour()
        {
            InitializeComponent();
        }



        private void ConsulterVentParJour_Load(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            var ventes = db.Ventes.ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Produit", "Produit");
            dataGridView1.Columns.Add("Prix", "Prix");
            dataGridView1.Columns.Add("Qte", "Qte");
            dataGridView1.Columns.Add("Totale", "Totale");
            dataGridView1.Columns.Add("Serveur", "Serveur");
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 200;

            // Remplir la DataGridView avec les ventes et les produits associés

            DateTime now = DateTime.Now.Date;
            //Serveur c = (Serveur)comboBox1.SelectedItem;
            using (var context = new MyDbContext())
            {
                // Récupérer les ventes avec leurs produits associés
                var vents = context.Ventes.Include(s => s.VenteProduits).ToList();

                if (vents != null)
                {
                  List<Vente> filteredExpenses = vents.Where(e => e.Date.Date == now).ToList();

                    foreach (var vent in filteredExpenses)
                    {

                        Serveur s = context.Serveurs.Find(vent.ServeurId);

                        foreach (var p in vent.VenteProduits)
                        {
                            Produit pp = context.Produits.Find(p.ProduitId);
                            String total = pp.Prix * p.Quantite + "";
                            somme = somme + int.Parse(total);
                            dataGridView1.Rows.Add(pp.Libelle, pp.Prix, p.Quantite, total, s.Nom, vent.Date);
                        }
                    }
                }
            }


            
            comboBox1.DisplayMember = "Nom";
            var serveurs = db.Serveurs.ToList();
            comboBox1.Items.AddRange(serveurs.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now.Date;
            Serveur c = (Serveur)comboBox1.SelectedItem;
            this.serveurid = c.ServeurId;
            using (var context = new MyDbContext())
            {
                // Récupérer les ventes avec leurs produits associés
                var vents = context.Ventes.Include(s => s.VenteProduits).ToList();

                if (vents != null)
                {
                    List<Vente> filteredExpenses = vents.Where(e => e.ServeurId == c.ServeurId && e.Date.Date == now).ToList();

                    this.filtrer(filteredExpenses);
                }
            }

     

        }
       
        private void filtrer(List<Vente> l)
        {
            using (var context = new MyDbContext())
            {

                dataGridView1.Rows.Clear();
                somme = 0;
                // Parcourir chaque vente et ajouter une ligne de données pour chaque produit associé
                foreach (var vent in l)
                {

                    Serveur s = context.Serveurs.Find(vent.ServeurId);

                    foreach (var p in vent.VenteProduits)
                    {
                        Produit pp = context.Produits.Find(p.ProduitId);
                        String total = pp.Prix * p.Quantite + "";
                        somme = somme + int.Parse(total);
                        dataGridView1.Rows.Add(pp.Libelle, pp.Prix, p.Quantite, total, s.Nom, vent.Date);
                    }
                }
            }

         
            textBox2.Text = somme + "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReglerCredit regler = new ReglerCredit();
            var db = new MyDbContext();
            Credit c = new Credit(credit*-1);
            c.ServeurId = serveurid;
            db.Credits.Add(c);
            db.SaveChanges();
            // regler.passer(this.serveurid);
            //ListParam m = new ListParam();
           // m.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int montantpayer = int.Parse(textBox3.Text);
            credit = montantpayer - somme;
            if (credit < 0)
            {
                label3.Text = "Crédit";
                textBox4.Text = credit + "";
                button3.Visible = true;

            }
            if (credit > 0)
            {
                label3.Text = "PourBoire";
                textBox4.Text = credit + "";
                button3.Visible = false;

            }

        }
    }
}
