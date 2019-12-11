using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    class Stade
    {
        string id;
        String nom;
        double nbPlace;
        String coordonnee;
        Zone[] zone;

        public Stade(string id, string nom, double nbPlace, string coordonnee)
        {
            this.id = id;
            this.nom = nom;
            this.nbPlace = nbPlace;
            this.coordonnee = coordonnee;
        }

        public Stade(string nom,string coordonne)
        {
            this.nom = nom;
            this.Coordonnee = coordonne;
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

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
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

        internal Zone[] Zone
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
    }
}
