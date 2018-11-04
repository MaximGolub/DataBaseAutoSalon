using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Sale : Form
    {
        AutoSalon.Presenter.ConsultantPresenter Presenter = new AutoSalon.Presenter.ConsultantPresenter();

        Client.Consultant client = new Client.Consultant();
        
        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            Abe();
            ShowSale();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchSale();
        }

        public void ShowSale()
        {
            dataGridView1.DataSource = Presenter.ShowSale();

            if (dataGridView1.Columns.Count != 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID продажи";
                dataGridView1.Columns[1].HeaderText = "VIN код";
                dataGridView1.Columns[2].HeaderText = "Марка авто";
                dataGridView1.Columns[3].HeaderText = "Модель авто";
                dataGridView1.Columns[4].HeaderText = "Дата продажи";
                dataGridView1.Columns[5].HeaderText = "Форма оплаты";
                dataGridView1.Columns[6].HeaderText = "Цена";
                dataGridView1.Columns[7].HeaderText = "Имя сотрудника";
                dataGridView1.Columns[8].HeaderText = "Фамилия сотрудника";
                dataGridView1.Columns[9].HeaderText = "Имя клиента";
                dataGridView1.Columns[10].HeaderText = "Фамилия клиента";
            }
        }

        public void Abe()
        {
            if (textBox1.Text == "consultant")
            {
                button9.Visible = true;
            }
            if (textBox1.Text == "director")
            {
                button2.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            dataGridView1.DataSource = Presenter.ShowSale();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //DeleteSale();
            MessageBox.Show("Ошибка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SearchSale()
        {
            if (richTextBox1.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower().Equals(richTextBox1.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DeleteSale()
        {
            try
            {
                int index = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                if (index != 0)
                {
                    DialogResult result = MessageBox.Show("Удалить данные? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                Presenter.DeleteFromSale(index);
                                ShowSale();
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSale();
        }
    }
}
