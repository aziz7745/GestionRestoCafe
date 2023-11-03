using CafeResto;
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
    public partial class ListParam : Form
    {
        
        public ListParam()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ListParam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsulterVente c = new ConsulterVente();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListeProduit l = new ListeProduit();
            l.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddDepenses a = new AddDepenses();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddServeur add = new AddServeur();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddCategorie add = new AddCategorie();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConsulterVentParJour c = new ConsulterVentParJour();
            c.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReglerCredit r = new ReglerCredit();
            r.Show();
        }
    }
}
