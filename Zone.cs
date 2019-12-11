using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    class Zone
    {
        String id;
        String designation;
        string couleur;
        String idStade;
        double nbPlace;
        String coordonnee;
        double espacementCote;
        double espacementHaut;
        double tailleSeza;
        int numDepart;
        double prixSiege;
        List<Seza> sieges;

        

        public Zone(string designation,string coord,string couleur,double tailleSeza,double espaceCote,double espaceHaut,int numDep,String idZone)
        {
            this.designation = designation;
            this.coordonnee = coord;
            this.couleur = couleur;
            this.tailleSeza = tailleSeza;
            this.espacementCote = espaceCote;
            this.espacementHaut = espaceHaut;
            this.NumDepart = numDep;
            this.id = idZone;
        }
        public Zone(string id, string designation, string idStade, double nbPlace, string coordonnee)
        {
            this.id = id;
            this.designation = designation;
            this.idStade = idStade;
            this.nbPlace = nbPlace;
            this.coordonnee = coordonnee;
        }

        public Zone(string id, string designation, string couleur, string idStade, double nbPlace, string coordonnee, double espacementCote, double espacementHaut, double tailleSeza, int numDepart,double prixSiege)
        {
            this.id = id ?? throw new ArgumentNullException(nameof(designation));
            this.designation = designation ?? throw new ArgumentNullException(nameof(designation));
            this.couleur = couleur ?? throw new ArgumentNullException(nameof(couleur));
            this.idStade = idStade ?? throw new ArgumentNullException(nameof(idStade));
            this.nbPlace = nbPlace;
            this.coordonnee = coordonnee ?? throw new ArgumentNullException(nameof(coordonnee));
            this.espacementCote = espacementCote;
            this.espacementHaut = espacementHaut;
            this.tailleSeza = tailleSeza;
            this.numDepart = numDepart;
            this.prixSiege = prixSiege;
        }

        public Zone(string id, string designation, string idStade, double nbPlace, string coordonnee, double espacementCote, double espacementHaut, int numDepart, double prixSiege) : this(id, designation, idStade, nbPlace, coordonnee)
        {
            
            EspacementCote = espacementCote;
            EspacementHaut = espacementHaut;
            NumDepart = numDepart;
            PrixSiege = prixSiege;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }

        public string IdStade
        {
            get
            {
                return idStade;
            }

            set
            {
                idStade = value;
            }
        }

        public double NbPlace
        {
            get
            {
                return nbPlace;
            }

            set
            {
                nbPlace = value;
            }
        }

        public string Coordonnee
        {
            get
            {
                return coordonnee;
            }

            set
            {
                coordonnee = value;
            }
        }

        public double EspacementCote
        {
            get
            {
                return espacementCote;
            }

            set
            {
                espacementCote = value;
            }
        }

        public double EspacementHaut
        {
            get
            {
                return espacementHaut;
            }

            set
            {
                espacementHaut = value;
            }
        }

        public string Couleur
        {
            get
            {
                return couleur;
            }

            set
            {
                couleur = value;
            }
        }

        public double TailleSeza { get => tailleSeza; set => tailleSeza = value; }
        public int NumDepart { get => numDepart; set => numDepart = value; }
        internal List<Seza> Sieges { get => sieges; set => sieges = value; }
        public double PrixSiege { get => prixSiege; set => prixSiege = value; }
    }
}
