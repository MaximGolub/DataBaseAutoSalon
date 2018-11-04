using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace AutoSalon
{
    public class DBConnection
    {
        private static string connParam;
        private static NpgsqlConnection conn;

        public static void setConnection(String server, String port, String userId, String password, String database)
        {
            connParam = "Server=" + server + "; Port=" + port + "; User Id=" + userId + "; Password=" + password + "; Database=" + database + ";";
            conn = new NpgsqlConnection(connParam);
        }

        public static void setConnection(NpgsqlConnection connection)
        {
            conn = connection;
        }

        public static NpgsqlConnection getConn => conn;

        public static void openConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public static void closeConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
    }
}
