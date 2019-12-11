using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    class Evenement
    {
        string id;
        string idStade;
        DateTime date;
        string nom;
        int nb;

        public Evenement() { }

        public Evenement(string id, string idStade, DateTime date, string nom)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.IdStade = idStade ?? throw new ArgumentNullException(nameof(idStade));
            this.Date = date;
            this.Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        }

        public Evenement(string id, string idStade, DateTime date, string nom, int nb) : this(id, idStade, date, nom)
        {
            this.nb = nb;
        }

        public string Id { get => id; set => id = value; }
        public string IdStade { get => idStade; set => idStade = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Nb { get => nb; set => nb = value; }
    }
}
