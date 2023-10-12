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
        public void PingConnection()
        {
            using (SqlConnection connection = GetDbConnection()) { }
        }
    }
}
