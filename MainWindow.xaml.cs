using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System;

namespace practica_ADONET_WPF_product__11_10_2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // создаем приватный обьект для видимости методов
        private db_connect Db_Connect;
        // вспомогательные поля
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        // вспомогательный метод обновления данных
        private void fillData()
        {
            try
            {
                // вытягивание данных из БД согласно запросу
                dataSet = new DataSet();    // в этот DataSet будет выполняться запись результата вытягивания
                dataAdapter.Fill(dataSet, "product_t");  // выгружаем данные из БД и сохраняем в DataSet
                dataGrid.ItemsSource = dataSet.Tables["product_t"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            // создаем новый экземпляр обьекта для соединения
            Db_Connect = new db_connect();
            // подготовка объектов
            dataAdapter = new SqlDataAdapter(fillCmd, Db_Connect.GetDbConnection());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);  // строка заполняет INSERT/UPDATE/DELETE-команды
            //c реализацией по умолчанию
        }


        private string fillCmd = "SELECT * from product_t p";
        //  ,supplier_t s, type_t t " +
        //  "where  p.type_id_f = t.id_f and p.supplier_id_f = s.id_f;";
        private void fillBtn_Click(object sender, RoutedEventArgs e)
        {
            fillData();
        }
        // обновляем таблицу в базе данных
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataAdapter.Update(dataSet, "product_t");
                fillData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // проверяем соединение к базе данных
        private void testconbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db_connect Db_con = new db_connect();
                Db_con.PingConnection();
                MessageBox.Show("Подключено к базе");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не Подключено к базе" + ex.ToString());
            }

        }
    }
}
