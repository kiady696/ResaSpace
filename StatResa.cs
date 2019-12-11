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
    public partial class StatResa : Form
    {
        Evenement ev;

        public StatResa()
        {
            InitializeComponent();
        }

        internal Evenement Ev { get => ev; set => ev = value; }

        private void StatResa_Load(object sender, EventArgs e)
        {
            

            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idEvent = ev.Id;
            DBConnect dbc = new DBConnect();
            Fonction f = new Fonction();


            //SUIVANT L'AXE Y EFA METY TSISY BLEM
            List<Evenement> statsCumules = f.getStats(dbc, idEvent);        
            int[] y = new int[statsCumules.Count];
            for (int i = 0; i < statsCumules.Count;i++)
            {
                y[i] = statsCumules[i].Nb;
            }
                
            //SUIVANT L'AXE X EFA TSISY BLEM
            List<Media> mediasPublies = null;
            for (int k = 0; k < statsCumules.Count; k++) {
                mediasPublies = f.getMedias_Pub(dbc); //maka ny medias reetra efa publiés 
            }
            f.filtrer(mediasPublies, idEvent);      //Ze mediaspubliés tamty evenement ty iany omena
            f.getLinkMediaGraph(mediasPublies, statsCumules);   //Liena amle graph le media ( jerena ny date ) MBOLA MISY BLEM 
            Media[] ed = f.rankMedia(mediasPublies); 


            string[] x = new string[statsCumules.Count];
            for (int j = 0; j < statsCumules.Count; j++)
            {
                x[j] = statsCumules[j].Date.ToString();
                for(int h = 0; h < mediasPublies.Count; h++)
                {
                    if((statsCumules[j].Date - mediasPublies[h].Date_pub).Days == 0)
                    {
                        //MISY DISO
                        x[j] = statsCumules[j].Date.ToString()+" media:"+mediasPublies[h].Nom;
                    }
                }
            }
            chart1.Series[0].Points.DataBindXY(x, y);
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Classement";
            dataGridView1.Columns[1].Name = "nom Media";
            dataGridView1.Columns[2].Name = "cumul";
            dataGridView1.Rows.Clear();
            int compt = 1;
            foreach(Media med in mediasPublies)
            {
                //MISY DISO
                string[] meds = { "" + compt, med.Nom ,med.Point +""};
                dataGridView1.Rows.Add(meds);
                compt++;
            }
            


        }
    }
}
