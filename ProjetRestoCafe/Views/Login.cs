using MySqlX.XDevAPI;
using ProjetRestoCafe.data;
using ProjetRestoCafe.domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetRestoCafe.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string password = textBox2.Text;

            var db = new MyDbContext(); ;
            var user = db.Users.FirstOrDefault(e => e.Name == Username && e.Password == password);
            if (user == null)
            {
                MessageBox.Show("Utilisateur n'existe pas");
                textBox1.Text = "";
                textBox2.Text = "";
            }

            else
            {
                

                if (user.Type == "Admin")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    ListParam m = new ListParam();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    var serveur = db.Serveurs.FirstOrDefault(e => e.Password == user.Password);
                    Menu m = new Menu();
                    m.charger(serveur);
                    this.Hide();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
