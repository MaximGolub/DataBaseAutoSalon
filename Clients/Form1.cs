using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients
{
    public partial class Form1 : Form
    {
        AutoSalon.ClientPresenter Presenter = new AutoSalon.ClientPresenter();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFindId_Click(object sender, EventArgs e)
        {
            SearchAuto();
        }

        public void SearchAuto()
        {
            if (tbInputId.Text != "")
            { Search1(); }

            if (textBox1.Text != "")
            { Search2(); }

            if (textBox2.Text != "")
            { Search3(); }
        }

        public void Search1()
        {
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Equals(tbInputId.Text.ToLower()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
                if (dataGridView1.Rows[i].Selected == false)
                {
                    dataGridView1.Rows.RemoveAt(i--);
                }
            }
        }

        public void Search2()
        {
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Equals(textBox1.Text.ToLower()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
                if (dataGridView1.Rows[i].Selected == false)
                {
                    dataGridView1.Rows.RemoveAt(i--);
                }
            }
        }

        public void Search3()
        {
            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Equals(textBox2.Text.ToLower()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
                if (dataGridView1.Rows[i].Selected == false)
                {
                    dataGridView1.Rows.RemoveAt(i--);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAuto();
        }

        public void ShowAuto()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.DataSource = Presenter.ShowAuto();

            if (dataGridView1.Columns.Count != 0)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                //dataGridView1.Columns[0].HeaderText = "ID авто";
                dataGridView1.Columns[1].HeaderText = "VIN код";
                dataGridView1.Columns[2].HeaderText = "Цвет";
                dataGridView1.Columns[4].HeaderText = "Объем двигателя";
                dataGridView1.Columns[5].HeaderText = "Топливо";
                dataGridView1.Columns[6].HeaderText = "Производитель";
                dataGridView1.Columns[7].HeaderText = "Марка";
                dataGridView1.Columns[8].HeaderText = "Модель";
                dataGridView1.Columns[9].HeaderText = "Л.с.";
                dataGridView1.Columns[10].HeaderText = "Цена";
                dataGridView1.Columns[12].HeaderText = "Трансмиссия";
                dataGridView1.Columns[13].HeaderText = "Тип авто";
                dataGridView1.Columns[14].HeaderText = "Тип кузова";
                dataGridView1.Columns[15].HeaderText = "Год";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAuto();
            tbInputId.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
