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
    public partial class AddServeur : Form
    {
        public int id;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public AddServeur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            var Serveure = new Serveur(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);
            var User = new User(textBox1.Text, textBox5.Text, "Serveur");
            db.Serveurs.Add(Serveure);
            db.Users.Add(User);
            db.SaveChanges();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            this.refreche();
        }

        private void AddServeur_Load(object sender, EventArgs e)
        {

            var db = new MyDbContext();
            var serveurs = db.Serveurs.ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("ServeurId", "Id");
            dataGridView1.Columns.Add("Nom", "Nom");
            dataGridView1.Columns.Add("Prenom", "Prenom");
            dataGridView1.Columns.Add("Adresse", "Adresse");
            dataGridView1.Columns.Add("Numtel", "Numéro");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;

            // Ajouter les données à la DataGridView
            foreach (var serveur in serveurs)
            {
                dataGridView1.Rows.Add(serveur.ServeurId, serveur.Nom, serveur.Prenom, serveur.Adresse, serveur.Numtel);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {


                    using (var db = new MyDbContext())
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {

                            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ServeurId"].Value);
                            this.id = id;
                            Serveur s = db.Serveurs.Find(id);
                            if (s != null)
                            {
                                textBox1.Text = s.Nom + "";
                                textBox2.Text = s.Prenom;
                                textBox3.Text = s.Adresse;
                                textBox5.Text = s.Numtel;

                            }
                        }
                    }
                }
            }
        
        private void refreche()
        {

            dataGridView1.Rows.Clear();
            var db = new MyDbContext();
            var serveurs = db.Serveurs.ToList();

            // Ajouter les données à la DataGridView
            foreach (var serveur in serveurs)
            {
                dataGridView1.Rows.Add(serveur.ServeurId, serveur.Nom, serveur.Prenom, serveur.Adresse, serveur.Numtel);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ServeurId"].Value);
                    Serveur s = db.Serveurs.Find(id);
                    if (s != null)
                    {
                        db.Serveurs.Remove(s);
                        db.SaveChanges();
                    }
                }
            }
            this.refreche();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {

                Serveur s = db.Serveurs.Find(this.id);
                s.Nom = textBox1.Text;
                s.Prenom = textBox2.Text;
                s.Adresse = textBox3.Text;
                s.Numtel = textBox5.Text;
                db.SaveChanges();

            }
            this.refreche();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
