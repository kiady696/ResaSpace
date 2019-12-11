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
    public partial class ResaForm : Form
    {
        Stade stade;
        List<Evenement> events;
        List<Zone> zones;
        Zone[] zone;

        
        internal Stade Stade { get => stade; set => stade = value; }
        internal Zone[] Zone1 { get => zone; set => zone = value; }

        public ResaForm()
        {
            InitializeComponent();
        }

        private void ResaForm_Load(object sender, EventArgs e)
        {
            Fonction f = new Fonction();
            DBConnect dbc = new DBConnect();
            this.events = f.getAllEvenements(dbc);
            for (int j = 0; j < events.Count; j++) {
                ListeStade.Items.Add(events[j].Nom);
            }
            
            
           
           
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Evenement temp = events[ListeStade.SelectedIndex];
                DBConnect dbc = new DBConnect();
                Fonction f = new Fonction();
                List<Zone> zonesStade = f.getAllZones(dbc, temp.IdStade);

                for (int i = 0; i < zonesStade.Count; i++)
                {
                    ListeZoneDuStade.Items.Add(zonesStade[i].Designation);
                }
                this.zone = zonesStade.ToArray<Zone>();
                //generer-na ny liste des numeros de tous les sieges du stade
                List<Seza> sezas = f.getAllSeza(dbc, temp.IdStade);

                for (int i = 0; i < sezas.Count; i++)
                {
                    listeSiegeDelaZone1.Items.Add(sezas[i].Numero);
                    listeSiegeDeLaZone2.Items.Add(sezas[i].Numero);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReserverAction_Click(object sender, EventArgs e)
        {
            //mapiditra ligne ray anaty reservation
            //creer table reservationDate(nbResaVitaReetra,datePrecise)
            //ny length anle place nreserver-na no apdirna amle reservationDate

            //recuperer donnees 
            try
            {
                string idEvent = this.events[ListeStade.SelectedIndex].Id;
                string idStade = this.events[ListeZoneDuStade.SelectedIndex].IdStade;
                string idZone = this.zone[ListeZoneDuStade.SelectedIndex].Id;
                string numSiege1 = listeSiegeDelaZone1.Text;
                string numSiege2 = listeSiegeDeLaZone2.Text;
                Fonction f = new Fonction();
                String[] sgs = f.getSieges( numSiege1, numSiege2);
                DateTime date = dateTimePicker1.Value;
                DBConnect dbc = new DBConnect();
                f.insertReservation(dbc,idStade,idZone,sgs,date,idEvent);
                   

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
