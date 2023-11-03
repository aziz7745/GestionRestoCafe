using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetRestoCafe.Views
{
    public partial class ListeProduit : Form
    {
        public ListeProduit()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            AddProduit nouvelleFenetre = new AddProduit();  // créer une nouvelle instance de la classe Form
            nouvelleFenetre.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProduitId"].Value);
                    Produit p = db.Produits.Find(id);
                    AddProduit addpro = new AddProduit();
                    if (p != null)
                    {
                        addpro.remplir(p);
                        this.Hide();
                     
                    }


                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProduitId"].Value);
                    Produit p = db.Produits.Find(id);
                    if (p != null)
                    {
                        db.Produits.Remove(p);
                        db.SaveChanges();
                    }
                }
            }
            this.refreche();
        }

        private void refreche()
        {

            dataGridView1.Rows.Clear();
            var db = new MyDbContext();
            var produits = db.Produits.ToList();
            MemoryStream ms;
            Image imagee=null;
            // Ajouter les données à la DataGridView
            foreach (var produit in produits)
            {

                Categorie c = db.Categories.Find(produit.CategorieId);

                if (produit.Image != null && produit.Image.Length > 0)
                {
                    // Vérifier si les données d'image sont valides
                    try
                    {
                        ms = new MemoryStream(produit.Image);

                        // Vérifier si le flux de mémoire est correctement ouvert et initialisé
                        if (ms != null && ms.Length > 0 && ms.Position < ms.Length)
                        {
                            MessageBox.Show(ms.Length + "");
                            imagee = Image.FromStream(ms);
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        // Gérer l'exception
                        MessageBox.Show("Erreur lors de la lecture des données d'image : " + ex.Message);
                    }
                }

                dataGridView1.Rows.Add(produit.ProduitId, produit.Libelle, c.Name, produit.Prix, imagee ?? new Bitmap(1, 1));


                //Image imageProduit = Image.FromStream(new MemoryStream(produit.Image));
            }
        }

        private void ListeProduit_Load(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            var produits = db.Produits.ToList();
            Image image=null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("ProduitId", "Id");
            dataGridView1.Columns.Add("Produit", "Libelle");
            dataGridView1.Columns.Add("Categorie", "Categorie");
            dataGridView1.Columns.Add("Prix", "Prix");
            dataGridView1.Columns.Add(new DataGridViewImageColumn() { Name = "imageProduit", HeaderText = "Image", ImageLayout = DataGridViewImageCellLayout.Zoom });
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width =150;
            dataGridView1.Columns[4].Width = 200;
            MemoryStream ms;
            // Ajouter les données à la DataGridView
            foreach (var produit in produits)
            {
                
                Categorie c = db.Categories.Find(produit.CategorieId);
              
                if (produit.Image != null && produit.Image.Length > 0)
                {
                    // Vérifier si les données d'image sont valides
                    try
                    {
                        ms = new MemoryStream(produit.Image);
                        
                            // Vérifier si le flux de mémoire est correctement ouvert et initialisé
                            if (ms != null && ms.Length > 0 && ms.Position < ms.Length)
                            {
             
                                image = Image.FromStream(ms);
                            }
                        
                    }
                    catch (ArgumentException ex)
                    {
                        // Gérer l'exception
                        MessageBox.Show("Erreur lors de la lecture des données d'image : " + ex.Message);
                    }
                }

                dataGridView1.Rows.Add(produit.ProduitId, produit.Libelle, c.Name, produit.Prix, image ?? new Bitmap(1, 1));


                //Image imageProduit = Image.FromStream(new MemoryStream(produit.Image));
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
