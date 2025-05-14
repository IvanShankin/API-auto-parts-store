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
    public partial class FormWarehouse : Form
    {
        public FormWarehouse(string FIOManager)
        {
            InitializeComponent();
            this.FIOManager = FIOManager;
        }
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM product";

        string FIOManager = "";

        FormSale formSale;
        FormManager formManager;
        FormReport formReport;

        public void SetAllForm(FormSale formSale, FormManager formManager , FormReport formReport)
        {
            this.formSale = formSale;
            this.formManager = formManager;
            this.formReport = formReport;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FormWarehouse_Load(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM product";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Товаров нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();

                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"], dbReader["prise"], 
                        dbReader["whatCarsIsItCompatibleWith"], dbReader["description"]); // добавляем новые строки
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Descending); // применяем сортировку
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            formSale.Show();
            formSale.Location = this.Location; // Сохраняет координаты текущей формы
            formSale.Size = this.Size;
            this.Hide();
        }

        private void buttonManegers_Click(object sender, EventArgs e)
        {
            if (FIOManager != "Админ")
            {
                MessageBox.Show("У вас недостаточно прав \nдля открытия этого раздела", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                formManager.Show();
                formManager.Location = this.Location;
                formManager.Size = this.Size;
                this.Hide();
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            formReport.Show();
            formReport.Location = this.Location; // Сохраняет координаты текущей формы
            formReport.Size = this.Size;
            this.Hide();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearchName.Text == "")
            {
                MessageBox.Show("Заполните поле с услугой по которому хотите искать!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name_service = textBoxSearchName.Text.ToString();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM product WHERE productName = '" + name_service + "'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Товара с таким именем нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();
                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"],
                                        dbReader["prise"], dbReader["whatCarsIsItCompatibleWith"], dbReader["description"] ); // добавляем новые строки
                                                                                         // добавляем новые строки
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Ascending); // применяем сортировку
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
            { MessageBox.Show("Пожалуйста, Выберите хотя бы одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 
            dbConnection.Open();//открытие соеденения

            for (int i = dataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                // Получаем первую выбранную строку
                DataGridViewRow selectedRow = dataGridView.SelectedRows[i];

                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                string query = "DELETE FROM product WHERE ID = " + id;//сам запрос
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда которую надо выполнить

                if (dbCommand.ExecuteNonQuery() != 1)//это выполнение запроса, а так же он возвращает кол-во именённых строк 
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                dataGridView.Rows.Remove(selectedRow);//удаляем выбранную строку
            }
            //выполнение запроса 
            
            MessageBox.Show("Данные Удалены", "Готово!");

            //закрытие соединения с БД
            dbConnection.Close();
        }

        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            FormWarehouseChange formServiceChange = new FormWarehouseChange(this, true);
            formServiceChange.ShowDialog();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 1)
            { MessageBox.Show("Пожалуйста, Выберите только одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            string productName = Convert.ToString(selectedRow.Cells["productName"].Value);
            int quantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
            int prise = Convert.ToInt32(selectedRow.Cells["prise"].Value);
            string whatCarsIsItCompatibleWith = Convert.ToString(selectedRow.Cells["whatCarsIsItCompatibleWith"].Value);
            string description = Convert.ToString(selectedRow.Cells["description"].Value);

            FormWarehouseChange formServiceChange = new FormWarehouseChange(this, false, id, productName, quantity,
                                                                            prise, whatCarsIsItCompatibleWith, description);
            formServiceChange.ShowDialog();

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

    }
}
