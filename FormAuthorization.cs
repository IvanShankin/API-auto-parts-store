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
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }
        
        bool manager = true;  // флаг использования приложения менеджером
        string FIOManager = "";
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";


        private void button1_Click(object sender, EventArgs e)
        {
            if (manager == true) // если выбрали роль менеджера
            {
                OleDbConnection dbConnection = new OleDbConnection(connectionString);

                dbConnection.Open();
                string query = "SELECT FIOManager FROM manager WHERE loginManager = @login AND passwordManager = @password";
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                // Добавляем параметр для защиты от SQL-инъекций
                dbCommand.Parameters.AddWithValue("@login", textBoxLogin.Text.ToString());
                dbCommand.Parameters.AddWithValue("@password", textBoxPassword.Text.ToString());

                OleDbDataReader dbReader = dbCommand.ExecuteReader();
                if (dbReader.Read())
                {
                    if (dbReader.HasRows == true)
                    {
                        FIOManager = dbReader["FIOManager"].ToString();

                        FormWarehouse formWarehouse = new FormWarehouse(FIOManager);
                        FormReport formReport = new FormReport(FIOManager);
                        FormManager formManager = new FormManager();

                        FormSale sale = new FormSale(formWarehouse, formReport, formManager, FIOManager);
                        this.Hide();
                        sale.Show();

                    }
                    else
                    {
                        MessageBox.Show("Введён не верный логин или пароль!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                dbReader.Close();
                dbConnection.Close();
            }
            else // если выбрали роль админа
            {
                if (textBoxPassword.Text.ToString() == "admin")
                {
                    FormWarehouse formWarehouse = new FormWarehouse("Админ");
                    FormReport formReport = new FormReport("Админ");
                    FormManager formManager = new FormManager();

                    FormSale sale = new FormSale(formWarehouse, formReport, formManager, "Админ");
                    this.Hide();
                    sale.Show();
                }
                else
                {
                    MessageBox.Show("Введён неверный пароль!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBoxLogin.Visible = false;
            this.textBoxPassword.Location = new System.Drawing.Point(177, 80);
            this.label2.Location = new System.Drawing.Point(66, 80);
            this.button2.Location = new System.Drawing.Point(334, 80);
            this.buttonNoVisible.Location = new System.Drawing.Point(334, 80);

            buttonMenedger.BackColor = SystemColors.Control;
            buttonAdmin.BackColor = Color.White;

            manager = false;
        }
        private void buttonMenedger_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBoxLogin.Visible = true;
            this.textBoxPassword.Location = new System.Drawing.Point(177, 99);
            this.label2.Location = new System.Drawing.Point(66, 99);
            this.button2.Location = new System.Drawing.Point(334, 99);
            this.buttonNoVisible.Location = new System.Drawing.Point(334, 99);

            buttonAdmin.BackColor = SystemColors.Control;
            buttonMenedger.BackColor = Color.White;

            manager = true;
        }
        private void buttonNoVisible_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            buttonNoVisible.Visible = false;
            button2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            button2.Visible = false;
            buttonNoVisible.Visible = true;
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackColor = Color.FromArgb(210, 210, 213); // Цвет при нажатии
            }
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            // Приводим sender к типу Button 
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackColor = Color.White; // меняем цвет при отжатии 
            }
        }

        public bool get_Check_Manager()
        {
            return manager;
        }
        public string get_FIO_Manager()
        {
            return FIOManager;
        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }
    }
}
