using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSalon;
using Npgsql;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        AutoSalon.Presenter.ConsultantPresenter presenter = new AutoSalon.Presenter.ConsultantPresenter();

        AutoSalon.LoginPass logpass = new AutoSalon.LoginPass();

        Client.Consultant consultant = new Client.Consultant();

        Client.Sale sale = new Client.Sale();

        Employee.Manager manager = new Employee.Manager();

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            if (logpass.Login(textBox1.Text, textBox2.Text))
            {
                //this.Hide();
                switch (CurrentUser.roles)
                {
                    case "clients":
                        Clients.Form1 form1 = new Clients.Form1();
                        form1.Show();
                        break;
                    case "consultant":
                        textBox3.Text = "consultant";
                        consultant.textBox21.Text = textBox3.Text;
                        //Hide();
                        consultant.Show();
                        break;
                    case "manager":
                        Employee.Manager manager = new Employee.Manager();
                        textBox3.Text = "manager";
                        manager.textBox14.Text = textBox3.Text;
                        //Hide();
                        manager.Show();
                        break;
                    case "director":
                        textBox3.Text = "director";
                        consultant.textBox21.Text = textBox3.Text;
                        sale.textBox1.Text = consultant.textBox21.Text;
                        AdminForm admMenu = new AdminForm();
                        //Hide();
                        admMenu.Show();
                        break;
                    default:
                        MessageBox.Show("Ошибка логина!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else
                MessageBox.Show("Не найден такой пользователь!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
