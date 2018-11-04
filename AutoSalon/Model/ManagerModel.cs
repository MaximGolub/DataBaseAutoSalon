using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace AutoSalon.Model
{
    public class ManagerModel
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

        public DataTable ShowAuto()
        {
            return Conn("SELECT car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier.surnamesupplier, supplier.namesupplier,  supplier.namecompany, transmission, typebody, typecar, year FROM car INNER JOIN supplier on car.supplier_id = supplier.supplier_id WHERE car_id NOT IN(SELECT sale.car_id FROM sale) ORDER BY car_id;");
        }

        public DataTable ShowSupplier()
        {
            return Conn("SELECT supplier_id, namesupplier, surnamesupplier, patronymicsupplier, address, namecompany, email, phone FROM supplier order by supplier_id");
        }

        public DataTable InsertSupplier(String address, String namecompany, String email, String namesupplier, String surnamesupplier, String patronymicsupplier, String phone)
        {
            return Conn("INSERT INTO supplier(supplier_id, address, namecompany, email, namesupplier, surnamesupplier, patronymicsupplier, phone)" +
                "VALUES(DEFAULT, '" + address + "','" + namecompany + "','" + email + "','" + namesupplier + "','" + surnamesupplier + "','" + patronymicsupplier + "','" + phone + "')");
        }

        public DataTable DeleteSupplier(int supplier_id)
        {
            return Conn("DELETE FROM supplier WHERE supplier_id = '" + supplier_id + "'");
        }

        public DataTable UpdateSupplier(int supplier_id, String namecompany, String email, String namesupplier, String surnamesupplier, String patronymicsupplier, String phone, String addresscity, String addressstreet, int addresshouse, int addressflat)
        {
            return Conn("UPDATE supplier SET namecompany ='" + namecompany + "', email ='" + email + "', namesupplier ='" + namesupplier + "', surnamesupplier ='" + surnamesupplier + "', patronymicsupplier ='" + patronymicsupplier + "', address.city ='" + addresscity + "', address.street ='" + addressstreet + "', address.house ='" + addresshouse + "', address.flat ='" + addressflat + "', phone ='" + phone + "' WHERE supplier_id = " + supplier_id);
        }

        public DataTable InsertAuto(String vin, String color, String datereceipt, String enginecapacity, String fuel, String manufacture, String marka, String model, int power, int price, int supplier_id, String transmission, String typebody, String typecar, int year)
        {
            return Conn("INSERT INTO car(car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier_id, transmission, typebody, typecar, year)" +
                "VALUES(DEFAULT, '" + vin + "','" + color + "','" + datereceipt + "','" + enginecapacity + "','" + fuel + "','" + manufacture + "','" + marka + "','" + model + "','" + power + "','" + price + "','" + supplier_id + "','" + transmission + "','" + typebody + "','" + typecar + "','" + year + "')");
        }

        public DataTable UpdateAuto(int car_id, String vin, String color, String datereceipt, String enginecapacity, String fuel, String manufacture, String marka, String model, int power, int price, int supplier_id, String transmission, String typebody, String typecar, int year)
        {
            return Conn("UPDATE car SET vin ='" + vin + "', color ='" + color + "', datereceipt ='" + datereceipt + "', enginecapacity ='" + enginecapacity + "', fuel ='" + fuel + "', manufacture ='" + manufacture + "', marka ='" + marka + "', model ='" + model + "', power ='" + power + "', price ='" + price + "', supplier_id ='" + supplier_id + "', transmission ='" + transmission + "', typebody ='" + typebody + "', typecar ='" + typecar + "', year ='" + year + "' WHERE car_id = " + car_id);
        }

        public DataTable DeleteAutoSale(int supplier_id)
        {
            return Conn("DELETE FROM sale WHERE sale.car_id IN (SELECT car.car_id FROM car WHERE supplier_id = '" + supplier_id + "')");
        }

        public DataTable DeleteAutoSupplier(int supplier_id)
        {
            return Conn("DELETE FROM car WHERE supplier_id = '" + supplier_id + "'");
        }

        public DataTable DeleteAuto(int car_id)
        {
            return Conn("DELETE FROM car WHERE car_id = '" + car_id + "'");
        }

        public DataTable ShowIdSupplier(int supplier_id)
        {
            return Conn("SELECT supplier_id, address, (address).city, (address).street, (address).house, (address).flat, namecompany, email, namesupplier, surnamesupplier, patronymicsupplier, phone FROM supplier WHERE supplier_id = " + supplier_id);
        }

        public DataTable ShowIdAuto(int car_id)
        {
            return Conn("SELECT car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, model, power, price, supplier_id, transmission, typebody, typecar, year FROM car WHERE car_id = " + car_id);
        }
    }
}
