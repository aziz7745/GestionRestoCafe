using Microsoft.EntityFrameworkCore;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using ProjetRestoCafe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeResto
{
    public partial class ReglerCredit : Form
    {
        Double somme = 0;
      //  int serveurid;
        Serveur c;
        public ReglerCredit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new MyDbContext();

            // Parcourir les lignes de la DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Vérifier si la case à cocher est cochée pour cette ligne
                if (row.Cells["Select"].Value != null && (bool)row.Cells["Select"].Value)
                {
                    // Récupérer la valeur de la colonne "CreditId" pour cette ligne
                    int creditId = (int)row.Cells["CreditId"].Value;
                    Credit c = db.Credits.Find(creditId);
                    db.Credits.Remove(c);
                    db.SaveChanges();
                }
            }

            this.refreche();


        }
        public void passer(int id)
        {
           // this.serveurid = id;
            this.Show();
        }

        private void ReglerCredit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("CreditId", "Id");
            dataGridView1.Columns.Add("Serveur", "Serveur");
            dataGridView1.Columns.Add("Montant", "Montant");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Name = "Select";
            checkboxColumn.HeaderText = "Select";
            dataGridView1.Columns.Add(checkboxColumn);
            var db = new MyDbContext();
            comboBox1.DisplayMember = "Nom";
            var serveurs = db.Serveurs.ToList();
            comboBox1.Items.AddRange(serveurs.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.c = (Serveur)comboBox1.SelectedItem;

            using (var db = new MyDbContext())
            {
                var credits = db.Credits.ToList();
                if (credits != null)
                {
                    List<Credit> filteredExpenses = credits.Where(e => e.ServeurId == c.ServeurId).ToList();
                    this.filtrer(filteredExpenses, c);
                }
            }
        }

        private void filtrer(List<Credit> l, Serveur c)
        {
            using (var db = new MyDbContext())
            {

                dataGridView1.Rows.Clear();

                foreach (var credit in l)
                {
                    somme = somme + (Double)credit.montant;
                    dataGridView1.Rows.Add(credit.CreditId, c.Nom, credit.montant);

                }

                textBox2.Text = somme + "";


            }

        }

        public void refreche()
        {
            dataGridView1.Rows.Clear();
            this.somme = 0;
            using (var db = new MyDbContext())
            {
                var credits = db.Credits.ToList();
                if (credits != null)
                {
                    foreach (var credit in credits)
                    {
                        somme = somme + (Double)credit.montant;
                        dataGridView1.Rows.Add(credit.CreditId, c.Nom, credit.montant);

                    }

                    textBox2.Text = somme + "";

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            
        }
    }

}
