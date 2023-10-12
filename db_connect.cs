using System.Configuration;
using System.Data.SqlClient;

namespace practica_ADONET_WPF_product__11_10_2023
{
    public class db_connect
    {
        public SqlConnection GetDbConnection()
        {
            // обработка исключений будет выполняться выше по стеку
            string connectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            // connection.Open(); - в отсоединенном режиме подключение открывает и закрывает DbDataAdapter
            return connection;
        }
        // метод проверки соединения (есть или нет) пока не работает 12-10-2023
        public void PingConnection()
        {
            using (SqlConnection connection = GetDbConnection()) { }
        }
    }
}
