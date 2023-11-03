using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetRestoCafe.Views
{
    public partial class AddProduit : Form
    {
        public AddProduit()
        {
            InitializeComponent();
        }

        public Produit p;
        public Produit proModifier;
        public Categorie cat;
        public Boolean select = false;
        public byte[] imageBytes;
        public Boolean verif = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

             this.select = true;
             p = new Produit();
             OpenFileDialog openFileDialog = new OpenFileDialog();

            // Définir les filtres d'extension de fichier à afficher
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.bmp;*.jpg;*.jpeg;*.png";

            // Afficher la boîte de dialogue pour sélectionner un fichier
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Récupérer le nom et le chemin du fichier sélectionné
                string fileName = openFileDialog.FileName;

                // Créer une instance de la classe Image à partir du fichier
                Image image = Image.FromFile(fileName);

                // Convertir l'image en tableau de bytes
                
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    this.imageBytes = ms.ToArray();
                }

                // Affecter le tableau de bytes à la propriété p.Image
                p.Image = imageBytes;

                // Afficher l'image dans la PictureBox
                pictureBox1.Image = image;
            }


        }


        public void remplir(Produit p)
        {
            this.verif = true;
            button2.Enabled = false;
            textBox1.Text = p.Libelle;
            textBox2.Text = p.Description;
            textBox3.Text = p.Prix + "";
            var db = new MyDbContext();

            Categorie c = db.Categories.Find(p.CategorieId);
            this.cat = c;
            this.proModifier = p;
            string selectedValue = c.Name;
            comboBox1.Text = selectedValue;
            Image imageProduit = Image.FromStream(new MemoryStream(p.Image));
            pictureBox1.Image = imageProduit;
            this.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddProduit_Load(object sender, EventArgs e)
        {
            if(this.verif==true)
            {
                button2.Enabled = false;
            }
            comboBox1.DisplayMember = "Name";
            var db = new MyDbContext();
            var categories = db.Categories.ToList();
            comboBox1.Items.AddRange(categories.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Categorie c = (Categorie)comboBox1.SelectedItem;
            p.Libelle = textBox1.Text;
            p.Description = textBox2.Text;
            p.Prix = int.Parse(textBox3.Text);


            p.CategorieId = c.CategorieId;

            // Ajouter le produit à la base de données
            using (var db = new MyDbContext())
            {
                db.Produits.Add(p);
                db.SaveChanges();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Image = null;
            p = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
            using (var db = new MyDbContext())
            {
                Produit pro = db.Produits.Find(this.proModifier.ProduitId);

                pro.Libelle = textBox1.Text;
                pro.Description = textBox2.Text;
                pro.Prix = int.Parse(textBox3.Text);
                Categorie c = (Categorie)comboBox1.SelectedItem;
                if (c != null)
                {
                    pro.CategorieId = c.CategorieId;
                }
                else if (c == null)
                {

                    pro.CategorieId = this.cat.CategorieId;
                }
                if (this.select == true)
                {

                    pro.Image = this.imageBytes;
                }

                db.SaveChanges();
            }

            this.Hide();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ListeProduit m = new ListeProduit();
           // m.Show();
            this.Hide();
        }
    }
}

