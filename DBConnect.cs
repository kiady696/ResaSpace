using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stade
{
    public class DBConnect
    {
        public SqlConnection createConnection(){
            SqlConnection con = null ;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIADY\Documents\S5\Ratah Arch Log\Projet Place\stade\stade\stade.mdf;Integrated Security=True";
            con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection sqlcon;
    public SqlDataReader DataReader(string query)
        {
            SqlCommand com = new SqlCommand(query, sqlcon);
            SqlDataReader sdr = com.ExecuteReader();
            return sdr;
        }



        
    }
}
