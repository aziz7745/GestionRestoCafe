using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;

namespace ProjetRestoCafe.Views
{
    public partial class AddCategorie : Form
    {
        public AddCategorie()
        {
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            var categorie = new Categorie(textBox1.Text);
            db.Categories.Add(categorie);
            db.SaveChanges();
            textBox1.Text = "";
            this.refreche();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddCategorie_Load(object sender, EventArgs e)
        {

            var db = new MyDbContext();
            var categories = db.Categories.ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("CategorieId", "Id");
            dataGridView1.Columns.Add("Name", "Nom");
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;

            // Ajouter les données à la DataGridView
            foreach (var categorie in categories)
            {
                dataGridView1.Rows.Add(categorie.CategorieId, categorie.Name);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    Categorie c = db.Categories.Find(id);
                    if (c != null)
                    {
                        db.Categories.Remove(c);
                        db.SaveChanges();
                    }
                }
            }
            this.refreche();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void refreche()
        {

            dataGridView1.Rows.Clear();
            var db = new MyDbContext();
            var categories = db.Categories.ToList();

            // Ajouter les données à la DataGridView
            foreach (var categorie in categories)
            {
                dataGridView1.Rows.Add(categorie.CategorieId, categorie.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
