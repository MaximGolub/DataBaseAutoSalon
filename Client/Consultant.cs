using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSalon;

namespace Client
{
    public partial class Consultant : Form
    {
        AutoSalon.Presenter.ConsultantPresenter Presenter = new AutoSalon.Presenter.ConsultantPresenter();
    
        public Consultant()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowClientIs();
            Combo();
            Ter();
        }

        public void Combo()
        {
            string[] myList = new string[2];
            myList[0] = "Cash";
            myList[1] = "CreditCard";
            comboBox1.Items.AddRange(myList);
            comboBox1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox9.Text != "" && textBox18.Text != "")
            {
                try
                {
                    Presenter.InsertClient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, "(" + textBox18.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + ")", textBox9.Text);
                    MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowClientIs();
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

        public void ShowClientIs()
        {
            dataGridView1.DataSource = Presenter.ShowClient();

            if (dataGridView1.Columns.Count != 0)
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Паспортные данные";
                dataGridView1.Columns[5].HeaderText = "Адрес";
                dataGridView1.Columns[6].HeaderText = "Город";
                dataGridView1.Columns[7].HeaderText = "Улица";
                dataGridView1.Columns[8].HeaderText = "Дом";
                dataGridView1.Columns[9].HeaderText = "Квартира";
                dataGridView1.Columns[10].HeaderText = "Телефон";
            }
        }

        public void Ter()
        {
            if (textBox21.Text == "consultant")
            {
                button4.Visible = true;
            }
            if (textBox21.Text == "director")
            {
                button13.Visible = true;
            }
        }

        public void DeleteClientIs()
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
                                Presenter.DeleteSale(index);
                                Presenter.DeleteClient(index);
                                ShowClientIs();
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

        public void SearchClient()
        {
            if (richTextBox1.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Equals(richTextBox1.Text.ToLower()))
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
            else
            {
                MessageBox.Show("Введите данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clean()
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
            textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox18.Text = "";
            textBox13.Text = ""; textBox12.Text = ""; textBox5.Text = ""; textBox11.Text = ""; textBox15.Text = "";
            textBox16.Text = ""; textBox14.Text = ""; textBox19.Text = ""; textBox17.Text = ""; tbInputId.Text = "";
            textBox24.Text = ""; textBox20.Text = ""; textBox22.Text = ""; textBox26.Text = "";
        }

        private void btnFindId_Click_1(object sender, EventArgs e)
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
                    
                    dataGridView1.DataSource = Presenter.ShowIdClient(index);

                    textBox13.Text = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
                    textBox12.Text = Convert.ToString(dataGridView1.Rows[0].Cells[2].Value);
                    textBox5.Text = Convert.ToString(dataGridView1.Rows[0].Cells[3].Value);
                    textBox11.Text = Convert.ToString(dataGridView1.Rows[0].Cells[4].Value);
                    textBox16.Text = Convert.ToString(dataGridView1.Rows[0].Cells[6].Value);
                    textBox14.Text = Convert.ToString(dataGridView1.Rows[0].Cells[7].Value);
                    textBox19.Text = Convert.ToString(dataGridView1.Rows[0].Cells[8].Value);
                    textBox17.Text = Convert.ToString(dataGridView1.Rows[0].Cells[9].Value);
                    textBox15.Text = Convert.ToString(dataGridView1.Rows[0].Cells[10].Value);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Такого ID нет", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowClientIs();
                tbInputId.Text = "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Clean();
            ShowClientIs();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox12.Text != "" && textBox5.Text != "" && textBox11.Text != "" && textBox16.Text != "" && textBox14.Text != "" && textBox19.Text != "" && textBox15.Text != "")
            {
                try
                {
                    int index = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                    if (textBox17.Text == "")
                    {
                        Presenter.UpdateClient(index, textBox13.Text, textBox12.Text, textBox5.Text, textBox11.Text, textBox16.Text, textBox14.Text, Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox17.Text = null), textBox15.Text);
                    }
                    else { Presenter.UpdateClient(index, textBox13.Text, textBox12.Text, textBox5.Text, textBox11.Text, textBox16.Text, textBox14.Text, Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox17.Text), textBox15.Text); }

                    MessageBox.Show("Данные успешно редактированы", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                    ShowClientIs();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            ShowClientIs();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //DeleteClientIs();
            MessageBox.Show("Ошибка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();
            auto.Show(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;

            if (textBox24.Text != "" && textBox26.Text != "" && textBox22.Text != "" && textBox20.Text != "")
            {
                try
                {
                    Presenter.InsertSale(Convert.ToInt32(textBox24.Text), dateTimePicker1.Value.Date.Year + "-" + dateTimePicker1.Value.Date.Month + "-" + dateTimePicker1.Value.Date.Day, comboBox1.Text, Convert.ToInt32(textBox26.Text), Convert.ToInt32(textBox22.Text), Convert.ToInt32(textBox20.Text));
                    MessageBox.Show("Успешно добавлено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
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

        private void button11_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            if (textBox21.Text == "consultant")
            {
                sale.textBox1.Text = "consultant";
            }
            if (textBox21.Text == "director")
            {
                sale.textBox1.Text = "director";
            }
            sale.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1) ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
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

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            if (char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
            DeleteClientIs();
        }
    }
}
