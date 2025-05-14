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

namespace WindowsFormsAppAutoPartsStore
{
    public partial class FormManager : Form
    {
        public FormManager()
        {
            InitializeComponent();
        }

        FormSale formSale;
        FormWarehouse formWarehouse;
        FormReport formReport;

        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM product";
        public void SetAllForm(FormSale formSale, FormWarehouse formWarehouse, FormReport formReport)
        {
            this.formSale = formSale;
            this.formWarehouse = formWarehouse;
            this.formReport = formReport;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FormManager_Load(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM manager";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Персонала нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();

                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["FIOManager"], dbReader["phone"], dbReader["salary" ] + " ₽",
                        dbReader["loginManager"], dbReader["passwordManager"]); // добавляем новые строки
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Descending); // применяем сортировку
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearchName.Text == "")
            {
                MessageBox.Show("Заполните поле с искомым ФИО персонала!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string FIO = textBoxSearchName.Text.ToString();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM manager WHERE FIOManager = '" + FIO + "'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Персонала с таким ФИО нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();
                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["FIOManager"], dbReader["phone"], dbReader["salary"] + " ₽",
                       dbReader["loginManager"], dbReader["passwordManager"]); // добавляем новые строки 
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Ascending); // применяем сортировку
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
            { MessageBox.Show("Пожалуйста, Выберите хотя бы одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соединение 
            dbConnection.Open();//открытие соединения

            for (int i = dataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                // Получаем первую выбранную строку
                DataGridViewRow selectedRow = dataGridView.SelectedRows[i];

                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                string query = "DELETE FROM manager WHERE ID = " + id;//сам запрос
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда которую надо выполнить

                if (dbCommand.ExecuteNonQuery() != 1)//это выполнение запроса, а так же он возвращает кол-во изменённых строк 
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                dataGridView.Rows.Remove(selectedRow);//удаляем выбранную строку
            }
            //выполнение запроса 

            MessageBox.Show("Данные Удалены", "Готово!");

            //закрытие соединения с БД
            dbConnection.Close();
        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            formSale.Show();
            formSale.Location = this.Location; // Сохраняет координаты текущей формы
            formSale.Size = this.Size;
            this.Hide();
        }

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            formWarehouse.Show();
            formWarehouse.Location = this.Location; 
            formWarehouse.Size = this.Size;
            this.Hide();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            formReport.Show();
            formReport.Location = this.Location; 
            formReport.Size = this.Size;
            this.Hide();
        }

        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is Button button)
            {
                button.BackColor = Color.White; // меняем цвет при отжатии 
            }
        }

        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(210, 210, 213); // Цвет при нажатии
            }
        }

        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            FormManagerChange formServiceChange = new FormManagerChange(this, true);
            formServiceChange.ShowDialog();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 1)
            { MessageBox.Show("Пожалуйста, Выберите только одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            string FIOManager = Convert.ToString(selectedRow.Cells["FIOManager"].Value);
            string phone = Convert.ToString(selectedRow.Cells["phone"].Value);
            string salaryStr = selectedRow.Cells["salary"].Value.ToString(); // этот параметре не передается, а используется для фунции ниже
            int salary = Convert.ToInt32(salaryStr.Substring(0, salaryStr.Length - 2));
            string login = Convert.ToString(selectedRow.Cells["login"].Value);
            string password = Convert.ToString(selectedRow.Cells["password"].Value);

            FormManagerChange formServiceChange = new FormManagerChange(this, false, id, FIOManager, phone,
                                                                            salary, login, password);
            formServiceChange.ShowDialog();
        }
    }
}
