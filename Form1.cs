using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreerStade_Click(object sender, EventArgs e)
        {
            CreateStade cr = new CreateStade();
            cr.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResaForm rs = new ResaForm();
            rs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Evenemens ev = new Evenemens();
            ev.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
