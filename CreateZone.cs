using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stade
{
    public partial class CreateZone : Form
    {
        Stade stade;
        List<Point> listePointZone=new List<Point>();
        List<Zone> zone = new List<Zone>();
        string[] colors;
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

        public List<Point> ListePointZone
        {
            get
            {
                return listePointZone;
            }

            set
            {
                listePointZone = value;
            }
        }

        internal List<Zone> Zone
        {
            get
            {
                return zone;
            }

            set
            {
                zone = value;
            }
        }


        public CreateZone()
        {
            InitializeComponent();
            panel1.BackColor = Color.White;
            panel1.Click += new EventHandler(this.panelClick);
            string[] propList = Fonction.getAllColor();
            string[] selected = { "Red" };
            propList = Fonction.getColorNoSelected(propList, selected);
            colors = propList;
            foreach(string c in propList)
            {
                comboBox1.Items.Add(c);
            } 
        }
        private void panelClick(object senders,EventArgs e)
        {
            Point p = panel1.PointToClient(Cursor.Position);
            ListePointZone.Add(p);
            Fonction.drawPoint(panel1,p);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Zone[] z = Stade.Zone;
            if (z != null)
            {
                for (int i = 0; i < z.Length; i++)
                {
                    Point[] p = Fonction.convertCoordonnee(z[i].Coordonnee);
                    Fonction.drawFigure(panel1, p, z[i].Couleur);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            string coord = Stade.Coordonnee;
            Fonction.drawFigure(this.panel1, Fonction.convertCoordonnee(coord), "Red");
            Zone[] z = Stade.Zone;
            if (z != null)
            {
                for (int i = 0; i < z.Length; i++)
                {
                    Point[] p = Fonction.convertCoordonnee(z[i].Coordonnee);
                    Fonction.drawFigure(panel1, p,z[i].Couleur);
                }
            }
            
        }

        private void AfficherStade_Click(object sender, EventArgs e)
        {
            string coord = Stade.Coordonnee;
            Fonction.drawFigure(this.panel1, Fonction.convertCoordonnee(coord),"Red");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //recuperation inputs formulaire

                if (NomZone.Text.CompareTo("") == 0 || comboBox1.Text.CompareTo("")==0)
                {
                    throw new Exception("Completez tous les champs");
                }
                if (!Fonction.IsNumeric(textBox1.Text))
                {
                    throw new Exception("le numero de siege de depart doit etre un nombre");
                }
                if (!Fonction.IsNumeric(prixSiege.Text))
                {
                    throw new Exception("le prix de la siege doit etre un nombre");
                }
                string coord = Fonction.convertString(ListePointZone.ToArray<Point>());

                
               
                //Récuperer-na ny id anle stade misy anle zone
                String idStade = Stade.Id;
                // Tsy atao sequence ny id anle zone
                Fonction f = new Fonction();
                DBConnect dbc = new DBConnect();
                int idZonee = f.getId(dbc, "zone");
                string idZone = "Z" + idZonee;
                Zone temp = new Zone( idZone,NomZone.Text, comboBox1.Text, idStade, 0, coord, (Double)numericUpDown2.Value, (Double)numericUpDown1.Value, (Double)tailleSiege.Value, Int32.Parse(textBox1.Text),Double.Parse(prixSiege.Text));
                //ETO NO INSERER-NA NY ZONE 
                f.insertZone(dbc, temp);


                string[] colorSelected = { comboBox1.Text };
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                colors = Fonction.getColorNoSelected(colors, colorSelected);
                foreach (string c in colors)
                {
                    comboBox1.Items.Add(c);
                }
                Zone.Add(temp);
                NomZone.Text = "";
                Stade.Zone = Zone.ToArray<Zone>();
                ListePointZone.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (stade.Zone == null)
                {
                    throw new Exception("Creez une/des zone(s)");
                }
                AfficherStade aff = new AfficherStade();
                aff.Stade = Stade;
                aff.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tailleSiege_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
