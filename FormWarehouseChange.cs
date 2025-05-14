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
    public partial class FormWarehouseChange : Form
    {
        FormWarehouse formWarehous;
        bool add;

        int id;
        string product;
        int quantity;
        int prise;
        string WhatCarsIsItCompatibleWith;// для каких машин подходит 
        string description;

        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
        string query = "SELECT * FROM product";
        public FormWarehouseChange(FormWarehouse formWarehous, bool add, int id = 0, string product = "", int quantity = 0, int prise = 0, 
                                    string WhatCarsIsItCompatibleWith = "", string description = "")
        {
            InitializeComponent();

            this.formWarehous = formWarehous;
            this.add = add;
            this.id = id;
            this.product = product;
            this.quantity = quantity;
            this.prise = prise;
            this.WhatCarsIsItCompatibleWith = WhatCarsIsItCompatibleWith;
            this.description = description;
        }

        private void FormWarehouseChange_Load(object sender, EventArgs e)
        {
            if (add == false) // если изменяем данные 
            {
                buttonConfirmation.Text = "Сохранить";
                textBoxInfo.Text = "Изменение Товара";
            }

            textBoxProduct.Text = product;
            numericQuantityProduct.Value = quantity;
            textBoxPrise.Text = prise.ToString();
            richTextBoxWhatCarsIsItCompatibleWith.Text = WhatCarsIsItCompatibleWith;
            richTextBoxDescription.Text = description;
        }

        private void buttonConfirmation_Click(object sender, EventArgs e)
        {
            if (textBoxProduct.Text == "" || textBoxPrise.Text == "" || richTextBoxWhatCarsIsItCompatibleWith.Text == "" ||
                richTextBoxDescription.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соединения
            if (add == true)
            {
                query = "SELECT * FROM product WHERE productName = '" + textBoxProduct.Text.ToString() + "'";
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                OleDbDataReader dbReader = dbCommand.ExecuteReader();

                if (dbReader.HasRows == true)
                {
                    MessageBox.Show("Товар с таким именем уже есть!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string queryAdd = "INSERT INTO product (productName, quantity, prise, whatCarsIsItCompatibleWith, description) " +
                                      "VALUES ( ?, ?, ?, ?, ?)"; // Знак вопроса - это параметры
                    using (OleDbCommand dbCommandAdd = new OleDbCommand(queryAdd, dbConnection))
                    {
                        // Добавление параметров
                        dbCommandAdd.Parameters.AddWithValue("?", textBoxProduct.Text.ToString());
                        dbCommandAdd.Parameters.AddWithValue("?", Convert.ToInt32(numericQuantityProduct.Value));
                        dbCommandAdd.Parameters.AddWithValue("?", Convert.ToInt32(textBoxPrise.Text));
                        dbCommandAdd.Parameters.AddWithValue("?", richTextBoxWhatCarsIsItCompatibleWith.Text.ToString());
                        dbCommandAdd.Parameters.AddWithValue("?", richTextBoxDescription.Text.ToString());
                        //выполнение запроса 
                        if (dbCommandAdd.ExecuteNonQuery() != 1)//это выполнение команды,а так же этот метот возвращает кол-во добавленных строк 
                        { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                        else
                        {

                            MessageBox.Show("Данные добавленны", "Готово!");
                            formWarehous.FormWarehouse_Load(sender, e);
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                query = "UPDATE product SET productName = ?, quantity = ?, prise = ?, whatCarsIsItCompatibleWith = ?, description = ? WHERE ID = ?";//сам запрос

                using (OleDbCommand dbCommandChange = new OleDbCommand(query, dbConnection))
                {
                    // Заменяем параметры на настоящие значения
                    dbCommandChange.Parameters.AddWithValue("?", textBoxProduct.Text.ToString());
                    dbCommandChange.Parameters.AddWithValue("?", Convert.ToInt32(numericQuantityProduct.Value));
                    dbCommandChange.Parameters.AddWithValue("?", Convert.ToInt32(textBoxPrise.Text));
                    dbCommandChange.Parameters.AddWithValue("?", richTextBoxWhatCarsIsItCompatibleWith.Text.ToString());
                    dbCommandChange.Parameters.AddWithValue("?", richTextBoxDescription.Text.ToString());
                    dbCommandChange.Parameters.AddWithValue("?", id);

                    //выполнение запроса 
                    if (dbCommandChange.ExecuteNonQuery() != 1)//это выполнение запроса, а так же метот возвращает кол-во добавленных строк 
                    { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }
                    else
                    {
                        MessageBox.Show("Данные изменены", "Готово!");
                        formWarehous.FormWarehouse_Load(sender, e);
                        this.Close();
                    }
                }
            }
            dbConnection.Close(); //закрытие соединения с БД
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

        private void textBoxPrise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }// запрещаем вписывать любые значения кроме цифр
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
