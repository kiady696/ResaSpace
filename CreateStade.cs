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
    public partial class CreateStade : Form
    {
        List<Point> listePoint = new List<Point>();
        public CreateStade()
        {
            InitializeComponent();
            panel1.Click += new EventHandler(this.panelClick);
            panel1.BackColor = Color.White;
        }
        private void panelClick(object senders, EventArgs e)
        {
            Point p = panel1.PointToClient(Cursor.Position);
            listePoint.Add(p);
            Fonction.drawPoint(this.panel1, p);
        }

        private void Visualiser_Click(object sender, EventArgs e)
        {
            Fonction.drawFigure(this.panel1, listePoint.ToArray<Point>(),"Red");
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            listePoint.Clear();
        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            try
            {
                if (listePoint.Count <= 2)
                {
                    throw new Exception("points insuffisants");
                }
                if (NomStade.Text.CompareTo("") == 0)
                {
                    throw new Exception("Ajoutez un nom au stade !");
                }
                // IGENERER-NA ID ILAY STADE
                Fonction F = new Fonction();
                DBConnect dbc = new DBConnect();
                int idStadee = F.getId(dbc, "stade");
                string idStade = "STADE" + idStadee;
                Stade stade = new Stade(idStade,NomStade.Text,0,Fonction.convertString(listePoint.ToArray<Point>()));
                //   ETO N MI-INSERER ANLE STADE 
                F.insertStade(dbc, stade);



                CreateZone cz = new CreateZone();
                cz.Stade = stade;
                cz.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
