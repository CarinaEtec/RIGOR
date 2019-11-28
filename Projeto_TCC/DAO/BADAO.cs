using MySql.Data.MySqlClient;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.DAO
{
    class BADAO
    {
        public void Insert(BA ba) //Inserir 
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                "Insert into BA(Apto,Bloco) values(@Apto,@Bloco)";

                comando.Parameters.AddWithValue("@Apto", ba.Apto);
                comando.Parameters.AddWithValue("@Bloco", ba.Bloco);
                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }


        public BA BuscaCodBA(string Apto, string Bloco) //Busca pelo apto e cód
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from BA where Bloco=@Bloco AND Apto=@Apto";

            comando.Parameters.AddWithValue("@Bloco", Bloco);
            comando.Parameters.AddWithValue("@Apto", Apto);

            MySqlDataReader dr = ConexaoBanco.Selecionar(comando);

            BA ba = new BA();
            if (dr.HasRows)
            {
                dr.Read();
                ba.Ba_Cod = (int)dr["Ba_Cod"];
                ba.Apto = (string)dr["Apto"];
                ba.Bloco = (string)dr["Bloco"];
            }
            else
            {
                ba.Ba_Cod = 0;
                ba.Apto = "";
                ba.Bloco = "";
            }
            return ba;
        }

        public DataTable Consulta(string bloco) //Condulta
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select bloco as Bloco, apto as Apto from BA where bloco like @bloco";
            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@bloco", "%" + bloco + "%");

                da = new MySqlDataAdapter(comando);

                DataTable dtDados = new DataTable();
                da.Fill(dtDados);
                return dtDados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }

    }
}
