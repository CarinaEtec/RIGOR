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
    class LocacoesDAO
    {
        public void Insert(Locacoes loc) //Inserir
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Locacoes(CodMorador,Inicio,Termino,BA_Cod) " +
                    "values(@CodMorador,@Inicio,@Termino,@BA_Cod)";

                comando.Parameters.AddWithValue("@Inicio", loc.Inicio);
                comando.Parameters.AddWithValue("@Termino", loc.Termino);
                comando.Parameters.AddWithValue("@CodMorador", loc.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Ba_Cod", loc.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Delete(Locacoes loc) //Deletar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Delete from Locacoes where CodLocacao=@CodLocacao";

                comando.Parameters.AddWithValue("@CodLocacao", loc.CodLocacao);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Locacoes loc) //Editar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update Locacoes set CodMorador=@CodMorador, Inicio=@Inicio, Termino=@Termino, " +
                    "Ba_Cod=@Ba_Cod where CodLocacao=@CodLocacao";

                comando.Parameters.AddWithValue("@CodLocacao", loc.CodLocacao);
                comando.Parameters.AddWithValue("@CodMorador", loc.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Inicio", loc.Inicio);
                comando.Parameters.AddWithValue("@Termino", loc.Termino);
                comando.Parameters.AddWithValue("@Ba_Cod", loc.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public DataTable BuscaApto(string apto) //Busca pelo apto
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, l.Inicio as Inicio, l.Termino as Termino" +
                             " from MORADORES M, BA BA, LOCACOES L where" +
                             " L.ba_cod = ba.ba_cod AND L.CODMORADOR = M.CODMORADOR AND apto like @apto";
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

        public DataTable BuscaBloco(string bloco) //Busca pelo bloco
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, l.Inicio as Inicio, l.Termino as Termino" +
                             " from MORADORES M, BA BA, LOCACOES L where" +
                             " L.ba_cod = ba.ba_cod AND L.CODMORADOR = M.CODMORADOR AND bloco like @bloco";
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

        public DataTable BuscaAptoComCod(string apto) //Busca pelo apto, contendo o campo código, para tela de alteração
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, l.Inicio as Inicio, l.Termino as Termino, l.codlocacao As CodLocacao" +
                             " from MORADORES M, BA BA, LOCACOES L where" +
                             " L.ba_cod = ba.ba_cod AND L.CODMORADOR = M.CODMORADOR AND apto like @apto";
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

        public DataTable BuscaBlocoComCod(string bloco) //Busca pelo bloco, contendo o campo código, para tela de alteração
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, l.Inicio as Inicio, l.Termino as Termino, l.codlocacao As CodLocacao" +
                             " from MORADORES M, BA BA, LOCACOES L where" +
                             " L.ba_cod = ba.ba_cod AND L.CODMORADOR = M.CODMORADOR AND bloco like @bloco";
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

