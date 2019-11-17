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
    class OcorrenciasDAO
    {


        public void Insert(Ocorrencias ocorrencias)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Ocorrencias(CodMorador,Motivo,Data,BA_Cod) " +
                    "values(@CodMorador,@Motivo,@Data,@BA_Cod)";

                comando.Parameters.AddWithValue("@Motivo", ocorrencias.Motivo);
                comando.Parameters.AddWithValue("@Data", ocorrencias.Data);
                comando.Parameters.AddWithValue("@CodMorador", ocorrencias.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Ba_Cod", ocorrencias.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Ocorrencias ocorrencias)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update ocorrencias set Data=@Data, CodMorador=@CodMorador, Motivo=@Motivo, " +
                    "Ba_Cod=@Ba_Cod where CodOcorrencia=@CodOcorrencia";

                comando.Parameters.AddWithValue("@Data", ocorrencias.Data);
                comando.Parameters.AddWithValue("@CodMorador", ocorrencias.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Motivo", ocorrencias.Motivo);
                comando.Parameters.AddWithValue("@Ba_Cod", ocorrencias.BA.Ba_Cod);
                comando.Parameters.AddWithValue("@CodOcorrencia", ocorrencias.CodOcorrencia);

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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario,  o.motivo as Motivo, o.data as Data" +
                 " from MORADORES M, BA BA, ocorrencias o where" +
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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario,  o.motivo as Motivo, o.data as Data" +
                 " from MORADORES M, BA BA, ocorrencias o where" +
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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.motivo as Motivo, o.data as Data, o.CodOcorrencia" +
                 " from MORADORES M, BA BA, ocorrencias o where" +
                 " apto like @apto and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@apto", "%" + apto + "%");


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


        public DataTable BuscaBlocoComCod(string bloco)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, o.motivo as Motivo, o.data as Data, o.CodOcorrencia" +
                 " from MORADORES M, BA BA, ocorrencias o where" +
                 " bloco like @bloco and o.ba_cod = ba.ba_cod and o.CODMORADOR = M.CODMORADOR ";

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

