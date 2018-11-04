using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AutoSalon
{
    public class LoginPass
    {   
        public bool Login(String login, String password)
        {

            if (!Connect())
            {
                return false;
            }
            Roles user;
            try
            {
                user = SecureRepository.GetUser(login, Cryptography.MD5(password).ToLower());
            }
            catch (Exception exp)
            {
                throw exp;
            }
            if (user == null)
            {
                return false;
            }

            string db_name = user.roles;
            string db_password = user.password;//Cryptography.MD5(user.passwordbd);
            
            CurrentUser.set(user.id_users, user.login, password, user.roles, user.passwordbd);
            
            return Reconnect(db_name, db_password);
        }

        private bool Reconnect(string db_name, string db_password)
        {
            if (DBConnection.getConn != null)
                DBConnection.closeConnection();
            try
            {
                string connection = "Server=127.0.0.1;User Id='" + db_name + "';Password='" + db_password + "';database=Autosalon;";
                NpgsqlConnection conn = new NpgsqlConnection(connection);
                DBConnection.setConnection(conn);
                DBConnection.openConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private bool Connect()
        {
            if (DBConnection.getConn != null)
                DBConnection.closeConnection();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=auto_users;Password=827ccb0eea8a706c4c34a16891f84e7b;database=Auth;");
                DBConnection.setConnection(conn);
                DBConnection.openConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
