using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppAutoPartsStore
{
    public partial class FormManagerChange : Form
    {
        FormManager formManager;
        bool add;

        int id;
        string FIO;
        string phone;
        int salary;
        string login;// для каких машин подходит 
        string password;

        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM product";
        public FormManagerChange(FormManager formManager, bool add, int id = 0, string FIO = "",string phone = "",
                                int salary = 0,string login = "", string password = "")
        {
            InitializeComponent();
            this.formManager = formManager;
            this.add = add;
            this.id = id;
            this.FIO = FIO;
            this.phone = phone;
            this.salary = salary;
            this.login = login;
            this.password = password;
        }

        private void FormManagerChange_Load(object sender, EventArgs e)
        {
            if (add == false) // если изменяем данные 
            {
                buttonConfirmation.Text = "Сохранить";
                textBoxInfo.Text = "Изменение данных";
            }

            textBoxFIO.Text = FIO;
            maskedTextBoxPhone.Text = phone;
            textBoxSalary.Text = salary.ToString();
            textBoxLogin.Text = login;
            textBoxPassword.Text = password;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }// запрещаем вписывать любые значения кроме цифр
        }

        private void buttonConfirmation_Click(object sender, EventArgs e)
        {
            if (textBoxFIO.Text == "" || maskedTextBoxPhone.Text == "" || textBoxSalary.Text == "" ||
                textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соединение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соединения
            query = "SELECT * FROM manager WHERE loginManager = '" + textBoxLogin.Text.ToString() + "'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == true)
            {
                MessageBox.Show("Сотрудник с таким логином уже есть!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (add == true)
                {

                    string queryAdd = "INSERT INTO manager (FIOManager, phone, salary, loginManager, passwordManager) " +
                                          "VALUES ( ?, ?, ?, ?, ?)"; // Знак вопроса - это параметры
                    using (OleDbCommand dbCommandAdd = new OleDbCommand(queryAdd, dbConnection))
                    {
                        // Добавление параметров
                        dbCommandAdd.Parameters.AddWithValue("?", textBoxFIO.Text.ToString());
                        dbCommandAdd.Parameters.AddWithValue("?", maskedTextBoxPhone.Text.ToString());
                        dbCommandAdd.Parameters.AddWithValue("?", Convert.ToInt32(textBoxSalary.Text));
                        dbCommandAdd.Parameters.AddWithValue("?", textBoxLogin.Text.ToString());
                        dbCommandAdd.Parameters.AddWithValue("?", textBoxPassword.Text.ToString());
                        //выполнение запроса 
                        if (dbCommandAdd.ExecuteNonQuery() != 1)//это выполнение команды,а так же этот метод возвращает кол-во добавленных строк 
                        { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                        else
                        {
                            MessageBox.Show("Данные добавлены", "Готово!");
                            formManager.FormManager_Load(sender, e);
                            this.Close();
                        }
                    }

                }
                else
                {
                    query = "UPDATE manager SET FIOManager = ?, phone = ?, salary = ?, loginManager = ?, passwordManager = ? WHERE ID = ?";//сам запрос

                    using (OleDbCommand dbCommandChange = new OleDbCommand(query, dbConnection))
                    {
                        // Заменяем параметры на настоящие значения
                        dbCommandChange.Parameters.AddWithValue("?", textBoxFIO.Text.ToString());
                        dbCommandChange.Parameters.AddWithValue("?", maskedTextBoxPhone.Text.ToString());
                        dbCommandChange.Parameters.AddWithValue("?", Convert.ToInt32(textBoxSalary.Text));
                        dbCommandChange.Parameters.AddWithValue("?", textBoxLogin.Text.ToString());
                        dbCommandChange.Parameters.AddWithValue("?", textBoxPassword.Text.ToString());
                        dbCommandChange.Parameters.AddWithValue("?", id);

                        //выполнение запроса 
                        if (dbCommandChange.ExecuteNonQuery() != 1)//это выполнение запроса, а так же метод возвращает кол-во добавленных строк 
                        { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                        else
                        {
                            MessageBox.Show("Данные изменены", "Готово!");
                            formManager.FormManager_Load(sender, e);
                            this.Close();
                        }
                    }
                }
            }
            dbConnection.Close(); //закрытие соединения с БД
        }
        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackColor = Color.White; // меняем цвет при отжатии 
            }
        }
        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackColor = Color.FromArgb(210, 210, 213); // Цвет при нажатии
            }
        }

    }
}
