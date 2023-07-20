using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ShopApp.Properties;

namespace ShopApp
{
    public partial class Form2 : Form
    {

        // строка, включающая в себя путь до нужной БД
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \"C:\\Users\\cherb\\Desktop\\DatabaseTest.mdb\"";
        // строка отвечающая за соединение с БД
        private OleDbConnection conn;

        public Form2()
        {
            InitializeComponent();

            // присваивание полям ввода значений по умолчанию
            textBox1.Text = Settings.Default["Login"].ToString();
            textBox2.Text = Settings.Default["Pas"].ToString();

            //создание подключения
            conn = new OleDbConnection(connectString);

            // открытие подключения
            conn.Open();

            // скрыть ввод пароля
            this.textBox2.UseSystemPasswordChar = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // класс подключения к БД, для дальнейшего заполнения DataTable 
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            // создание DataTable
            DataTable table = new DataTable();

            // строка запроса к БД
            string query = "Select * FROM Пользователь WHERE Логин = '"+ textBox1.Text +"' and Пароль = '" + textBox2.Text+ "' ";
            // выполнение запроса
            OleDbCommand cmd = new OleDbCommand(query, conn);

            // получение результата запроса
            adapter.SelectCommand = cmd;
            // внесение полученных данных в table
            adapter.Fill(table);


            // проверка корректности данных
            if (table.Rows.Count > 0 ) 
            {
                // текущая форма скрывается
                this.Hide();

                // передача Form1
                Form1 newForm1 = new Form1();
                // открытие Form1
                newForm1.Show();

                // проверка нажатия кнопки "Запомнить меня"
                if(checkBox1.Checked) 
                {
                    // установка значений по умолчанию
                    Settings.Default["Login"] = textBox1.Text;
                    Settings.Default["Pas"] = textBox2.Text;
                    Settings.Default.Save();
                }
                else
                {
                    // сброс значений по умолчанию
                    Settings.Default["Login"] = "";
                    Settings.Default["Pas"] = "";
                    Settings.Default.Save();
                }
            }
            // некорректный ввод данных
            else
            {
                // показ сообщения об ошибке
                label4.Show();
                //сброс введенных полей
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        // показ пароля
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                this.textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
