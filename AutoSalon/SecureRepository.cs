using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AutoSalon
{
    public class SecureRepository
    {
        public static Roles GetUser(String login, String password)
        {
            Roles userTbl = null;

            string commPart =
                "SELECT * " +
                " FROM \"public\".\"users\"" +
                " WHERE \"login\" = @login AND \"password\" = @password;";


            NpgsqlCommand command = new NpgsqlCommand(commPart, DBConnection.getConn);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            NpgsqlDataReader readerUserTable = command.ExecuteReader();

            foreach (DbDataRecord dbDataRecord in readerUserTable)
            {
                userTbl = new Roles(
                    Convert.ToInt32(dbDataRecord["id_users"].ToString()),
                    dbDataRecord["login"].ToString(),
                    dbDataRecord["password"].ToString(),
                    dbDataRecord["roles"].ToString(),
                    dbDataRecord["passwordbd"].ToString()
                        );
                break;
            }
            readerUserTable.Close();
            return userTbl;
        }
    }
}
