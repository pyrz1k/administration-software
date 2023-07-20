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
using System.Xml.Linq;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShopApp
{
    public partial class Form1 : Form
    {
        // строка, включающая в себя путь до нужной БД
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \"C:\\Users\\cherb\\Desktop\\DatabaseTest.mdb\"";
        // строка отвечающая за соединение с БД
        private OleDbConnection conn;

        // создание переменных для реализации графиков
        private DataSet dataset = null;
        private DataTable table = null;
        private DataTable table1 = null;
        private DataTable table2 = null;
        private DataTable table3 = null;
        private DataTable table4 = null;

        public Form1()
        {
            InitializeComponent();

            // создание соединения
            conn = new OleDbConnection(connectString);
            // открытие соединения
            conn.Open();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Аддитивный_критерий". При необходимости она может быть перемещена или удалена.
            this.аддитивный_критерийTableAdapter.Fill(this.databaseTestDataSet.Аддитивный_критерий);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Перемещение3". При необходимости она может быть перемещена или удалена.
            this.перемещение3TableAdapter.Fill(this.databaseTestDataSet.Перемещение3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Перемещение2". При необходимости она может быть перемещена или удалена.
            this.перемещение2TableAdapter.Fill(this.databaseTestDataSet.Перемещение2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Перемещение1". При необходимости она может быть перемещена или удалена.
            this.перемещение1TableAdapter.Fill(this.databaseTestDataSet.Перемещение1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Отдел". При необходимости она может быть перемещена или удалена.
            this.отделTableAdapter.Fill(this.databaseTestDataSet.Отдел);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Покупка". При необходимости она может быть перемещена или удалена.
            this.покупкаTableAdapter.Fill(this.databaseTestDataSet.Покупка);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Содержание_корзины". При необходимости она может быть перемещена или удалена.
            this.содержание_корзиныTableAdapter.Fill(this.databaseTestDataSet.Содержание_корзины);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Корзина". При необходимости она может быть перемещена или удалена.
            this.корзинаTableAdapter.Fill(this.databaseTestDataSet.Корзина);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Пользователь". При необходимости она может быть перемещена или удалена.
            this.пользовательTableAdapter.Fill(this.databaseTestDataSet.Пользователь);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Поставщик". При необходимости она может быть перемещена или удалена.
            this.поставщикTableAdapter.Fill(this.databaseTestDataSet.Поставщик);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Поставка". При необходимости она может быть перемещена или удалена.
            this.поставкаTableAdapter.Fill(this.databaseTestDataSet.Поставка);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Товар". При необходимости она может быть перемещена или удалена.
            this.товарTableAdapter.Fill(this.databaseTestDataSet.Товар);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseTestDataSet.Клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.databaseTestDataSet.Клиент);


            //====================================================================
            //выборка данных из представлений

            string query = "SELECT * From Перемещение1";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            dataset = new DataSet();
            adapter.Fill(dataset, "Place1");
            table = dataset.Tables["Place1"];

            string query1 = "SELECT * From Перемещение2";
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(query1, conn);
            dataset = new DataSet();
            adapter1.Fill(dataset, "Place2");
            table1 = dataset.Tables["Place2"];

            string query2 = "SELECT * From Перемещение3";
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(query2, conn);
            dataset = new DataSet();
            adapter2.Fill(dataset, "Place3");
            table2 = dataset.Tables["Place3"];

            string query3 = "SELECT * From КоличествоПокупокТовара";
            OleDbDataAdapter adapter3 = new OleDbDataAdapter(query3, conn);
            dataset = new DataSet();
            adapter3.Fill(dataset, "КоличествоПокупокТовара");
            table3 = dataset.Tables["КоличествоПокупокТовара"];

            string query4 = "SELECT * From [Аддитивный критерий]";
            OleDbDataAdapter adapter4 = new OleDbDataAdapter(query4, conn);
            dataset = new DataSet();
            adapter4.Fill(dataset, "Аддитивный критерий");
            table4 = dataset.Tables["Аддитивный критерий"];
        }

        //========================================================================
        // взаимодействие с таблицей "Клиент"

        // добавление записи
        private void button1_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox1.Text);
            string fam = textBox2.Text;
            string name = textBox3.Text;
            string otch = textBox4.Text;
            string phone = textBox5.Text;
            // SQL-запрос
            string query = "INSERT INTO Клиент (id_клиента, Фамилия, Имя, Отчество, Телефон) " +
                "VALUES " + "(" + kod + ",'" + fam + "','" + name + "', '" + otch + "', '" + phone + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Клиент добавлен");
            // обновление данных в таблице DataGridView
            this.клиентTableAdapter.Fill(this.databaseTestDataSet.Клиент);
        }

        //обновление записи
        private void button2_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox1.Text);

            if(textBox2.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Клиент SET Фамилия = '" + textBox2.Text +"' Where id_клиента = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox3.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Клиент SET Имя = '" + textBox3.Text + "' Where id_клиента = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox4.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Клиент SET Отчество = '" + textBox4.Text + "' Where id_клиента = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox5.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Клиент SET Телефон = '" + textBox5.Text + "' Where id_клиента = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Клиент обновлен");
            // обновление данных в таблице DataGridView
            this.клиентTableAdapter.Fill(this.databaseTestDataSet.Клиент);
        }

        // удаление записи
        private void button3_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox1.Text);
            // SQL-запрос
            string query = "DELETE FROM Клиент  Where id_клиента = " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Клиент удален");
            // обновление данных в таблице DataGridView
            this.клиентTableAdapter.Fill(this.databaseTestDataSet.Клиент);
        }

        //========================================================================
        // взаимодействие с таблицей "Товар"

        // добавление записи
        private void button4_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox6.Text);
            string name = textBox7.Text;
            string price = textBox8.Text;
            string Date = textBox9.Text;
            // SQL-запрос
            string query = "INSERT INTO Товар (id_товара, Название, Цена, Срок_годности) " +
                "VALUES " + "(" + kod + ",'" + name + "','" + price + "', '" + Date + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Товар добавлен");
            // обновление данных в таблице DataGridView
            this.товарTableAdapter.Fill(this.databaseTestDataSet.Товар);
        }

        // обновление записи
        private void button5_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox6.Text);

            if (textBox7.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Товар SET Название = '" + textBox7.Text + "' Where id_товара = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox8.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Товар SET Цена = '" + textBox8.Text + "' Where id_товара = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox9.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Товар SET Срок_годности = '" + textBox9.Text + "' Where id_товара = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Товар обновлен");
            // обновление данных в таблице DataGridView
            this.товарTableAdapter.Fill(this.databaseTestDataSet.Товар);
        }

        //удаление записи
        private void button6_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox6.Text);
            // SQL-запрос
            string query = "DELETE FROM Товар  Where id_товара= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Товар удален");
            // обновление данных в таблице DataGridView
            this.товарTableAdapter.Fill(this.databaseTestDataSet.Товар);
        }

        //========================================================================
        // взаимодействие с таблицей "Поставка"
        //добавление записи
        private void button7_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox10.Text);
            string tovar = textBox11.Text;
            string count = textBox12.Text;
            string postav = textBox13.Text;
            string Date = textBox14.Text;
            // SQL-запрос
            string query = "INSERT INTO Поставка (id_поставки, id_товара, [кол-во], id_поставщика, дата_поставки) " +
                "VALUES " + "(" + kod + ",'" + tovar + "','" + count + "', '"+ postav +"', '" + Date + "')";

            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Поставка добавлена");
            // обновление данных в таблице DataGridView
            this.поставкаTableAdapter.Fill(this.databaseTestDataSet.Поставка);
        }

        //обновление записи
        private void button8_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox10.Text);

            if (textBox11.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Поставка SET id_товара = '" + textBox11.Text + "' Where id_поставки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox12.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Поставка SET [кол-во] = '" + textBox12.Text + "' Where id_поставки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox13.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Поставка SET id_поставщика = '" + textBox13.Text + "' Where id_поставки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox14.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Поставка SET дата_поставки = '" + textBox14.Text + "' Where id_поставки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об удалении
            MessageBox.Show("Поставка обновлена");
            // обновление данных в таблице DataGridView
            this.поставкаTableAdapter.Fill(this.databaseTestDataSet.Поставка);
        }

        //удаление записи
        private void button9_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox10.Text);
            // SQL-запрос
            string query = "DELETE FROM Поставка  Where id_поставки= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Поставка удалена");
            // обновление данных в таблице DataGridView
            this.поставкаTableAdapter.Fill(this.databaseTestDataSet.Поставка);
        }

        //========================================================================
        // взаимодействие с таблицей "Поставщик"

        //добавление записи
        private void button10_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox15.Text);
            string name = textBox16.Text;
            // SQL-запрос
            string query = "INSERT INTO Поставщик (id_поставщика, Название) " +
                "VALUES " + "(" + kod + ",'" + name + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Поставщик добавлен");
            // обновление данных в таблице DataGridView
            this.поставщикTableAdapter.Fill(this.databaseTestDataSet.Поставщик);
        }

        // изменение записи
        private void button11_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox15.Text);

            if (textBox16.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Поставщик SET Название = '" + textBox16.Text + "' Where id_поставщика = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Поставщик обновлен");
            // обновление данных в таблице DataGridView
            this.поставщикTableAdapter.Fill(this.databaseTestDataSet.Поставщик);
        }

        // удаление записи
        private void button12_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox15.Text);
            // SQL-запрос
            string query = "DELETE FROM Поставщик  Where id_поставщика= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Поставщик удален");
            // обновление данных в таблице DataGridView
            this.поставщикTableAdapter.Fill(this.databaseTestDataSet.Поставщик);
        }

        //========================================================================
        // взаимодействие с таблицей "Пользователь"

        // добавление записи
        private void button13_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox17.Text);
            string log = textBox18.Text;
            string pas = textBox19.Text;
            // SQL-запрос
            string query = "INSERT INTO Пользователь (id_пользователя, Логин, Пароль) " +
                "VALUES " + "(" + kod + ",'" + log + "', '" + pas + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Пользователь добавлен");
            // обновление данных в таблице DataGridView
            this.пользовательTableAdapter.Fill(this.databaseTestDataSet.Пользователь);
        }

        // изменение записи
        private void button14_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox17.Text);

            if (textBox18.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Пользователь SET Логин = '" + textBox18.Text + "' Where id_пользователя = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox19.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Пользователь SET Пароль = '" + textBox19.Text + "' Where id_пользователя = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Пользователь обновлен");
            // обновление данных в таблице DataGridView
            this.пользовательTableAdapter.Fill(this.databaseTestDataSet.Пользователь);
        }

        //удаление записи
        private void button15_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox17.Text);
            // SQL-запрос
            string query = "DELETE FROM Пользователь  Where id_пользователя= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Пользователь удален");
            // обновление данных в таблице DataGridView
            this.пользовательTableAdapter.Fill(this.databaseTestDataSet.Пользователь);
        }

        //========================================================================
        // взаимодействие с таблицей "Корзина"

        // добавление записи
        private void button16_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox20.Text);
            string status = textBox21.Text;
            // SQL-запрос
            string query = "INSERT INTO Корзина (id_корзины, Статус) " +
                "VALUES " + "(" + kod + ",'" + status + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Корзина добавлена");
            // обновление данных в таблице DataGridView
            this.корзинаTableAdapter.Fill(this.databaseTestDataSet.Корзина);
        }

        // изменение записи
        private void button17_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox20.Text);

            if (textBox21.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Корзина SET Статус = '" + textBox21.Text + "' Where id_корзины = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения о добавлении
            MessageBox.Show("Корзина обновлена");
            // обновление данных в таблице DataGridView
            this.корзинаTableAdapter.Fill(this.databaseTestDataSet.Корзина);
        }

        //удаление записи
        private void button18_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox20.Text);
            // SQL-запрос
            string query = "DELETE FROM Корзина  Where id_корзины= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Корзина удалена");
            // обновление данных в таблице DataGridView
            this.корзинаTableAdapter.Fill(this.databaseTestDataSet.Корзина);
        }

        //========================================================================
        // взаимодействие с таблицей "Содержание корзины"

        // добавление записи
        private void button19_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox22.Text);
            string tovar = textBox23.Text;
            string pokupka = textBox24.Text;
            string Date = textBox25.Text;
            // SQL-запрос
            string query = "INSERT INTO Содержание_корзины (id_содержимого, id_товара, id_покупки, дата_покупки) " +
                "VALUES " + "(" + kod + ",'" + tovar + "', '" + pokupka + "', '" + Date + "' )";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Содержимое добавлено");
            // обновление данных в таблице DataGridView
            this.содержание_корзиныTableAdapter.Fill(this.databaseTestDataSet.Содержание_корзины);
        }

        // изменение записи
        private void button20_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox22.Text);

            if (textBox23.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Содержание_корзины SET id_товара = '" + textBox23.Text + "' Where id_содержимого = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox24.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Содержание_корзины SET id_покупки = '" + textBox24.Text + "' Where id_содержимого = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox25.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Содержание_корзины SET дата_покупки = '" + textBox25.Text + "' Where id_содержимого = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об удалении
            MessageBox.Show("Содержимое обновлено");
            // обновление данных в таблице DataGridView
            this.содержание_корзиныTableAdapter.Fill(this.databaseTestDataSet.Содержание_корзины);
        }

        //удаление записи
        private void button21_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox22.Text);
            // SQL-запрос
            string query = "DELETE FROM Содержание_корзины  Where id_содержимого= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Содержимое удалено");
            // обновление данных в таблице DataGridView
            this.содержание_корзиныTableAdapter.Fill(this.databaseTestDataSet.Содержание_корзины);
        }

        //========================================================================
        // взаимодействие с таблицей "Покупка"

        // добавление записи
        private void button22_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox26.Text);
            string  pokupka = textBox27.Text;
            string cart = textBox28.Text;
            DateTime Date = DateTime.Parse(textBox29.Text);
            // SQL-запрос
            string query = "INSERT INTO Покупка (id_покупки, id_корзины, id_клиента, Дата) " +
                "VALUES " + "(" + kod + ",'" + pokupka+ "', '" + cart + "', '" + Date + "' )";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Покупка добавлена");
            // обновление данных в таблице DataGridView
            this.покупкаTableAdapter.Fill(this.databaseTestDataSet.Покупка);
        }

        // изменение записи
        private void button23_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox26.Text);

            if (textBox27.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Покупка SET id_корзины = '" + textBox27.Text + "' Where id_покупки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox28.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Покупка SET id_клиента = '" + textBox28.Text + "' Where id_покупки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            if (textBox29.Text != null)
            {
                DateTime Date = DateTime.Parse(textBox29.Text);
                // SQL-запрос
                string query = "UPDATE Покупка SET Дата = '" + Date + "' Where id_покупки = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Покупка обновлена");
            // обновление данных в таблице DataGridView
            this.покупкаTableAdapter.Fill(this.databaseTestDataSet.Покупка);
        }

        //удаление записи
        private void button24_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox26.Text);
            // SQL-запрос
            string query = "DELETE FROM Покупка  Where id_покупки= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Покупка удалена");
            // обновление данных в таблице DataGridView
            this.покупкаTableAdapter.Fill(this.databaseTestDataSet.Покупка);
        }

        //========================================================================
        // взаимодействие с таблицей "Отдел"

        //добавление записи
        private void button25_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox30.Text);
            string name = textBox31.Text;

            // SQL-запрос
            string query = "INSERT INTO Отдел (id_отдела, Название) " +
                "VALUES " + "(" + kod + ",'" + name + "')";
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение звапроса
            cmd.ExecuteNonQuery();
            // вывод сообщения о добавлении
            MessageBox.Show("Отдел добавлен");
            // обновление данных в таблице DataGridView
            this.отделTableAdapter.Fill(this.databaseTestDataSet.Отдел);
        }

        //обновление записи
        private void button26_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox30.Text);

            if (textBox31.Text != null)
            {
                // SQL-запрос
                string query = "UPDATE Отдел SET Название = '" + textBox31.Text + "' Where id_отдела = " + kod;
                // создание команды с запросом
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // выполнение звапроса
                cmd.ExecuteNonQuery();
            }
            // вывод сообщения об изменении
            MessageBox.Show("Отдел обновлен");
            // обновление данных в таблице DataGridView
            this.отделTableAdapter.Fill(this.databaseTestDataSet.Отдел);
        }

        //удаление записи
        private void button27_Click(object sender, EventArgs e)
        {
            // получение строки по id 
            int kod = Convert.ToInt32(textBox30.Text);
            // SQL-запрос
            string query = "DELETE FROM Отдел  Where id_отдела= " + kod;
            // создание команды с запросом
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // выполнение запроса
            cmd.ExecuteNonQuery();
            // вывод сообщения об удалении
            MessageBox.Show("Отдел удален");
            // обновление данных в таблице DataGridView
            this.отделTableAdapter.Fill(this.databaseTestDataSet.Отдел);
        }


        //============================================================
        // составление графиков и диаграмм

        // составление графика времени по отделам
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in table.Rows)
            {
                double dbl = Convert.ToDouble(row["Place1"]);
                chart1.Series[0].Points.Add(dbl);
            }
            foreach (DataRow row in table1.Rows)
            {
                double dbl = Convert.ToDouble(row["Place2"]);
                chart1.Series[1].Points.Add(dbl);
            }
            foreach (DataRow row in table2.Rows)
            {
                double dbl = Convert.ToDouble(row["Place3"]);
                chart1.Series[2].Points.Add(dbl);
            }
        }

        // очистка графика времени по отделам
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }

        // составление диаграммы покупок товара
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in table3.Rows)
            {
                chart2.Series[0].Points.AddXY(row[1], row[2]);
            }
        }

        // очистка диаграммы покупок товара
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
        }

        // составление диаграммы рейтинга товаров
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in table4.Rows)
            {
                chart3.Series[0].Points.AddXY(row[2], row[1]);
            }
        }

        // очистка диаграммы рейтинга товаров
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            chart3.Series.Clear(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
