using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    class Seza
    {
        string idSiege;
        String typeSeza;
        String coordonee;
        int numero;
        int reserve;


        public Seza(int numero,string coordonee,int reservation)
        {
            this.Numero = numero;
            this.Coordonee = coordonee;
            this.Reserve = reservation;
        }

        public Seza(string idSiege, int numero, int reserve)
        {
            this.idSiege = idSiege ?? throw new ArgumentNullException(nameof(idSiege));
            this.numero = numero;
            this.reserve = reserve;
        }

        public Seza(string typeSeza, string coordonee, int numero, int reserve)
        {
            this.typeSeza = typeSeza;
            this.Coordonee = coordonee;
            this.numero = numero;          
            this.reserve = reserve;
        }

        public int Numero { get => numero; set => numero = value; }
        public int Reserve { get => reserve; set => reserve = value; }
        public string TypeSeza { get => typeSeza; set => typeSeza = value; }
        public string Coordonee { get => coordonee; set => coordonee = value; }
        public string IdSiege { get => idSiege; set => idSiege = value; }
    }
}
