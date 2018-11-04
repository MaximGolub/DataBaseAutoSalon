using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSalon;

namespace Employee
{
    public partial class Manager : Form
    {
        AutoSalon.Presenter.ManagerPresenter Presenter = new AutoSalon.Presenter.ManagerPresenter();

        public Manager()
        {
            InitializeComponent();
            Combo();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            ShowTable();
            Ter();
        }

        public void Ter()
        {
            if (textBox14.Text == "manager")
            {
                button9.Visible = true;
                button16.Visible = true;
            }

            if (textBox14.Text == "director")
            {
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        public void Combo()
        {
            string[] myList = new string[4];
            myList[0] = "Бензин";
            myList[1] = "Дизель";
            myList[2] = "Гибрид";
            myList[3] = "Электро";
            comboBox1.Items.AddRange(myList);
            comboBox1.SelectedIndex = 0;
            comboBox8.Items.AddRange(myList);

            string[] myList2 = new string[5];
            myList2[0] = "Механика";
            myList2[1] = "Автомат";
            myList2[2] = "Типтроник";
            myList2[3] = "Адаптивная";
            myList2[4] = "Вариатор";
            comboBox2.Items.AddRange(myList2);
            comboBox2.SelectedIndex = 0;
            comboBox7.Items.AddRange(myList2);

            string[] myList3 = new string[1];
            myList3[0] = "Легковые";
            comboBox3.Items.AddRange(myList3);
            comboBox3.SelectedIndex = 0;
            comboBox6.Items.AddRange(myList3);

            string[] myList4 = new string[8];
            myList4[0] = "Седан";
            myList4[1] = "Хэтчбек";
            myList4[2] = "Купе";
            myList4[3] = "Универсал";
            myList4[4] = "Кабриолет";
            myList4[5] = "Внедорожник";
            myList4[6] = "Пикап";
            myList4[7] = "Минивэн";
            comboBox5.Items.AddRange(myList4);
            comboBox5.SelectedIndex = 0;
            comboBox4.Items.AddRange(myList4);
        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            InsertSupplier();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SearchSupplier();
        }      

        private void button9_Click(object sender, EventArgs e)
        {
            //DeleteSupplier();
            MessageBox.Show("Ошибка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            ShowTable();
        }
        
        //Вывод
        public void ShowTable()
        {
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.DataSource = Presenter.ShowSupplier();
            dataGridView2.DataSource = Presenter.ShowSupplier();
            dataGridView3.DataSource = Presenter.ShowSupplier();
            dataGridView4.DataSource = Presenter.ShowAuto();
            dataGridView5.DataSource = Presenter.ShowAuto();
            dataGridView6.DataSource = Presenter.ShowAuto();

            if (dataGridView1.Columns.Count != 0 || dataGridView2.Columns.Count !=0 || dataGridView3.Columns.Count != 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID поставщика";
                dataGridView1.Columns[1].HeaderText = "Имя";
                dataGridView1.Columns[2].HeaderText = "Фамилия";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Адрес";
                dataGridView1.Columns[5].HeaderText = "Название компании";
                dataGridView1.Columns[6].HeaderText = "Email";
                dataGridView1.Columns[7].HeaderText = "Телефон";

                dataGridView2.Columns[0].HeaderText = "ID поставщика";
                dataGridView2.Columns[1].HeaderText = "Имя";
                dataGridView2.Columns[2].HeaderText = "Фамилия";
                dataGridView2.Columns[3].HeaderText = "Отчество";
                dataGridView2.Columns[4].HeaderText = "Адрес";
                dataGridView2.Columns[5].HeaderText = "Название компании";
                dataGridView2.Columns[6].HeaderText = "Email";
                dataGridView2.Columns[7].HeaderText = "Телефон";

                dataGridView3.Columns[0].HeaderText = "ID поставщика";
                dataGridView3.Columns[1].HeaderText = "Имя";
                dataGridView3.Columns[2].HeaderText = "Фамилия";
                dataGridView3.Columns[3].HeaderText = "Отчество";
                dataGridView3.Columns[4].HeaderText = "Адрес";
                dataGridView3.Columns[5].HeaderText = "Название компании";
                dataGridView3.Columns[6].HeaderText = "Email";
                dataGridView3.Columns[7].HeaderText = "Телефон";
            }

            if (dataGridView4.Columns.Count != 0 || dataGridView5.Columns.Count != 0 || dataGridView6.Columns.Count != 0)
            {
                dataGridView4.Columns[0].HeaderText = "ID авто";
                dataGridView4.Columns[1].HeaderText = "VIN код";
                dataGridView4.Columns[2].HeaderText = "Цвет";
                dataGridView4.Columns[3].HeaderText = "Дата поставки";
                dataGridView4.Columns[4].HeaderText = "Объем двигателя";
                dataGridView4.Columns[5].HeaderText = "Топливо";
                dataGridView4.Columns[6].HeaderText = "Производитель";
                dataGridView4.Columns[7].HeaderText = "Марка";
                dataGridView4.Columns[8].HeaderText = "Модель";
                dataGridView4.Columns[9].HeaderText = "Л.с.";
                dataGridView4.Columns[10].HeaderText = "Цена";
                dataGridView4.Columns[11].HeaderText = "Фамилия поставщика";
                dataGridView4.Columns[12].HeaderText = "Имя поставщика";
                dataGridView4.Columns[13].HeaderText = "Название компании";
                dataGridView4.Columns[14].HeaderText = "Трансмиссия";
                dataGridView4.Columns[15].HeaderText = "Тип авто";
                dataGridView4.Columns[16].HeaderText = "Тип кузова";
                dataGridView4.Columns[17].HeaderText = "Год";

                dataGridView5.Columns[0].HeaderText = "ID авто";
                dataGridView5.Columns[1].HeaderText = "VIN код";
                dataGridView5.Columns[2].HeaderText = "Цвет";
                dataGridView5.Columns[3].HeaderText = "Дата поставки";
                dataGridView5.Columns[4].HeaderText = "Объем двигателя";
                dataGridView5.Columns[5].HeaderText = "Топливо";
                dataGridView5.Columns[6].HeaderText = "Производитель";
                dataGridView5.Columns[7].HeaderText = "Марка";
                dataGridView5.Columns[8].HeaderText = "Модель";
                dataGridView5.Columns[9].HeaderText = "Л.с.";
                dataGridView5.Columns[10].HeaderText = "Цена";
                dataGridView5.Columns[11].HeaderText = "Фамилия поставщика";
                dataGridView5.Columns[12].HeaderText = "Имя поставщика";
                dataGridView5.Columns[13].HeaderText = "Название компании";
                dataGridView5.Columns[14].HeaderText = "Трансмиссия";
                dataGridView5.Columns[15].HeaderText = "Тип авто";
                dataGridView5.Columns[16].HeaderText = "Тип кузова";
                dataGridView5.Columns[17].HeaderText = "Год";

                dataGridView6.Columns[0].HeaderText = "ID авто";
                dataGridView6.Columns[1].HeaderText = "VIN код";
                dataGridView6.Columns[2].HeaderText = "Цвет";
                dataGridView6.Columns[3].HeaderText = "Дата поставки";
                dataGridView6.Columns[4].HeaderText = "Объем двигателя";
                dataGridView6.Columns[5].HeaderText = "Топливо";
                dataGridView6.Columns[6].HeaderText = "Производитель";
                dataGridView6.Columns[7].HeaderText = "Марка";
                dataGridView6.Columns[8].HeaderText = "Модель";
                dataGridView6.Columns[9].HeaderText = "Л.с.";
                dataGridView6.Columns[10].HeaderText = "Цена";
                dataGridView6.Columns[11].HeaderText = "Фамилия поставщика";
                dataGridView6.Columns[12].HeaderText = "Имя поставщика";
                dataGridView6.Columns[13].HeaderText = "Название компании";
                dataGridView6.Columns[14].HeaderText = "Трансмиссия";
                dataGridView6.Columns[15].HeaderText = "Тип авто";
                dataGridView6.Columns[16].HeaderText = "Тип кузова";
                dataGridView6.Columns[17].HeaderText = "Год";
            }
        }

        //Добавление
        public void InsertSupplier()
        {
            if (textBox27.Text != "" && textBox26.Text != "" && textBox25.Text != "" && textBox28.Text != "" && textBox29.Text != "" && textBox30.Text != "" && textBox21.Text != "" && textBox20.Text != "")
            {
                try
                {
                    string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
                    string email = textBox26.Text;

                    if (Regex.IsMatch(email, cond))
                    {
                        Presenter.InsertSupplier("(" + textBox21.Text + "," + textBox20.Text + "," + textBox23.Text + "," + textBox22.Text + ")", textBox27.Text, textBox26.Text, textBox25.Text, textBox28.Text, textBox29.Text, textBox30.Text);
                        MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean();
                        ShowTable();
                    }
                    else
                    {
                        MessageBox.Show("Неверные Email", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void InsertAuto()
        {
            if (textBox49.Text != "" && textBox48.Text != "" && textBox47.Text != "" && textBox41.Text != "" && textBox40.Text != "" && textBox43.Text != "" && textBox42.Text != "" && textBox45.Text != "" && textBox44.Text != "" && textBox2.Text != "")
            {
                if (dateTimePicker1.Value <= DateTime.Today)
                {
                    try
                    {
                        Presenter.InsertAuto(textBox49.Text, textBox48.Text, dateTimePicker1.Value.Date.Year + "-" + dateTimePicker1.Value.Date.Month + "-" + dateTimePicker1.Value.Date.Day, textBox47.Text, comboBox1.Text, textBox41.Text, textBox40.Text, textBox43.Text, Convert.ToInt32(textBox42.Text), Convert.ToInt32(textBox45.Text), Convert.ToInt32(textBox44.Text), comboBox2.Text, comboBox3.Text, comboBox5.Text, Convert.ToInt32(textBox2.Text));
                        MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean();
                        ShowTable();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Обновление 
        public void UpdateSupplier()
        {
            if (textBox32.Text != "" && textBox31.Text != "" && textBox34.Text != "" && textBox38.Text != "" && textBox37.Text != "" && textBox35.Text != "" && textBox36.Text != "" && textBox39.Text != "" && textBox1.Text != "")
            {
                try
                {
                    int index = Convert.ToInt32(dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString());

                    if (textBox33.Text == "")
                    {
                        Presenter.UpdateSupplier(index, textBox38.Text, textBox37.Text, textBox35.Text, textBox36.Text, textBox39.Text, textBox1.Text, textBox32.Text, textBox31.Text, Convert.ToInt32(textBox34.Text), Convert.ToInt32(textBox33.Text = null));
                    }
                    else
                    {
                        Presenter.UpdateSupplier(index, textBox38.Text, textBox37.Text, textBox35.Text, textBox36.Text, textBox39.Text, textBox1.Text, textBox32.Text, textBox31.Text, Convert.ToInt32(textBox34.Text), Convert.ToInt32(textBox33.Text));
                    }
                    MessageBox.Show("Данные успешно редактированы", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowTable();
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateAuto()
        {
            if (textBox13.Text != "" && textBox12.Text != "" && textBox11.Text != "" && textBox5.Text != "" && textBox4.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox9.Text != "" && textBox8.Text != "" && textBox3.Text != "")
            {
                try
                {
                    if (dateTimePicker2.Value <= DateTime.Today)
                    {
                        textBox11.Text = textBox11.Text.Replace(",", ".");

                        int index = Convert.ToInt32(dataGridView6[0, dataGridView6.CurrentRow.Index].Value.ToString());

                        Presenter.UpdateAuto(index, textBox13.Text, textBox12.Text, dateTimePicker2.Value.Date.Year + "-" + dateTimePicker2.Value.Date.Month + "-" + dateTimePicker2.Value.Date.Day, textBox11.Text, comboBox8.Text, textBox5.Text, textBox4.Text, textBox7.Text, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox8.Text), comboBox7.Text, comboBox6.Text, comboBox4.Text, Convert.ToInt32(textBox3.Text));

                        MessageBox.Show("Данные успешно редактированы", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean();
                        ShowTable();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Удаление
        public void DeleteSupplier()
        {
            try
            {
                int index = Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString());

                if (index != 0)
                {
                    DialogResult result = MessageBox.Show("Удалить данные? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                Presenter.DeleteAutoSale(index);
                                Presenter.DeleteAutoSupplier(index);
                                Presenter.DeleteSupplier(index);
                                ShowTable();
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

        public void DeleteAuto()
        {
            try
            {
                int index = Convert.ToInt32(dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString());

                if (index != 0)
                {
                    DialogResult result = MessageBox.Show("Удалить данные? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                Presenter.DeleteAuto(index);
                                Show();
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

        //Поиск
        public void SearchSupplier()
        {
            if (richTextBox2.Text != "")
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().ToLower().Equals(richTextBox2.Text.ToLower()))
                        {
                            dataGridView2.Rows[i].Selected = true;
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

        public void SearchAuto()
        {
            if (richTextBox3.Text != "")
            {
                for (int i = 0; i < dataGridView5.RowCount; i++)
                {
                    dataGridView5.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    {
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().ToLower().Equals(richTextBox3.Text.ToLower()))
                        {
                            dataGridView5.Rows[i].Selected = true;
                            break;
                        }
                    }
                    if (dataGridView5.Rows[i].Selected == false)
                    {
                        dataGridView5.Rows.RemoveAt(i--);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Очистка полей
        public void Clean()
        {
            comboBox8.Enabled = false; comboBox7.Enabled = false; comboBox6.Enabled = false; comboBox4.Enabled = false;
            comboBox8.Text = ""; comboBox7.Text = ""; comboBox6.Text = ""; comboBox4.Text = "";
            textBox27.Text = ""; textBox26.Text = ""; textBox25.Text = ""; textBox28.Text = "";
            textBox29.Text = ""; textBox30.Text = ""; textBox21.Text = ""; textBox20.Text = ""; textBox23.Text = "";
            textBox22.Text = ""; textBox51.Text = ""; textBox13.Text = ""; textBox12.Text = ""; textBox11.Text = "";
            textBox5.Text = ""; textBox4.Text = ""; textBox7.Text = ""; textBox6.Text = ""; textBox9.Text = "";
            textBox8.Text = ""; textBox3.Text = ""; textBox49.Text = ""; textBox48.Text = ""; textBox47.Text = "";
            textBox41.Text = ""; textBox40.Text = ""; textBox43.Text = ""; textBox42.Text = ""; textBox45.Text = "";
            textBox44.Text = ""; textBox2.Text = ""; textBox38.Text = ""; textBox37.Text = ""; textBox35.Text = "";
            textBox36.Text = ""; textBox39.Text = ""; textBox1.Text = ""; textBox32.Text = ""; textBox31.Text = "";
            textBox34.Text = ""; textBox33.Text = ""; dateTimePicker2.Value = DateTime.Now; textBox10.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text == "")
                {
                    MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int index = Convert.ToInt32(textBox10.Text);

                    dataGridView3.DataSource = Presenter.ShowIdSupplier(index);
                    
                    textBox32.Text = Convert.ToString(dataGridView3.Rows[0].Cells[2].Value); //city
                    textBox31.Text = Convert.ToString(dataGridView3.Rows[0].Cells[3].Value); //street
                    textBox34.Text = Convert.ToString(dataGridView3.Rows[0].Cells[4].Value); //house
                    textBox33.Text = Convert.ToString(dataGridView3.Rows[0].Cells[5].Value); //flat
                    textBox38.Text = Convert.ToString(dataGridView3.Rows[0].Cells[6].Value); //namecompany
                    textBox37.Text = Convert.ToString(dataGridView3.Rows[0].Cells[7].Value); //email
                    textBox35.Text = Convert.ToString(dataGridView3.Rows[0].Cells[8].Value); //name
                    textBox36.Text = Convert.ToString(dataGridView3.Rows[0].Cells[9].Value); //surname
                    textBox39.Text = Convert.ToString(dataGridView3.Rows[0].Cells[10].Value); //patronymic
                    textBox1.Text = Convert.ToString(dataGridView3.Rows[0].Cells[11].Value); //phone
                }
            }
            catch (Exception)
            {
                ShowTable();
                MessageBox.Show("Такого ID нет", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox10.Text = "";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UpdateSupplier();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            InsertAuto();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SearchAuto();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            ShowTable();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //DeleteAuto();
            //ShowTable();
            MessageBox.Show("Ошибка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox51.Text == "")
                {
                    MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int index = Convert.ToInt32(textBox51.Text);
                    dataGridView6.DataSource = Presenter.ShowIdAuto(index);

                    comboBox8.Enabled = true;
                    comboBox7.Enabled = true;
                    comboBox6.Enabled = true;
                    comboBox5.Enabled = true;
                    comboBox4.Enabled = true;

                    textBox13.Text = Convert.ToString(dataGridView6.Rows[0].Cells[1].Value); //vin
                    textBox12.Text = Convert.ToString(dataGridView6.Rows[0].Cells[2].Value); //color
                    dateTimePicker2.Text = Convert.ToString(dataGridView6.Rows[0].Cells[3].Value); //datereceipt
                    textBox11.Text = Convert.ToString(dataGridView6.Rows[0].Cells[4].Value); //enginecapacity
                    comboBox8.Text = Convert.ToString(dataGridView6.Rows[0].Cells[5].Value); //fuel
                    textBox5.Text = Convert.ToString(dataGridView6.Rows[0].Cells[6].Value); //manufacture
                    textBox4.Text = Convert.ToString(dataGridView6.Rows[0].Cells[7].Value); //marka
                    textBox7.Text = Convert.ToString(dataGridView6.Rows[0].Cells[8].Value); //model
                    textBox6.Text = Convert.ToString(dataGridView6.Rows[0].Cells[9].Value); //power
                    textBox9.Text = Convert.ToString(dataGridView6.Rows[0].Cells[10].Value); //price
                    textBox8.Text = Convert.ToString(dataGridView6.Rows[0].Cells[11].Value); //supplier_id
                    comboBox7.Text = Convert.ToString(dataGridView6.Rows[0].Cells[12].Value); //transmission
                    comboBox6.Text = Convert.ToString(dataGridView6.Rows[0].Cells[13].Value); //typebody
                    comboBox4.Text = Convert.ToString(dataGridView6.Rows[0].Cells[14].Value); //typecar
                    textBox3.Text = Convert.ToString(dataGridView6.Rows[0].Cells[15].Value); //year
                }
            }
            catch (Exception)
            {
                ShowTable();
                MessageBox.Show("Такого ID нет", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Clean();
            ShowTable();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            UpdateAuto();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Clean();
            ShowTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox38_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox39_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void textBox49_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox48_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox47_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox40_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox43_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox45_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox44_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteSupplier();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteAuto();
            ShowTable();
        }
    }
}
