using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Remoting.Messaging;//задаём имя т.к. мужик из видео сказал что это может привести к ошибке совместимости с System.data
using System.Windows.Forms;

namespace WindowsFormsAppAutoPartsStore
{
    public partial class FormReport : Form
    {
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM orders";
        string FIOManagerStr;

        public FormReport(string FIOManagerStr)
        {
            InitializeComponent();
            this.FIOManagerStr = FIOManagerStr;
        }
        FormSale formSale; 
        FormWarehouse formWarehouse;
        FormManager formManager;

        public void SetAllForm(FormSale formSale,FormWarehouse formWarehouse, FormManager formManager)
        {
            this.formSale = formSale;
            this.formWarehouse = formWarehouse;
            this.formManager = formManager;
        }

        private void FormReport_Load(object sender, EventArgs e)
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
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"], dbReader["sellingPrice"],
                        dbReader["dataTime"], dbReader["FIOManager"]); // добавляем новые строки
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Descending); // применяем сортировку
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void buttonManegers_Click(object sender, EventArgs e)
        {
            if (FIOManagerStr != "Админ")
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM sale ";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Продаж нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView.Rows.Clear();
                while (dbReader.Read())
                {
                    if (Convert.ToDateTime(dbReader["dataTime"]) >= dateTimePickerWith.Value &&
                                Convert.ToDateTime(dbReader["dataTime"]) <= dateTimePickerBy.Value)
                    {
                        dataGridView.Rows.Add(dbReader["ID"], dbReader["productName"], dbReader["quantity"], dbReader["sellingPrice"],
                                                dbReader["dataTime"], dbReader["FIOManager"]); // добавляем новые строки
                    }   
                }
                dataGridView.Sort(dataGridView.Columns["ID"], ListSortDirection.Descending); // применяем сортировку

                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Продаж за этот период нет!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            for (int i = 0; i <= dataGridView.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView.Columns.Count - 1; j++)
                {
                    wsh.Cells[1, j + 1] = dataGridView.Columns[j].HeaderText.ToString();//записываем название столбцов в excel
                    wsh.Cells[i + 2, j + 1] = dataGridView[j, i].Value.ToString(); //записываем сами строки в exсel
                    //(прибавляем +2 т.к.в excel отсчёт строки начинается с 1 и под 1 индексом у нас название столбца)
                }
            }

            exApp.Visible = true;
        }
    }
}
