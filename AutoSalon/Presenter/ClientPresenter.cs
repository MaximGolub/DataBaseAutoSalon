using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AutoSalon
{
    public class ClientPresenter
    {
        ClientModel model = new ClientModel();

        public DataTable ShowAuto()
        {
            return model.ShowAuto();
        }
    }
}