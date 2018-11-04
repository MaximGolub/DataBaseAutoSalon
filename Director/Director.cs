using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Director
{
    public partial class Director : Form
    {
        AutoSalon.Presenter.DirectorPresenter Presenter = new AutoSalon.Presenter.DirectorPresenter();
        
        public Director()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowEmployee();
            ShowPosition();
            Combo();
            Chart();
        }
        
        public void Combo()
        {
            string[] myList = new string[2];
            myList[0] = "Консультант";
            myList[1] = "Менеджер";
            comboBox1.Items.AddRange(myList);
            comboBox1.SelectedIndex = 0;          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchEmployee();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InsertEmployee();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clean();
            ShowEmployee();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void btnFindId_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbInputId.Text == "")
                {
                    MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int index = Convert.ToInt32(tbInputId.Text);

                    dataGridView3.DataSource = Presenter.ShowIdEmployee(index);

                    textBox13.Text = Convert.ToString(dataGridView3.Rows[0].Cells[1].Value);
                    textBox12.Text = Convert.ToString(dataGridView3.Rows[0].Cells[2].Value);
                    textBox5.Text = Convert.ToString(dataGridView3.Rows[0].Cells[3].Value);
                    textBox11.Text = Convert.ToString(dataGridView3.Rows[0].Cells[4].Value);
                    textBox16.Text = Convert.ToString(dataGridView3.Rows[0].Cells[6].Value);
                    textBox14.Text = Convert.ToString(dataGridView3.Rows[0].Cells[7].Value);
                    textBox19.Text = Convert.ToString(dataGridView3.Rows[0].Cells[8].Value);
                    textBox17.Text = Convert.ToString(dataGridView3.Rows[0].Cells[9].Value);
                    textBox15.Text = Convert.ToString(dataGridView3.Rows[0].Cells[11].Value);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Такого ID нет", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowEmployee();
                tbInputId.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            ShowEmployee();
        }

        //Вывод
        public void ShowEmployee()
        {
            dataGridView1.DataSource = Presenter.ShowEmployee();
            dataGridView2.DataSource = Presenter.ShowEmployee();
            dataGridView3.DataSource = Presenter.ShowEmployee();

            if (dataGridView1.Columns.Count != 0 || dataGridView2.Columns.Count != 0 || dataGridView3.Columns.Count != 0)
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView3.Columns[6].Visible = false;

                dataGridView1.Columns[7].Visible = false;
                dataGridView2.Columns[7].Visible = false;
                dataGridView3.Columns[7].Visible = false;

                dataGridView1.Columns[8].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView3.Columns[8].Visible = false;

                dataGridView1.Columns[9].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView3.Columns[9].Visible = false;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView3.Columns[0].HeaderText = "ID";

                dataGridView1.Columns[1].HeaderText = "Имя";
                dataGridView2.Columns[1].HeaderText = "Имя";
                dataGridView3.Columns[1].HeaderText = "Имя";

                dataGridView1.Columns[2].HeaderText = "Фамилия";
                dataGridView2.Columns[2].HeaderText = "Фамилия";
                dataGridView3.Columns[2].HeaderText = "Фамилия";

                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView2.Columns[3].HeaderText = "Отчество";
                dataGridView3.Columns[3].HeaderText = "Отчество";

                dataGridView1.Columns[4].HeaderText = "Паспортные данные";
                dataGridView2.Columns[4].HeaderText = "Паспортные данные";
                dataGridView3.Columns[4].HeaderText = "Паспортные данные";

                dataGridView1.Columns[5].HeaderText = "Адрес";
                dataGridView2.Columns[5].HeaderText = "Адрес";
                dataGridView3.Columns[5].HeaderText = "Адрес";

                dataGridView1.Columns[10].HeaderText = "Должность";
                dataGridView2.Columns[10].HeaderText = "Должность";
                dataGridView3.Columns[10].HeaderText = "Должность";

                dataGridView1.Columns[11].HeaderText = "Телефон";
                dataGridView2.Columns[11].HeaderText = "Телефон";
                dataGridView3.Columns[11].HeaderText = "Телефон";
            }
        }

        public void ShowPosition()
        {
            dataGridView5.DataSource = Presenter.ShowPosition();

            if (dataGridView5.Columns.Count != 0)
            {
                dataGridView5.Columns[0].HeaderText = "ID должность";
                dataGridView5.Columns[1].HeaderText = "Должность";
                dataGridView5.Columns[2].HeaderText = "Зарплата";
            }
        }
        
        //Поиск
        public void SearchEmployee()
        {
            if (richTextBox1.Text != "")
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().ToLower().Equals(richTextBox1.Text.ToLower()))
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

        //Добавление
        public void InsertEmployee()
        {
            int index = 0;
            if (comboBox1.Text == "Консультант") { index = 3; }
            if (comboBox1.Text == "Менеджер") { index = 2; }

            if (textBox25.Text != "" && textBox24.Text != "" && textBox21.Text != "" && textBox23.Text != "" && textBox26.Text != "" && textBox22.Text != "" && textBox20.Text != "" && textBox28.Text != "")
            {
                try
                {
                    Presenter.InsertEmployee(textBox25.Text, textBox24.Text, textBox21.Text, textBox23.Text, "(" + textBox22.Text + "," + textBox20.Text + "," + textBox28.Text + "," + textBox27.Text + ")", index, textBox26.Text);
                    MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowEmployee();
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

        /*public void InsertPosition()
        {
            if (textBox33.Text != "" && textBox32.Text != "")
            {
                try
                {
                    Presenter.InsertPosition(textBox33.Text, Convert.ToInt32(textBox32.Text));
                    MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowPosition();
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
        }*/
        
        //Удаление
        public void DeleteEmployee()
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
                                Presenter.DeleteSaleEmployee(index);
                                Presenter.DeleteEmployee(index);
                                ShowEmployee();
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите пользователя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DeletePosition()
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
                                Presenter.DeletePositionInSale(index);
                                Presenter.DeletePositionInEmployee(index);
                                Presenter.DeletePosition(index);
                                ShowPosition();
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите пользователя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        //Обновление
        public void UpdateEmployee()
        {
            if (textBox13.Text != "" && textBox12.Text != "" && textBox5.Text != "" && textBox11.Text != "" && textBox15.Text != ""  && textBox16.Text != "" && textBox14.Text != "" && textBox19.Text != "")
            {
                try
                {
                    int index = Convert.ToInt32(dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString());

                    if (textBox17.Text == "")
                    {
                        Presenter.UpdateEmployee(index, textBox13.Text, textBox12.Text, textBox5.Text, textBox11.Text, textBox16.Text, textBox14.Text, Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox17.Text = null), textBox15.Text);
                    }
                    else
                    {
                        Presenter.UpdateEmployee(index, textBox13.Text, textBox12.Text, textBox5.Text, textBox11.Text, textBox16.Text, textBox14.Text, Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox17.Text), textBox15.Text);
                    }

                    MessageBox.Show("Данные успешно редактированы", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowEmployee();
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

        public void UpdatePosition()
        {
            if (textBox35.Text != "" && textBox29.Text != "")
            {
                try
                {
                    int index = Convert.ToInt32(dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString());

                    Presenter.UpdatePosition(index, textBox35.Text, Convert.ToInt32(textBox29.Text));

                    MessageBox.Show("Данные успешно редактированы", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowPosition();
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
        
        //Очистка полей
        public void Clean()
        {
            textBox25.Text = ""; textBox24.Text = ""; textBox21.Text = ""; textBox23.Text = ""; textBox26.Text = "";
            textBox22.Text = ""; textBox20.Text = ""; textBox28.Text = ""; textBox27.Text = ""; tbInputId.Text = "";
            textBox13.Text = ""; textBox12.Text = ""; textBox5.Text = ""; textBox11.Text = ""; textBox15.Text = "";
            textBox16.Text = ""; textBox14.Text = ""; textBox19.Text = ""; textBox17.Text = ""; textBox29.Text = "";
            textBox10.Text = ""; textBox35.Text = "";
        }

        public void Chart()
        {
            dataGridView4.DataSource = Presenter.Chart1();
            dataGridView7.DataSource = Presenter.Chart2();
            
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.Interval = 1;

            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                chart1.Series[0].Points.AddXY(dataGridView4.Rows[i].Cells[0].Value, dataGridView4.Rows[i].Cells[1].Value);
            }
            
            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                chart2.Series[0].Points.AddXY(dataGridView7.Rows[i].Cells[0].Value, dataGridView7.Rows[i].Cells[1].Value);
            }
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            DeletePosition();
            ShowEmployee();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Clean();
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

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
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

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
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

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void button14_Click(object sender, EventArgs e)
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

                    dataGridView5.DataSource = Presenter.ShowIdPosition(index);

                    textBox35.Text = Convert.ToString(dataGridView5.Rows[0].Cells[1].Value);
                    textBox29.Text = Convert.ToString(dataGridView5.Rows[0].Cells[2].Value);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Такого ID нет", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowPosition();
                textBox10.Text = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clean();
            ShowPosition();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UpdatePosition();
        }
    }
}
