using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stade
{
    class Fonction
    {
        public static object[] select(SqlConnection c, string table, string sep, string[] where)
        {
            string sql="select * from "+table;
            string tab = table.ToUpper();
            SqlCommand command = new SqlCommand("select column_name from user_tab_columns where table_name='" + tab + "'", c);
            SqlDataReader dataReader = command.ExecuteReader();
             int nb = 0;
		    while(dataReader.Read())
            {
			    nb++;
		    }
            if (where != null)
            {
                sql = sql + " where ";
            }
			for(int i = 0; i<where.Length;i++)
            {
				if(sep!=null)
                {
					sql=sql+where[i]+" "+sep+" ";
				}
				else
                {
					sql=sql+where[i];
				}
			}
			if(sep!=null)
            { 
				sql=sql.Substring(0,sql.Length-(sep.Length+2));
			}
            dataReader.Close();
            command.Dispose();
            string maj = table.Substring(0, 1);
            maj=maj.ToUpper();
		    string tableMaj = maj + table.Substring(1, table.Length);
            Type cl = Type.GetType(table + "." + tableMaj);
            SqlCommand command2 = new SqlCommand(sql, c);
            SqlDataReader dataReader2 = command.ExecuteReader();
            List<object> result = new List<object>();
		    object[] arg = new Object[nb];
            Type[] param = new Type[nb];
		    while(dataReader2.Read())
            {
			    for(int i = 0; i<nb;i++)
                {
                    if (dataReader2.GetValue(i) is string)
                    {
                        arg[i] = (string)dataReader2.GetValue(i);
                    }
                    else
                    {
                        arg[i] = (double)dataReader2.GetValue(i);
                    }
                    param[i]=arg[i].GetType();
                }
                ConstructorInfo cons = cl.GetConstructor(param);
                result.Add(cons.Invoke(arg));
            }
            return result.ToArray();
         }

        public static void drawPoint(Panel panel,Point p)
        {
            Graphics g = panel.CreateGraphics();
            Brush brush = (Brush)Brushes.Red;
            g.FillRectangle(brush, p.X, p.Y, 5, 5);
        }

        public static String deconvertCoordonnee(Point[] pointsDuSiege)
        {
            String res = "" + pointsDuSiege[0].X + ";" + pointsDuSiege[0].Y;
            return res;
        }

        public string getNextval(string nomSequence,DBConnect dbc)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            String nextId = "";
            try
            {
                con.Open();
                String queryString = "Select next value for " + nomSequence;
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    nextId = ""+read.GetValue(0);
                }


            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
            return nextId;
        }

        public static bool IsNumeric(string Nombre)
        {
            try
            {
                int.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void insertNbReservation(DBConnect dbc,DateTime date)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            SqlTransaction transac = null;
            try
            {
                con.Open();
                transac = con.BeginTransaction();
                Fonction f = new Fonction();


                String queryString = "INSERT INTO NbReservation(id,nb,date) VALUES ('" + f.getNextval("sequenceNbEvenement", dbc) + "', 0 ,@date)";
                SqlCommand com = new SqlCommand(queryString, con, transac);
                com.Parameters.AddWithValue("@date", date);
                com.ExecuteNonQuery();
                transac.Commit();



            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }

        public void insertEvenement(DBConnect dbc,DateTime date,string idStade,string nomEvent)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            SqlTransaction transac = null;
            try
            {
                con.Open();
                transac = con.BeginTransaction();
                Fonction f = new Fonction();
               
                    
                    String queryString = "INSERT INTO evenement(id,idStade,date,nom) VALUES ('" + f.getNextval("sequenceEvenement", dbc) + "','" + idStade + "',@date,'" +nomEvent+ "')";
                    SqlCommand com = new SqlCommand(queryString, con, transac);
                    com.Parameters.AddWithValue("@date", date);
                    com.ExecuteNonQuery();
                    transac.Commit();



            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }

        public void checkIfOccupied(DBConnect dbc, DateTime date,String idStade)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
           
            try
            {
                con.Open();
                String queryString = "SELECT * from Evenement WHERE idstade=+'"+idStade+ "' AND date=@date";
                SqlCommand com = new SqlCommand(queryString, con);
                com.Parameters.AddWithValue("@date", date);
                read = com.ExecuteReader();
               
                
                if (read.Read())
                {
                    throw new Exception("ce stade fait deja partie d'un evenement aujourd'hui");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }

        public String[] getSieges(string num1,string num2)
        {

            String[] res = null;
            try
            {
                int numm1 = Int32.Parse(num1);
                int numm2 = Int32.Parse(num2);
                
                if (numm1 > numm2)
                {
                    throw new Exception("numero sieges invalides desordonnee");
                }
                res = new String[numm2 - numm1+1];
                for (int i = 0;i<=numm2 - numm1; i++)
                {
                    res[i] = "" + (i+numm1);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
          

            return res;

        }

        public void filtrer(List<Media> medss, string idEvent)
        {
            for(int i = 0; i < medss.Count; i++)
            {
                if (medss[i].IdEvent.CompareTo(idEvent) != 0)
                {
                    medss.Remove(medss[i]);
                    i--;
                }


            }
        }

        public void getLinkMediaGraph(List<Media> medias, List<Evenement> events)
        {
            for(int i = 0; i < medias.Count; i++)
            {
                for(int j = 0; j < events.Count; j++)
                {
                    if((medias[i].Date_pub - events[j].Date).Days == 0)
                    {
                        int c = 0;
                        if (j > 0)
                        {
                            c = events[j].Nb - events[j-1].Nb;
                        }
                        else
                        {
                            c = events[j].Nb;
                        }
                        medias[i].Point = c;
                    }
                }
            }
        } 

        public Media[] rankMedia(List<Media> medias)
        {
            Media[] res = medias.ToArray();
            for(int i = 0; i < res.Length; i++)
            {
                for(int j = i; j < res.Length; j++)
                {
                    if (res[i].Point < res[j].Point)
                    {
                        Media temp = res[i];
                        res[i] = res[j];
                        res[j] = temp;
                    }

                }
            }
            return res;
        }

        public List<Media> getMedias_Pub(DBConnect dbc)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Media> zones = new List<Media>();
            try
            {
                con.Open();
                String queryString = "SELECT media.id,media.nom,media_pub.datepub,media_pub.idevent from Media_pub JOIN Media ON media.id=media_pub.idMedia";
                SqlCommand com = new SqlCommand(queryString, con);
               
                read = com.ExecuteReader();
                int cumul = 0;
                while (read.Read())
                {
                    zones.Add(new Media(read.GetString(0), read.GetString(1), 0, read.GetDateTime(2),read.GetString(3)));


                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return zones;
        }

        public List<Evenement> getStats(DBConnect dbc,string idEvent)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Evenement> zones = new List<Evenement>();
            try
            {
                con.Open();
                String queryString = "SELECT * from NBreservation where idevent='" + idEvent + "' ORDER BY date ASC";
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                int cumul = 0;
                while (read.Read())
                {
                    Evenement z = new Evenement();
                    z.Nb =cumul+ read.GetInt32(1);
                    z.Date = read.GetDateTime(2);
                    zones.Add(z);
                    cumul = z.Nb;

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return zones;
        }

        public List<Seza> getAllSeza(DBConnect dbc, string idStade)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Seza> zones = new List<Seza>();
            try
            {
                con.Open();
                String queryString = "SELECT * from vueSiegesDuStade where idStade='" + idStade + "'";
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    Seza z = new Seza(read.GetString(0), read.GetInt32(1), read.GetInt32(2));
                    zones.Add(z);

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return zones;
        }

        public List<Evenement> getAllEvenements(DBConnect dbc)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Evenement> stades = new List<Evenement>();
            try
            {
                con.Open();
                String queryString = "SELECT * from Evenement ORDER BY id DESC";
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    stades.Add(new Evenement(read.GetString(0),read.GetString(1),read.GetDateTime(2),read.GetString(3)));

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return stades;
        }

        public List<Stade> getAllStades(DBConnect dbc)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Stade> stades = new List<Stade>();
            try
            {
                con.Open();
                String queryString = "SELECT * from Stade ORDER BY id DESC";
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    stades.Add(new Stade(read.GetString(0),read.GetString(1),read.GetDouble(2),read.GetString(3) ));

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return stades;
        }


        public List<Zone> getAllZones(DBConnect dbc,string idStade)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            List<Zone> zones = new List<Zone>();
            try
            {
                con.Open();
                String queryString = "SELECT * from Zone where idStade='"+idStade+"'";
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    Zone z = new Zone(read.GetString(0), read.GetString(1), read.GetString(2), read.GetDouble(3), read.GetString(4), read.GetDouble(5), read.GetDouble(6), (int)(read.GetDecimal(7)), read.GetDouble(8));
                    zones.Add(z);

                }

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return zones;
        }

        public void insertZone(DBConnect dbc, Zone zone)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            try
            {
                con.Open();
                String queryString = "INSERT INTO zone(id,designation,idStade,nbPlace,coordonnee,espacementcote,espacementhaut,numeroSiegeDepart,prixsiege) VALUES ('" + zone.Id + "','" + zone.Designation + "','" + zone.IdStade + "'," + zone.NbPlace + ",'"+zone.Coordonnee+"',"+zone.EspacementCote+","+zone.EspacementHaut+","+zone.NumDepart+","+zone.PrixSiege+")";
                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

        }

        public void insertStade(DBConnect dbc,Stade stade)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            try
            {
                con.Open();
                String queryString = "INSERT INTO stade(id,nom,nbPlace,coordonee) VALUES ('" + stade.Id+ "','" + stade.Nom + "'," + stade.NbPlace + ",'" + stade.Coordonnee + "')";
                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }



        public void insertReservation(DBConnect dbc,string idStade,string idZone,String[] sieges,DateTime date,string idEvent)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            SqlTransaction transac = null;
            try
            {
                //Boolean check = checkSiege(sieges, dbc,idEvent);
                con.Open();
                transac = con.BeginTransaction();
                Fonction f = new Fonction();
                for (int i = 0; i < sieges.Length; i++)
                {
                    String numSiege = sieges[i];
                    String queryString = "INSERT INTO Reservation(id,datereservation,idzone,idStade,numeroSiege,idEvent) VALUES ('" + f.getNextval("sequenceReservation", dbc) + "',@date,'" + idZone + "','" + idStade + "','"+sieges[i]+"','"+idEvent+"')";
                    SqlCommand comm = new SqlCommand(queryString, con, transac);
                    comm.Parameters.AddWithValue("@date", date);
                    comm.ExecuteNonQuery();

                }
                string query2 = "Insert into NbReservation(id,nb,date,idEvent) VALUES('" + f.getNextval("sequenceNbReservation", dbc) + "'," + sieges.Length + ",@date,'" + idEvent + "')";
                SqlCommand com = new SqlCommand(query2, con, transac);
                com.Parameters.AddWithValue("@date", date);
                com.ExecuteNonQuery();
                transac.Commit();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }

        public void insertSeza(DBConnect dbc,List<Seza> sieges,String idZone)
        {
            SqlDataReader read = null;
            SqlConnection con = dbc.createConnection();
            SqlTransaction transac = null;
            try
            {
                con.Open();
                transac = con.BeginTransaction();
                Fonction f  = new Fonction();
                for (int i = 0; i < sieges.Count; i++)
                {
                    Seza siege = sieges[i];
                    String queryString = "INSERT INTO Siege(idSiege,numero,coordonnee,reservation,idZone) VALUES ('" + f.getNextval("sequenceSiege", dbc) + "'," + siege.Numero + ",'" + siege.Coordonee + "',0,'" + idZone + "')";
                    SqlCommand com = new SqlCommand(queryString, con, transac);
                    com.ExecuteNonQuery();

                }
                transac.Commit();

            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }

      

        public int getId(DBConnect dbc,String nomTable)
        {
            SqlDataReader read = null;
            
            SqlConnection con = dbc.createConnection();
            int nbSiege = 0;

            try
            {
                con.Open();
                String queryString = "SELECT COUNT(*) from "+nomTable;
                SqlCommand com = new SqlCommand(queryString, con);
                read = com.ExecuteReader();
                while (read.Read())
                {
                    nbSiege = read.GetInt32(0);
                }

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
            return nbSiege;
        }

        public static void insertSeza(Point[] siegePoints,String numSiege)
        {
            String coord = deconvertCoordonnee(siegePoints);
            //String queryString = "INSERT INTO SIEGE(IdSiege,numero,coordonnee,reservation) VALUES (,"+numSiege+","+coord+",0);
        }

        public static void drawSeza(Panel panel,Point[] p,string couleur, String numStr)
        {
            Graphics g = panel.CreateGraphics();
            Color c = Color.FromName(couleur);
            Pen brush = new Pen(c);
            g.DrawPolygon(brush, p);
            g.DrawString(numStr, new Font("Arial", 10), Brushes.Black, new PointF(p[2].X, p[0].Y));

        }

        public static void drawFigure(Panel panel, Point[] p,string couleur)
        {
            Graphics g = panel.CreateGraphics();
            Color c = Color.FromName(couleur);
            Pen brush = new Pen(c);
            g.DrawPolygon(brush, p);
        }

        public static Point[] convertCoordonnee(String coord)
        {
            string[] points = coord.Split(';');
            List<Point> result = new List<Point>();
            for(int i = 0; i < points.Length; i++)
            {
                string[] temp = points[i].Split(',');
                Point temp2 = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
                result.Add(temp2);
            }
            return result.ToArray<Point>();
        }

        public static string convertString(Point[] coord)
        {
            string result = "";
            for (int i = 0; i < coord.Length; i++)
            {
                result += coord[i].X + "," + coord[i].Y + ";";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public static Point[] createRectangle(Point[] p)
        {
            Point A, B, C, D, temp1,temp2,temp3;
            var start = from x in p orderby x.Y descending select x ;
            A = start.ElementAt<Point>(0);
            var start2 = from x in p orderby x.X ascending select x;
            temp1 = start2.ElementAt<Point>(0);
            B = new Point(temp1.X, A.Y);
            var start3 = from x in p orderby x.Y ascending select x;
            temp2 = start3.ElementAt<Point>(0);
            C = new Point(B.X, temp2.Y);
            var start4 = from x in p orderby x.X descending select x;
            temp3 = start4.ElementAt<Point>(0);
            D = new Point(temp3.X, C.Y);
            A.X = D.X;
            A.Y = B.Y;
            Point[] result = { A, B, C, D };
            return result;
        }

        public static string[] getAllColor()
        {
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] proplist = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            var list = from x in proplist select x.Name;
            return list.ToArray<string>();
        }

        public static string[] getColorNoSelected(string[] colors,string[] selected)
        {
            List<string> newColors = new List<string>();
            for(int i = 0; i < colors.Length; i++)
            {
                int check = 0;
                for(int v = 0; v < selected.Length; v++)
                {
                    if (colors[i].CompareTo(selected[v]) == 0)
                    {
                        check = 1;
                        break;
                    }
                }
                if (check == 0)
                {
                    newColors.Add(colors[i]);
                }
            }
            return newColors.ToArray<string>();
        }
    }
}
