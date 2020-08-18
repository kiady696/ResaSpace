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
    public partial class Evenemens : Form
    {
        List<Evenement> evenement;

        internal List<Evenement> Evenement { get => evenement; set => evenement = value; }

        public Evenemens()
        {
            InitializeComponent();
            Fonction f = new Fonction();
            DBConnect dbc = new DBConnect();
            List<Stade>stades = f.getAllStades(dbc);
            for (int j = 0; j < stades.Count; j++)
            {
                comboBox2.Items.Add(stades[j].Id+"-"+stades[j].Nom);
            }
            List<Evenement> events = f.getAllEvenements(dbc);
            evenement = events;
            for(int i = 0; i < events.Count; i++)
            {
                comboBox1.Items.Add(events[i].Nom);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string idStadeNomStade = comboBox2.Text;
                char[] cars = { '-' };
                string idStade = idStadeNomStade.Split(cars)[0];
                string nom = textBox1.Text;
                DateTime date = dateTimePicker1.Value;
                DBConnect dbc = new DBConnect();
                Fonction f = new Fonction();
                f.checkIfOccupied(dbc, date, idStade);
                f.insertEvenement(dbc, date, idStade, nom);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatResa sr = new StatResa();
            Evenement ev = evenement[comboBox1.SelectedIndex];
            sr.Ev = ev;
            sr.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
