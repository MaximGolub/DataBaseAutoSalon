using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

namespace AutoSalon
{
    public class ClientModel
    {
        public DataTable Conn(string quer)
        {
            string connectionString = "Server='localhost';Port='5432';User='clients';Password='827ccb0eea8a706c4c34a16891f84e7b';Database='Autosalon';";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(quer, npgSqlConnection);
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            adapter.Fill(table);
            npgSqlConnection.Close();
            return table;
        }

        public DataTable ShowAuto()
        {
            return Conn("SELECT car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier_id, transmission, typebody, typecar, year FROM car WHERE car_id NOT IN(SELECT sale.car_id FROM sale) ORDER BY car_id");
        }
    }
}