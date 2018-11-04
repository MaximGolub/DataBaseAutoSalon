using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AutoSalon.Model;

namespace AutoSalon.Presenter
{
    public class ConsultantPresenter
    {
        ConsultantModel model = new ConsultantModel();

        public DataTable ShowIdAuto(int car_id)
        {
            return model.ShowIdAuto(car_id);
        }

        public DataTable ShowAuto()
        {
            return model.ShowAuto();
        }

        public DataTable ShowSale()
        {
            return model.ShowSale();
        }

        public DataTable ShowIdClient(int client_id)
        {
            return model.ShowIdClient(client_id);
        }

        public DataTable ShowClient()
        {
            return model.ShowClient();
        }

        public DataTable InsertClient(String name, String surname, String patronymic, String passportdata, String address, String phone)
        {
            return model.InsertClient(name, surname, patronymic, passportdata, address, phone);
        }

        public DataTable DeleteClient(int client_id)
        {
            return model.DeleteClient(client_id);
        }

        public DataTable DeleteSale(int client_id)
        {
            return model.DeleteSale(client_id);
        }

        public DataTable UpdateClient(int client_id, String name, String surname, String patronymic, String passportdata, String addresscity, String addressstreet, int addresshouse, int addressflat, String phone)
        {
            return model.UpdateClient(client_id, name, surname, patronymic, passportdata, addresscity, addressstreet, addresshouse, addressflat, phone);
        }

        public DataTable InsertSale(int car_id, String datesale, String formpayment, int payment, int employee_id, int client_id)
        {
            return model.InsertSale(car_id, datesale, formpayment, payment, employee_id, client_id);
        }

        public DataTable DeleteFromSale(int sale_id)
        {
            return model.DeleteFromSale(sale_id);
        }
    }
}
