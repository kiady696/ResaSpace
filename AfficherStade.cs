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
    public partial class AfficherStade : Form
    {
        Stade stade;
        public AfficherStade()
        {
            InitializeComponent();
            panel1.BackColor = Color.White;
            //mtest ny database kely loa
            DBConnect dbc = new DBConnect();
            Fonction F = new Fonction();
            int nbSiegeactuelle = F.getId(dbc,"Siege");
            textBox1.Text = ""+ nbSiegeactuelle;
        }

        internal Stade Stade
        {
            get
            {
                return stade;
            }

            set
            {
                stade = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Nom du stade : " + Stade.Nom;
            Point[] coord = Fonction.convertCoordonnee(Stade.Coordonnee);
            Fonction.drawFigure(panel1, coord,"Red");
            Zone[] z = Stade.Zone;
            for (int i = 0; i < z.Length; i++)
            {
                Point[] p = Fonction.convertCoordonnee(z[i].Coordonnee);
                Fonction.drawFigure(panel1, p,z[i].Couleur);
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = z[i].Designation;
                row.Cells[1].Style.BackColor = Color.FromName(z[i].Couleur);
                dataGridView1.Rows.Add(row);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zone[] zone = Stade.Zone;
            for(int i = 0; i < zone.Length; i++)
            {
                // mila igénerena id tsirairay avy le zone 
                StadeService.addPlaceHorizontalementInverse(panel1, zone[i]);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResaForm rf = new ResaForm();
            rf.Stade = Stade;
            rf.Zone1 = Stade.Zone; 
            rf.Show();
        }
    }
}
