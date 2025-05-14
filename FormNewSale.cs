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
using System.Windows.Forms;

namespace WindowsFormsAppAutoPartsStore
{
    public partial class FormNewSale : Form
    {
        string query = "";
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";

        int id = 0;
        string FIOManeger = "";
        FormSale formSale;
        public FormNewSale(string FIOManeger, FormSale formSale)
        {
            InitializeComponent();
            this.FIOManeger = FIOManeger;
            this.formSale = formSale;   
        }

        private void FormNewSale_Load(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM product";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("У нет ни одного товара!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                while (dbReader.Read())
                {
                    comboBoxProduct.Items.Add(dbReader["productName"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();

        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            query = "SELECT * FROM product WHERE productName = '" + comboBoxProduct.Text + "'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
            {
                id = Convert.ToInt32(dbReader["ID"]);
                HavingQuantity.Text = Convert.ToString(dbReader["quantity"]);
                numericUpDown1.Maximum = Convert.ToInt32(HavingQuantity.Text);
                richTextBoxWhatCarsIsItCompatibleWith.Text = Convert.ToString(dbReader["whatCarsIsItCompatibleWith"]);
                richTextBoxDescription.Text = Convert.ToString(dbReader["description"]);
                PriseOneProduct.Text = Convert.ToString(dbReader["prise"]);
            }

            dbReader.Close();
            dbConnection.Close();
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(numericUpDown1.Value);

            LabelPrise.Text = Convert.ToString(quantity * Convert.ToInt32(PriseOneProduct.Text));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericUpDown1.Text) == 0 || comboBoxProduct.Text == "")
            {
                MessageBox.Show("Выберите количество товара!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соединение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соединения

            string queryAdd = "INSERT INTO sale (productName, quantity, sellingPrice, dataTime, FIOManager) " +
                                  "VALUES ( ?, ?, ?, ?, ?)"; // Знак вопроса - это параметры
            using (OleDbCommand dbCommandAdd = new OleDbCommand(queryAdd, dbConnection))
            {
                // Добавление параметров
                dbCommandAdd.Parameters.AddWithValue("?", comboBoxProduct.Text.ToString());
                dbCommandAdd.Parameters.AddWithValue("?", Convert.ToInt32(numericUpDown1.Value));
                dbCommandAdd.Parameters.AddWithValue("?", Convert.ToInt32(LabelPrise.Text));
                dbCommandAdd.Parameters.AddWithValue("?", DateTime.Now.ToString());
                dbCommandAdd.Parameters.AddWithValue("?", FIOManeger);
                //выполнение запроса 
                if (dbCommandAdd.ExecuteNonQuery() != 1)//это выполнение команды,а так же этот метот возвращает кол-во добавленных строк 
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }

            }

            query = "UPDATE product SET quantity = ? WHERE ID = ?";//сам запрос

            using (OleDbCommand dbCommandChange = new OleDbCommand(query, dbConnection))
            {
                // Заменяем параметры на настоящие значения
                dbCommandChange.Parameters.AddWithValue("?", Convert.ToInt32(HavingQuantity.Text) - Convert.ToInt32(numericUpDown1.Value));
                dbCommandChange.Parameters.AddWithValue("?", id);

                //выполнение запроса 
                if (dbCommandChange.ExecuteNonQuery() != 1)//это выполнение запроса, а так же метот возвращает кол-во добавленных строк 
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                else
                {
                    MessageBox.Show("Покупка совершена!", "Готово!");
                    formSale.FormSale_Load(sender, e);
                    this.Close();
                }
            }
            dbConnection.Close(); //закрытие соединения с БД
        }

        
    }
}
