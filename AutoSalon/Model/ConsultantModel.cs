using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace AutoSalon.Model
{
    public class ConsultantModel
    {   
        public DataTable Conn(string quer)
        {
            string connectionString = "Server='localhost';Port='5432';User Id='director';Password='0a06eb93b7d29e8d9b1891eec932ba2a';Database='Autosalon';";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(quer, npgSqlConnection);
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            adapter.Fill(table);
            npgSqlConnection.Close();

            return table;
        }

        public DataTable ShowIdAuto(int car_id)
        {
            return Conn("SELECT car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier_id, transmission, typebody, typecar, year FROM car WHERE car_id = '" + car_id + "' AND car_id NOT IN(SELECT sale.car_id FROM sale) ORDER BY car_id");
        }

        public DataTable ShowAuto()
        {
            return Conn("SELECT car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier_id, transmission, typebody, typecar, year FROM car WHERE car_id NOT IN(SELECT sale.car_id FROM sale) ORDER BY car_id");
        }

        public DataTable ShowSale()
        {
            return Conn("SELECT sale_id, vin, marka, model, datesale, formpayment, payment, employee.surname, employee.name, client.surname, client.name FROM sale " +
                "INNER JOIN car ON sale.car_id = car.car_id " +
                "INNER JOIN employee ON sale.employee_id = employee.employee_id " +
                "INNER JOIN client ON sale.client_id = client.client_id");
        }

        public DataTable ShowIdClient(int client_id)
        {
            return Conn("SELECT client_id, surname, name, patronymic, passportdata, address, (address).city, (address).street, (address).house, (address).flat, phone FROM client WHERE client_id = " + client_id);
        }

        public DataTable ShowClient()
        {
            return Conn("SELECT client_id, surname, name, patronymic, passportdata, address, (address).city, (address).street, (address).house, (address).flat, phone FROM client order by client_id");
        }

        public DataTable InsertClient(String name, String surname, String patronymic, String passportdata, String address, String phone)
        {
            return Conn("INSERT INTO client(client_id, name, surname, patronymic, PassportData, address, phone)" +
                "VALUES(DEFAULT, '" + name + "','" + surname + "','" + patronymic + "','" + passportdata + "','" + address + "','" + phone + "')");
        }

        public DataTable DeleteClient(int client_id)
        {
            return Conn("DELETE FROM client WHERE client_id = '" + client_id + "'");
        }

        public DataTable DeleteSale(int client_id)
        {
            return Conn("DELETE FROM sale WHERE client_id = '" + client_id + "'");
        }

        public DataTable UpdateClient(int client_id, String name, String surname, String patronymic, String passportdata, String addresscity, String addressstreet, int addresshouse, int addressflat, String phone)
        {
            return Conn("UPDATE client SET name ='" + name + "', surname ='" + surname + "', patronymic ='" + patronymic + "', PassportData ='" + passportdata + "', address.city ='" + addresscity + "', address.street ='" + addressstreet + "', address.house ='" + addresshouse + "', address.flat ='" + addressflat + "', phone ='" + phone + "' WHERE client_id = " + client_id);
        }

        public DataTable InsertSale(int car_id, String datesale, String formpayment, int payment, int employee_id, int client_id)
        {
            return Conn("INSERT INTO sale(sale_id, car_id, datesale, formpayment, payment, employee_id, client_id)" +
                "VALUES(DEFAULT, '" + car_id + "','" + datesale + "','" + formpayment + "','" + payment + "','" + employee_id + "','" + client_id + "')");
        }

        public DataTable DeleteFromSale(int sale_id)
        {
            return Conn("DELETE FROM sale WHERE sale_id = '" + sale_id + "'");
        }
    }
}
