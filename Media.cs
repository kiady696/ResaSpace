using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    class Media
    {
        string id;
        string nom;
        double prix;
        DateTime date_pub;
        int point;
        string idEvent;

public Media(string id, string nom, double prix, DateTime date_pub,string idEvent )
        {
            this.id = id ?? throw new ArgumentNullException(nameof(id));
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prix = prix;
            this.date_pub = date_pub;
            this.idEvent = idEvent;
           
        }

        public double Prix { get => prix; set => prix = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Id { get => id; set => id = value; }
        public DateTime Date_pub { get => date_pub; set => date_pub = value; }
        public int Point { get => point; set => point = value; }
        public string IdEvent { get => idEvent; set => idEvent = value; }
    }
}
