using Microsoft.EntityFrameworkCore;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections;
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
    public partial class Menu : Form
    {


        Serveur u;
        List<Produit> ListProduit = new List<Produit>();
        Produit ProduitSelected;
        int pointeur = 1;
        int qte = 1;
        int somme = 0;
        int i = 0;
        Panel myPanel = new Panel();
        Panel myPanel1 = new Panel();
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            label2.Text = u.Nom + " " + u.Prenom;

            //panel for catégorie

            myPanel.Location = new Point(440, 370);
            myPanel.Size = new Size(685, 102);
            myPanel.BackColor = Color.White;
            this.Controls.Add(myPanel);

            //panel for produit

            myPanel1.Location = new Point(440, 48);
            myPanel1.Size = new Size(685, 301);
            myPanel1.BackColor = Color.White;
            this.Controls.Add(myPanel1);

            //Add the name of serveur
            //label2.Text = u.Nom + " " + u.Prenom;

            //définir les columns de datagridview
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Produit", "Produit");
            dataGridView1.Columns.Add("Prix", "Prix");
            dataGridView1.Columns.Add("Qte", "Qte");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;

            //Activier et désactiver les button de navigation
            if (i == 0)
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }


            var db = new MyDbContext();
            var categories = db.Categories.ToList();
            var produits = db.Produits.ToList();


            //afficher les catégorie 4 par 4
            for (int j = i; j < i + 4 && j < categories.Count; j++)
            {

                if (j == i)
                {
                    int catid = categories[j].CategorieId;
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;
                    myButton.Location = new Point(26, 20);
                    myPanel.Controls.Add(myButton);
                    myButton.Click += (sender, e) =>
                    {

                        this.getBycat(catid);
                    };
                }
                if (j == i + 1)
                {
                    int catid = categories[j].CategorieId;
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Location = new Point(194, 20);
                    myButton.Text = categories[j].Name;
                    myPanel.Controls.Add(myButton);
                    myButton.Click += (sender, e) =>
                    {

                        this.getBycat(catid);
                    };
                }
                if (j == i + 2)
                {
                    int catid = categories[j].CategorieId;
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;
                    myButton.Location = new Point(362, 20);
                    myPanel.Controls.Add(myButton);
                    myButton.Click += (sender, e) =>
                    {
                        this.getBycat(catid);
                    };
                }
                if (j == i + 3)
                {
                    int catid = categories[j].CategorieId;
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;
                    myButton.Location = new Point(526, 20);
                    myPanel.Controls.Add(myButton);
                    myButton.Click += (sender, e) =>
                    {
                        this.getBycat(catid);
                    };
                }


            }

            //afficher les produits produit par produit

            for (int j = i; j < i + 8 && j < produits.Count; j++)
            {
                if (j == i)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    myButton.Location = new Point(17, 25);
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);
                    myPanel1.Controls.Add(myButton);

                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };


                }
                if (j == i + 1)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 25);
                    this.ProduitSelected = produits[j];
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);

                    myPanel1.Controls.Add(myButton);

                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };



                }
                if (j == i + 2)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 25);
                    myButton.Text = produits[j].Libelle;
                    this.ProduitSelected = produits[j];
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);
                    myPanel1.Controls.Add(myButton);
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                }
                if (j == i + 3)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 25);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 4)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(17, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 5)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 6)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);


                    myPanel1.Controls.Add(myButton);
                }

                if (j == i + 7)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 161);

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myPanel1.Controls.Add(myButton);
                }
            }
        }




        public void getBycat(int idcat)
        {

            var db = new MyDbContext();
            List<Produit> filtered = db.Produits.Where(e => e.CategorieId == idcat).ToList();


            myPanel1.Controls.Clear();

            AfficherBycat(filtered);
        }

        public void AfficherBycat(List<Produit> produits)
        {

            foreach (Control c in myPanel1.Controls)
            {
                myPanel1.Controls.Remove(c);
            }

            if (i == 0)
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }


            var db = new MyDbContext();


            //afficher les produits produit par produit

            for (int j = i; j < i + 8 && j < produits.Count; j++)
            {

                if (j == i)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    myButton.Location = new Point(17, 25);
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);
                    myPanel1.Controls.Add(myButton);

                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };


                }
                if (j == i + 1)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 25);
                    this.ProduitSelected = produits[j];
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);

                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 2)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 25);
                    myButton.Text = produits[j].Libelle;
                    this.ProduitSelected = produits[j];

                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };



                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 3)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 25);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 4)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(17, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 5)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 6)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 161);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);


                    myPanel1.Controls.Add(myButton);
                }

                if (j == i + 7)
                {
                    Produit p = produits[j];
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 161);

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);
                    this.ProduitSelected = produits[j];
                    myButton.Click += (sender, e) =>
                    {
                        this.AddCommande(p);
                    };

                    myPanel1.Controls.Add(myButton);
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            DateTime now = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Vente vente = new Vente(DateTime.Now);
                vente.ServeurId = u.ServeurId;

                // Vérifier que la valeur de la cellule n'est pas nulle
                if (row.Cells[0].Value != null && row.Cells[2].Value != null)
                {

                    string produit = row.Cells[0].Value.ToString();
                    int qte = Convert.ToInt32(row.Cells[2].Value);

                    // Find the corresponding Produit entity from ListProduit
                    Produit pro = db.Produits.FirstOrDefault(e => e.Libelle == produit);

                    // Create a new ProduitVente entity and set its properties
                    ProduitVente venteProduit1 = new ProduitVente();
                    venteProduit1.Produit = pro;  // set the Produit entity
                    venteProduit1.Quantite = qte; // set the quantity
                    venteProduit1.Vente = vente;  // set the Vente entity
                    vente.VenteProduits.Add(venteProduit1);
                    // Add the ProduitVente entity to the Vente entity's collection
                    db.Ventes.Add(vente);
                    // Save the changes to the database
                    db.SaveChanges();

                }


            }
            this.terminer();

        }

        public void terminer()
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            this.ListProduit.Clear();
            somme = 0;


        }


        public void charger(Serveur u)
        {
            this.u = u;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string produit = dataGridView1.SelectedRows[0].Cells["Produit"].Value.ToString();
                Produit pro = ListProduit.FirstOrDefault(e => e.Libelle == produit);
                ListProduit.Remove(pro);
                this.AnnulerProduit();

            }


        }

        private void AnnulerProduit()
        {
            dataGridView1.Rows.Clear();
            somme = 0;
            // Ajouter les données à la DataGridView
            foreach (var produit in ListProduit)
            {
                dataGridView1.Rows.Add(produit.Libelle, produit.Prix, qte);
                somme = somme + (produit.Prix * qte);
            }
            textBox1.Text = somme + "";
        }

        private void refreche()
        {
            dataGridView1.Rows.Clear();
            somme = 0;
            // Ajouter les données à la DataGridView
            foreach (var produit in ListProduit)
            {
                dataGridView1.Rows.Add(produit.Libelle, produit.Prix, qte);
                somme = somme + (produit.Prix * qte);
            }
            textBox1.Text = somme + "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                qte += 1;
                dataGridView1.SelectedRows[0].Cells["Qte"].Value = qte.ToString();
                somme = somme + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Prix"].Value);
                textBox1.Text = somme + "";
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (qte > 1)
                {
                    qte -= 1;
                    dataGridView1.SelectedRows[0].Cells["Qte"].Value = qte.ToString();
                    somme = somme - Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Prix"].Value);
                    textBox1.Text = somme + "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListProduit.Clear();
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            somme = 0;
            // this.refreche();
        }



        private void refrechemenu()
        {
            //panel for catégorie
            Panel myPanel = new Panel();
            myPanel.Location = new Point(440, 370);
            myPanel.Size = new Size(685, 102);
            myPanel.BackColor = Color.White;
            this.Controls.Add(myPanel);

            //panel for produit
            Panel myPanel1 = new Panel();
            myPanel1.Location = new Point(440, 48);
            myPanel1.Size = new Size(685, 301);
            myPanel1.BackColor = Color.White;
            this.Controls.Add(myPanel1);
            if (i != 0)
            {
                button6.Visible = true;
                button7.Visible = true;

            }
            else
            {
                button6.Visible = false;
                button7.Visible = false;
            }

            var db = new MyDbContext();
            var categories = db.Categories.ToList();
            var produits = db.Produits.ToList();


            //afficher les catégorie 4 par 4
            for (int j = i; j < i + 4 && j < categories.Count; j++)
            {

                if (j == i)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;
                    myButton.Location = new Point(26, 20);
                    myPanel.Controls.Add(myButton);
                }
                else if (j == i + 1)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;
                    myButton.Location = new Point(194, 20);
                    myPanel.Controls.Add(myButton);
                }
                else if (j == i + 2)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;

                    myButton.Location = new Point(362, 20);
                    myPanel.Controls.Add(myButton);
                }
                else if (j == i + 3)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(132, 63);
                    myButton.Text = categories[j].Name;

                    myButton.Location = new Point(526, 20);
                    myPanel.Controls.Add(myButton);
                }


            }

            //afficher les produits produit par produit

            for (int j = i; j < i + 8 && j < produits.Count; j++)
            {
                if (j == i)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    myButton.Location = new Point(17, 25);
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));

                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);

                }
                if (j == i + 1)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 25);

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 2)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 25);
                    myButton.Text = produits[j].Libelle;




                    // Vérifier si la couleur de fond est blanche ou non

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 3)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 25);
                    // Vérifier si la couleur de fond est blanche ou non

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 4)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(17, 161);
                    // Vérifier si la couleur de fond est blanche ou non

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 5)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(184, 161);
                    // Vérifier si la couleur de fond est blanche ou non

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);




                    myPanel1.Controls.Add(myButton);
                }
                if (j == i + 6)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(362, 161);
                    // Vérifier si la couleur de fond est blanche ou non

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);


                    myPanel1.Controls.Add(myButton);
                }

                if (j == i + 7)
                {
                    Button myButton = new Button();
                    myButton.Size = new Size(127, 121);
                    myButton.Text = produits[j].Libelle;
                    Image imageProduit = Image.FromStream(new MemoryStream(produits[j].Image));
                    imageProduit = imageProduit.GetThumbnailImage(myButton.Width, myButton.Height, null, IntPtr.Zero);
                    myButton.BackgroundImage = imageProduit;
                    myButton.TextAlign = ContentAlignment.TopLeft;
                    myButton.Location = new Point(531, 161);

                    myButton.Font = new Font("Arial", 15, FontStyle.Bold);



                    myPanel1.Controls.Add(myButton);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.i = i - 8;
            this.refrechemenu();
        }

        private void AddCommande(Produit p)
        {
            this.ListProduit.Add(p);
            dataGridView1.Rows.Add(p.Libelle, p.Prix, 1);
            somme = somme + (p.Prix * qte);
            textBox1.Text = somme + "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.i = i + 8;
            this.refrechemenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.i = i - 4;
            this.refrechemenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.i = i + 4;
            this.refrechemenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
