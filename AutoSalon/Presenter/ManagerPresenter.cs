using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AutoSalon.Model;

namespace AutoSalon.Presenter
{
    public class ManagerPresenter
    {
        ManagerModel model = new ManagerModel();

        public DataTable ShowAuto()
        {
            return model.ShowAuto();
        }

        public DataTable ShowSupplier()
        {
            return model.ShowSupplier();
        }

        public DataTable InsertSupplier(String address, String namecompany, String email, String namesupplier, String surnamesupplier, String patronymicsupplier, String phone)
        {
            return model.InsertSupplier(address, namecompany, email, namesupplier, surnamesupplier, patronymicsupplier, phone);
        }

        public DataTable DeleteSupplier(int supplier_id)
        {
            return model.DeleteSupplier(supplier_id);
        }

        public DataTable UpdateSupplier(int supplier_id, String namecompany, String email, String namesupplier, String surnamesupplier, String patronymicsupplier, String phone, String addresscity, String addressstreet, int addresshouse, int addressflat)
        {
            return model.UpdateSupplier(supplier_id, namecompany, email, namesupplier, surnamesupplier, patronymicsupplier, phone, addresscity, addressstreet, addresshouse, addressflat);
        }

        public DataTable InsertAuto(String vin, String color, String datereceipt, String enginecapacity, String fuel, String manufacture, String marka, String modelcar, int power, int price, int supplier_id, String transmission, String typebody, String typecar, int year)
        {
            return model.InsertAuto(vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, modelcar, power, price, supplier_id, transmission, typebody, typecar, year);
        }

        public DataTable UpdateAuto(int car_id, String vin, String color, String datereceipt, String enginecapacity, String fuel, String manufacture, String marka, String modelcar, int power, int price, int supplier_id, String transmission, String typebody, String typecar, int year)
        {
            return model.UpdateAuto(car_id, vin, color, datereceipt, enginecapacity, fuel, manufacture, marka, modelcar, power, price, supplier_id, transmission, typebody, typecar, year);
        }

        public DataTable DeleteAutoSale(int supplier_id)
        {
            return model.DeleteAutoSale(supplier_id);
        }

        public DataTable DeleteAutoSupplier(int supplier_id)
        {
            return model.DeleteAutoSupplier(supplier_id);
        }

        public DataTable DeleteAuto(int car_id)
        {
            return model.DeleteAuto(car_id);
        }

        public DataTable ShowIdSupplier(int supplier_id)
        {
            return model.ShowIdSupplier(supplier_id);
        }

        public DataTable ShowIdAuto(int car_id)
        {
            return model.ShowIdAuto(car_id);
        }
    }
}
