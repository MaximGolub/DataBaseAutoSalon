using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class AdminForm : Form
    {
        LoginForm form = new LoginForm();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            Employee.Manager employee = new Employee.Manager();
            employee.textBox14.Text = "director";
            employee.Show();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Clients.Form1 form1 = new Clients.Form1();
            form1.Show();
        }

        private void btnEmpl_Click(object sender, EventArgs e)
        {
            Client.Consultant consultant = new Client.Consultant();
            consultant.textBox21.Text = "director";
            consultant.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Director.Director director = new Director.Director();
            director.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
