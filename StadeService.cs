using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stade
{
    class StadeService
    {
        public static Stade getStade(SqlConnection c,String id)
        {
            String sql = "SELECT * FROM stadeClass WHERE idStade='" + id + "'";
            SqlCommand command = new SqlCommand(sql, c);
            SqlDataReader dataReader = command.ExecuteReader();
            Stade resultat = null;
            List<Zone> zone = new List<Zone>();
            while (dataReader.Read())
            {
                resultat = new Stade((string)dataReader.GetValue(0), (string)dataReader.GetValue(1), (double)dataReader.GetValue(2), (string)dataReader.GetValue(3));
                zone.Add(new Zone((string)dataReader.GetValue(4),(string)dataReader.GetValue(0), (string)dataReader.GetValue(5), (double)dataReader.GetValue(6), (string)dataReader.GetValue(7))); 
             }
            resultat.Zone = zone.ToArray<Zone>();
            dataReader.Close();
            command.Dispose();
            return resultat;
        }
        public static Stade[] getAllStade(SqlConnection c)
        {
            object[] result = Fonction.select(c, "stade", null, null);
            Stade[] reponse = new Stade[result.Length];
            for(int i=0; i < result.Length; i++)
            {
                reponse[i] = (Stade)result[i];
            }
            return reponse;
        }

        public static void addPlaceVerticalementNormale(Panel panel, Zone z)
        {
            Point[] polygon = Fonction.convertCoordonnee(z.Coordonnee);
            Point[] rectangle = Fonction.createRectangle(polygon); //le rectangle mcontenir anle polygone 
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygon);
            int indexFin = 0;
            int index = 2;
            int limiteBody = rectangle[1].Y;

            int x = rectangle[index].X;
            int y = rectangle[index].Y;
            //

            int nbPlace = 0;
            while (x < rectangle[indexFin].X && y < rectangle[indexFin].Y)
            {
                y += (int)z.EspacementHaut;
                
                Point A, B, C, D; //coins anle sieges
                A = new Point(x, y);
                x += 1;
                B = new Point(x, y);
                C = new Point(x, B.Y + 5);
                D = new Point(x - 5, y + 5);
                Point[] place = { A, B, C, D };
                if (path.IsVisible(A) && path.IsVisible(B) && path.IsVisible(C) && path.IsVisible(D))
                {

                    Fonction.drawFigure(panel, place, "Red");
                    nbPlace++;
                   
                    
                }

                if (y >= limiteBody)
                {
                    y = rectangle[index].Y;
                    x += (int)z.EspacementCote;

                }
            }
            z.NbPlace = nbPlace;
        }

        public static void addPlaceHorizontalementInverse(Panel panel,Zone z)
        {
            Point[] polygon = Fonction.convertCoordonnee(z.Coordonnee);
            Point[] rectangle = Fonction.createRectangle(polygon); //le rectangle mcontenir anle polygone 
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygon);
            int indexFin = 1;
            int index = 3;
            int limiteBody = rectangle[2].X;

                int x = rectangle[index].X;
                int y = rectangle[index].Y;
                //maka ny coin anakroa meme coté (tsy opposé)

                int nbPlace = z.NumDepart; //atao numero depart
            z.Sieges = new List<Seza>();
                while (x > rectangle[indexFin].X && y < rectangle[indexFin].Y)
                {
                    x -= (int)z.EspacementCote;
                    Point A, B, C, D; //coins anle sieges
                    A = new Point(x, y);
                    x -=(int) z.TailleSeza;
                    B = new Point(x, y);
                    C = new Point(x,B.Y + (int)z.TailleSeza);
                    D = new Point(x + (int)z.TailleSeza, y + (int)z.TailleSeza);
                    Point[] place = { A, B, C, D };
                String numStr = ""+ nbPlace;
                    if (path.IsVisible(A) && path.IsVisible(B) && path.IsVisible(C) && path.IsVisible(D))
                    {
                        
                        Seza temp = new Seza(nbPlace,Fonction.convertString(place),0);
                        z.Sieges.Add(temp);
                        

                         Fonction.drawSeza(panel, place, "Red",numStr);
                           nbPlace++;
                        
                    
                    }

                    if (x <= limiteBody)
                    {
                        x = rectangle[index].X;
                    y += (int)z.EspacementHaut + (int)z.TailleSeza;
                        ;
                   
                    }
                }
            //ETO NO MI-INSERT NY SEZA reetra anle zone ANATY BASE (VITA)
            Fonction f = new Fonction();
            DBConnect dbc = new DBConnect();
            f.insertSeza(dbc, z.Sieges, z.Id);
            z.NbPlace = nbPlace;
            }
        



        public static void addPlace(Panel panel, Zone z)
        {
             
            Point[] polygon = Fonction.convertCoordonnee(z.Coordonnee);
            Point[] rectangle = Fonction.createRectangle(polygon); //le rectangle mcontenir anle polygone 
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygon);
            int index = 0;
            Point temp = rectangle[index];
            //mitady anle coins anaky telo amle rectangle conteneur du polygone
            for (int i = 1; i < rectangle.Length; i++)// tetezina le points zoronle rectangle
            {
                if (rectangle[i].X < temp.X && rectangle[i].Y < temp.Y) //?
                {
                    index = i; //
                }
            }
            int indexFin = index + 2;
            if (indexFin > 3)
            {
                indexFin = indexFin - 4;
            }
            int indexMil = indexFin - 1;
            if (indexMil < 0)
            {
                indexMil = 3;
            }
            int x = rectangle[index].X;
            int y = rectangle[index].Y;
            //maka ny coin anakroa meme coté (tsy opposé)

            int nbPlace = 0;
            while (x < rectangle[indexFin].X && y < rectangle[indexFin].Y)
            {
                x += (int)z.EspacementCote;
                Point A, B, C, D; //coins anle sieges
                A = new Point(x, y);
                x += 5;
                B = new Point(x, y);
                C = new Point(x, B.Y + 5);
                D = new Point(x - 5, y + 5);
                Point[] place = { A, B, C, D };
                if (path.IsVisible(A) && path.IsVisible(B) && path.IsVisible(C) && path.IsVisible(D))
                {

                    Fonction.drawFigure(panel, place, "Red");
                    nbPlace++;
                }

                if (x >= rectangle[indexMil].X)
                {
                    x = rectangle[index].X;
                    y += (int)z.EspacementHaut + 5;
                }
            }
            z.NbPlace = nbPlace;
        }
        
    }
}
