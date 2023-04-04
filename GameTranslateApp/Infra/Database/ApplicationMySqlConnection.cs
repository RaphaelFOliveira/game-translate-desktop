using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTranslateApp.Infra.Database
{
    internal class ApplicationMySqlConnection
    {

        public MySqlConnection ConnectionDbGameTranslate()
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection("server=localhost;uid=root;pwd=root;database=game_translate");

                return cnn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de conexão: " + e.Message);
                return null;
            }
        }
    }
}
