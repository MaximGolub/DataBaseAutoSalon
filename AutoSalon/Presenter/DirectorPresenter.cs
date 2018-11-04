using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AutoSalon.Model;

namespace AutoSalon.Presenter
{
    public class DirectorPresenter
    {
        DirectorModel model = new DirectorModel();

        public DataTable ShowIdPosition(int position_id)
        {
            return model.ShowIdPosition(position_id);
        }

        public DataTable ShowIdEmployee(int employee_id)
        {
            return model.ShowIdEmployee(employee_id);
        }

        public DataTable ShowEmployee()
        {
            return model.ShowEmployee();
        }

        public DataTable InsertEmployee(String name, String surname, String patronymic, String passportdata, String address, int position, String phone)
        {
            return model.InsertEmployee(name, surname, patronymic, passportdata, address, position, phone);
        }

        public DataTable ShowPosition()
        {
            return model.ShowPosition();
        }

        public DataTable InsertPosition(String title, int salary)
        {
            return model.InsertPosition(title, salary);
        }

        public DataTable DeleteEmployee(int employee_id)
        {
            return model.DeleteEmployee(employee_id);
        }

        public DataTable DeleteSaleEmployee(int employee_id)
        {
            return model.DeleteSaleEmployee(employee_id);
        }

        public DataTable DeletePositionInSale(int position_id)
        {
            return model.DeletePositionInSale(position_id);
        }

        public DataTable DeletePositionInEmployee(int position_id)
        {
            return model.DeletePositionInEmployee(position_id);
        }

        public DataTable DeletePosition(int position_id)
        {
            return model.DeletePosition(position_id);
        }

        public DataTable UpdateEmployee(int employee_id, String name, String surname, String patronymic, String passportdata, String addresscity, String addressstreet, int addresshouse, int addressflat, String phone)
        {
            return model.UpdateEmployee(employee_id, name, surname, patronymic, passportdata, addresscity, addressstreet, addresshouse, addressflat, phone);
        }

        public DataTable UpdatePosition(int position_id, String title, int salary)
        {
            return model.UpdatePosition(position_id, title, salary);
        }

        public DataTable Chart1()
        {
            return model.Chart1();
        }

        public DataTable Chart2()
        {
            return model.Chart2();
        }
    }
}
