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
    class ObrasDAO
    {
        public void Insert(Obras obras)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Obras(CodMorador,DataHora,BA_Cod) " +
                    "values(@CodMorador,@DataHora,@BA_Cod)";

                comando.Parameters.AddWithValue("@DataHora", obras.DataHora);
                comando.Parameters.AddWithValue("@CodMorador", obras.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Ba_Cod", obras.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Delete(Obras obras)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Delete from Obras where CodObras=@CodObras";

                comando.Parameters.AddWithValue("@CodObras", obras.CodObras);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Obras obras)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update obras set CodMorador=@CodMorador, DataHora=@DataHora, " +
                    "Ba_Cod=@Ba_Cod where CodObras=@CodObras";

                comando.Parameters.AddWithValue("@codObras", obras.CodObras);
                comando.Parameters.AddWithValue("@CodMorador", obras.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@DataHora", obras.DataHora);
                comando.Parameters.AddWithValue("@Ba_Cod", obras.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public DataTable BuscaApto(string apto)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.datahora as DataHora" +
                 " from MORADORES M, BA BA, obras o where" +
                 " apto like @apto and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@apto", "%" + apto + "%");


                da = new MySqlDataAdapter(comando);
                //
                DataTable dtDados = new DataTable();
                da.Fill(dtDados);
                return dtDados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }

        public DataTable BuscaBloco(string bloco)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.datahora as DataHora" +
                 " from MORADORES M, BA BA, obras o where" +
                 " bloco like @bloco and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@bloco", "%" + bloco + "%");


                da = new MySqlDataAdapter(comando);
                //
                DataTable dtDados = new DataTable();
                da.Fill(dtDados);
                return dtDados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }

        public DataTable BuscaAptoComCod(string apto)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.datahora as DataHora, o.codobras as CodObras" +
                 " from MORADORES M, BA BA, obras o where" +
                 " apto like @apto and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@apto", "%" + apto + "%");


                da = new MySqlDataAdapter(comando);
                //
                DataTable dtDados = new DataTable();
                da.Fill(dtDados);
                return dtDados;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }

        public DataTable BuscaBlocoComCod(string bloco)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.datahora as DataHora, o.codobras as CodObras" +
                 " from MORADORES M, BA BA, obras o where" +
                 " bloco like @bloco and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@bloco", "%" + bloco + "%");


                da = new MySqlDataAdapter(comando);
                //
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
