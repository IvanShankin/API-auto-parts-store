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
    public partial class FormSale : Form
    {
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM orders";

        FormWarehouse formWarehouse;
        FormReport formReport;
        FormManager formManager;

        string FIOMeneger;
        public FormSale(FormWarehouse formWarehouse, FormReport formReport, FormManager formManager, string FIOMeneger)
        {
            InitializeComponent();
            this.formWarehouse = formWarehouse;
            this.formReport = formReport;
            this.formManager = formManager;
            this.FIOMeneger = FIOMeneger;

            // передаём другим формам формы с которыми работаем
            this.formWarehouse.SetAllForm(this, formManager, formReport);
            this.formReport.SetAllForm(this, formWarehouse, formManager);
            this.formManager.SetAllForm(this, formWarehouse, formReport);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FormSale_Load(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM sale";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Истории продаж нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();

                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"], dbReader["sellingPrice"], dbReader["dataTime"]); // добавляем новые строки
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
                MessageBox.Show("Заполните поле с услугой по которому хотите искать!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name_service = textBoxSearchName.Text.ToString();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM sale WHERE productName = '" + name_service + "'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Продаж с таким продуктом нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();
                while (dbReader.Read())
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"],
                                        dbReader["sellingPrice"], dbReader["dataTime"]); // добавляем новые строки
                                                                                                                                                          // добавляем новые строки
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Ascending); // применяем сортировку
            }
        }

        private void buttonNewSale_Click(object sender, EventArgs e)
        {

            FormNewSale formServiceChange = new FormNewSale(FIOMeneger,this);
            formServiceChange.ShowDialog();
        }

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            formWarehouse.FormWarehouse_Load(sender, e);
            formWarehouse.Show();
            formWarehouse.Location = this.Location; // Сохраняет координаты текущей формы
            formWarehouse.Size = this.Size;
            this.Hide();
        }

        private void buttonManegers_Click(object sender, EventArgs e)
        {
            if (FIOMeneger != "Админ")
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

    }
}
