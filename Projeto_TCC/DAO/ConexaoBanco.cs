using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.DAO
{
    class ConexaoBanco
    {
        public static MySqlConnection Conectar()
        {
            string stringConexao = "SERVER=localhost;DATABASE=sgc;UID=root;PASSWORD=12345;";
            MySqlConnection conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }

        public static void CRUD(MySqlCommand comando)
        {
            MySqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();
        }

        public static MySqlDataReader Selecionar(MySqlCommand comando)
        {
            MySqlConnection con = Conectar();
            comando.Connection = con;
            MySqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}
