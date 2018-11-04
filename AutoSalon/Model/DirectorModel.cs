using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace AutoSalon.Model
{
    public class DirectorModel
    {
        public DataTable Conn(string quer)
        {
            string connectionString = "Server='localhost';Port='5432';User='director';Password='0a06eb93b7d29e8d9b1891eec932ba2a';Database='Autosalon';";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(quer, npgSqlConnection);
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            adapter.Fill(table);
            npgSqlConnection.Close();
            return table;
        }

        public DataTable ShowIdPosition(int position_id)
        {
            return Conn("SELECT position_id, title, salary FROM position WHERE position_id = " + position_id);
        }

        public DataTable ShowIdEmployee(int employee_id)
        {
            return Conn("SELECT employee_id, name, surname, patronymic, passportdata, address, (address).city, (address).street, (address).house, (address).flat, position.title, phone FROM employee INNER JOIN position ON employee.position_id = position.position_id WHERE employee_id = " + employee_id);
        }

        public DataTable ShowEmployee()
        {
            return Conn("SELECT employee_id, name, surname, patronymic, passportdata, address, (address).city, (address).street, (address).house, (address).flat, position.title, phone FROM employee INNER JOIN position ON employee.position_id = position.position_id ORDER BY employee_id;");
        }

        public DataTable InsertEmployee(String name, String surname, String patronymic, String passportdata, String address, int position, String phone)
        {
            return Conn("INSERT INTO employee(employee_id, name, surname, patronymic, PassportData, address, position_id, phone)" +
                "VALUES(DEFAULT, '" + name + "','" + surname + "','" + patronymic + "','" + passportdata + "','" + address + "','" + position + "','" + phone + "')");
        }

        public DataTable ShowPosition()
        {
            return Conn("SELECT position_id, title, salary FROM position ORDER BY position_id");
        }

        public DataTable InsertPosition(String title, int salary)
        {
            return Conn("INSERT INTO position(position_id, title, salary)" +
                    "VALUES(DEFAULT, '" + title + "','" + salary + "')");
        }

        public DataTable DeleteEmployee(int employee_id)
        {
            return Conn("DELETE FROM employee WHERE employee_id = '" + employee_id + "'");
        }

        public DataTable DeleteSaleEmployee(int employee_id)
        {
            return Conn("DELETE FROM sale WHERE employee_id = '" + employee_id + "'");
        }

        public DataTable DeletePositionInSale(int position_id)
        {
            return Conn("DELETE FROM sale WHERE sale.employee_id IN(SELECT employee.employee_id FROM employee WHERE position_id = '" + position_id + "')");
        }

        public DataTable DeletePositionInEmployee(int position_id)
        {
            return Conn("DELETE FROM employee WHERE position_id = '" + position_id + "'");
        }

        public DataTable DeletePosition(int position_id)
        {
            return Conn("DELETE FROM position WHERE position_id = '" + position_id + "'");
        }

        public DataTable UpdateEmployee(int employee_id, String name, String surname, String patronymic, String passportdata, String addresscity, String addressstreet, int addresshouse, int addressflat, String phone)
        {
            return Conn("UPDATE employee SET name ='" + name + "', surname ='" + surname + "', patronymic ='" + patronymic + "', PassportData ='" + passportdata + "', address.city ='" + addresscity + "', address.street ='" + addressstreet + "', address.house ='" + addresshouse + "', address.flat ='" + addressflat + "', phone ='" + phone + "' WHERE employee_id = " + employee_id);
        }

        public DataTable UpdatePosition(int position_id, String title, int salary)
        {
            return Conn("UPDATE position SET title ='" + title + "', salary ='" + salary + "' WHERE position_id = " + position_id);
        }

        public DataTable Chart1()
        {
            return Conn("SELECT surname, COUNT(sale_id) FROM sale INNER JOIN employee ON sale.employee_id = employee.employee_id GROUP BY surname;");
        }

        public DataTable Chart2()
        {
            return Conn("SELECT marka, SUM(sale.payment) FROM car INNER JOIN sale ON car.car_id = sale.car_id GROUP BY marka;");
        }
    }
}
