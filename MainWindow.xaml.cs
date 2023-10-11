using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practica_ADONET_WPF_product__11_10_2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // вспомогательная процедура, создающая подключение к БД
        private SqlConnection GetDbConnection()
        {
            // обработка исключений будет выполняться выше по стеку
            string connectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
             //connection.Open(); //- в отсоединенном режиме подключение открывает и закрывает DbDataAdapter
            return connection;
        }

        // вспомогательный метод обновления данных
        private void fillData()
        {
            // вытягивание данных из БД согласно запросу
            dataSet = new DataSet();    // в этот DataSet будет выполняться запись результата вытягивания
            dataAdapter.Fill(dataSet, "product_t");  // выгружаем данные из БД и сохраняем в DataSet
            dataGrid.ItemsSource = dataSet.Tables["product_t"].DefaultView;
        }
        public MainWindow()
        {
            InitializeComponent();
            // подготовка объектов
            dataAdapter = new SqlDataAdapter(fillCmd, GetDbConnection());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);  // строка заполняет INSERT/UPDATE/DELETE-команды
            // реализацией по умолчанию
        }

        // вспомогательные поля
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private string fillCmd = "SELECT * from product_t;";

        private void fillBtn_Click(object sender, RoutedEventArgs e)
        {
            fillData();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            dataAdapter.Update(dataSet, "product_t");
            fillData();

        }
    }
}
