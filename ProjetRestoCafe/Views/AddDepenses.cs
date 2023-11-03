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
    public partial class AddDepenses : Form
    {

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public AddDepenses()
        {
            InitializeComponent();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            var db = new MyDbContext();
            DateTime selectedDate = dateTimePicker1.Value;
            Double number = Double.Parse(textBox3.Text);
            Depense dep = new Depense(textBox1.Text, number, selectedDate);
            db.Depenses.Add(dep);
            db.SaveChanges();
            textBox1.Text = "";
            textBox3.Text = "";
            this.refreche();
        }

        private void refreche()
        {

            dataGridView1.Rows.Clear();
            var db = new MyDbContext();
            var depenses = db.Depenses.ToList();

            // Ajouter les données à la DataGridView
            foreach (var depense in depenses)
            {
                dataGridView1.Rows.Add(depense.DepenseId, depense.Libelle, depense.Montant, depense.Date);
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

                        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepenseId"].Value);

                        Depense s = db.Depenses.Find(id);
                        if (s != null)
                        {
                            textBox1.Text = s.Libelle;
                            textBox3.Text = s.Montant + "";
                            dateTimePicker1.Text = s.Date.ToString();




                        }
                    }
                }
            }
        }
        private void AddDepenses_Load(object sender, EventArgs e)
        {

            var db = new MyDbContext();
            var depenses = db.Depenses.ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("DepenseId", "Id");
            dataGridView1.Columns.Add("Libelle", "Libellé");
            dataGridView1.Columns.Add("Montant", "Montant");
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;

            // Ajouter les données à la DataGridView
            foreach (var depense in depenses)
            {
                dataGridView1.Rows.Add(depense.DepenseId, depense.Libelle, depense.Montant, depense.Date);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new MyDbContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepenseId"].Value);
                    Depense dep = db.Depenses.Find(id);
                    if (dep != null)
                    {
                        db.Depenses.Remove(dep);
                        db.SaveChanges();
                    }
                }
            }
            this.refreche();
        }





        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime DateDeb = dateTimePicker2.Value.Date;
            DateTime Datefin = dateTimePicker3.Value.Date.AddDays(1).AddSeconds(-1);

            using (var db = new MyDbContext())
            {
                DbSet<Depense> deps = db.Depenses;
                if (deps != null)
                {
                    List<Depense> filteredExpenses = deps.Where(e => e.Date >= DateDeb && e.Date <= Datefin).ToList();

                    this.filtrer(filteredExpenses);
                }
            }

        }

        private void filtrer(List<Depense> list)
        {
            using (var db = new MyDbContext())
            {
                dataGridView1.Rows.Clear();


                // Ajouter les données à la DataGridView
                foreach (var depense in list)
                {
                    dataGridView1.Rows.Add(depense.DepenseId, depense.Libelle, depense.Montant, depense.Date);
                }
            }
        }

     
        private void button2_Click(object sender, EventArgs e)
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
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                int x = 100;
                for (int j = 0; j < colCount-1; j++)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(x, y));
                    x += 200;
                }
                y += rowHeight;
            }
        }

    }
}
