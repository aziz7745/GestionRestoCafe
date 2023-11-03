using Microsoft.EntityFrameworkCore;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetRestoCafe.Views
{
    public partial class ConsulterVente : Form
    {
        public ConsulterVente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Ma liste de données";
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            PrintPreviewDialog printPreviewDlg = new PrintPreviewDialog();
            printPreviewDlg.Document = printDoc;
            printPreviewDlg.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Dessiner le titre
            e.Graphics.DrawString("Liste de dépenses", new Font("Arial", 16), Brushes.Black, new Point(100, 100));

            // Dessiner les données de la DataGridView
            int rowHeight = dataGridView1.RowTemplate.Height;
            int colCount = dataGridView1.ColumnCount;
            int y = 150;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int x = 100;
                for (int j = 0; j < colCount - 1; j++)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(x, y));
                    x += 200;
                }
                y += rowHeight;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Serveur c = (Serveur)comboBox1.SelectedItem;
            DateTime DateDeb = dateTimePicker1.Value.Date;
            DateTime Datefin = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            // Remplir la DataGridView avec les ventes et les produits associés
            using (var context = new MyDbContext())
            {
                // Récupérer les ventes avec leurs produits associés
                var vents = context.Ventes.Include(s => s.VenteProduits).ToList();

                // Parcourir chaque vente et ajouter une ligne de données pour chaque produit associé
                List<Vente> filteredExpenses = vents.Where(e => e.ServeurId == c.ServeurId && e.Date >= DateDeb && e.Date <= Datefin).ToList();
                this.filtrer(filteredExpenses);
            }

        }

        private void ConsulterVente_Load(object sender, EventArgs e)
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
            using (var context = new MyDbContext())
            {
                // Récupérer les ventes avec leurs produits associés
                var vents = context.Ventes.Include(s => s.VenteProduits).ToList();

                // Parcourir chaque vente et ajouter une ligne de données pour chaque produit associé
                foreach (var vent in vents)
                {

                    Serveur s = context.Serveurs.Find(vent.ServeurId);

                    foreach (var p in vent.VenteProduits)
                    {
                        Produit pp = db.Produits.Find(p.ProduitId);
                        String total = pp.Prix * p.Quantite + "";
                        dataGridView1.Rows.Add(pp.Libelle, pp.Prix, p.Quantite, total, s.Nom, vent.Date);
                    }
                }
            }

            comboBox1.DisplayMember = "Nom";
            var serveurs = db.Serveurs.ToList();
            comboBox1.Items.AddRange(serveurs.ToArray());
        }
        private void filtrer(List<Vente> l)
        {
            using (var context = new MyDbContext())
            {

                dataGridView1.Rows.Clear();
                // Parcourir chaque vente et ajouter une ligne de données pour chaque produit associé
                foreach (var vent in l)
                {

                    Serveur s = context.Serveurs.Find(vent.ServeurId);

                    foreach (var p in vent.VenteProduits)
                    {
                        Produit pp = context.Produits.Find(p.ProduitId);
                        String total = pp.Prix * p.Quantite + "";
                        dataGridView1.Rows.Add(pp.Libelle, pp.Prix, p.Quantite, total, s.Nom, vent.Date);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
