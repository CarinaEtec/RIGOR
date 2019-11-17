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
    class VeiculosDAO
    {

        public void Insert(Veiculos veiculos)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Veiculos(CodMorador,Placa,Modelo,Cor,BA_Cod) " +
                    "values(@CodMorador,@Placa,@Modelo,@Cor,@BA_Cod)";

                comando.Parameters.AddWithValue("@Placa", veiculos.Placa);
                comando.Parameters.AddWithValue("@Modelo", veiculos.Modelo);
                comando.Parameters.AddWithValue("@Cor", veiculos.Cor);
                comando.Parameters.AddWithValue("@CodMorador", veiculos.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Ba_Cod", veiculos.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Delete(Veiculos veiculos)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Delete from Veiculos where Placa=@Placa";

                comando.Parameters.AddWithValue("@Placa", veiculos.Placa);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Veiculos veiculos)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update Veiculos set CodMorador=@CodMorador, placa=@placa, modelo=@modelo, " +
                    "cor=@cor, Ba_Cod=@Ba_Cod where placa=@placa";

                comando.Parameters.AddWithValue("@CodMorador", veiculos.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Placa", veiculos.Placa);
                comando.Parameters.AddWithValue("@Modelo", veiculos.Modelo);
                comando.Parameters.AddWithValue("@Cor", veiculos.Cor);
                comando.Parameters.AddWithValue("@Ba_Cod", veiculos.BA.Ba_Cod);

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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, v.placa as Placa, v.modelo as Modelo, v.cor as Cor" +
                             " from MORADORES M, BA BA, VEICULOS v where" +
                             " V.ba_cod = ba.ba_cod AND V.CODMORADOR = M.CODMORADOR AND apto like @apto";
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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, v.placa as Placa, v.modelo as Modelo, v.cor as Cor" +
                             " from MORADORES M, BA BA, VEICULOS v where" +
                             " V.ba_cod = ba.ba_cod AND V.CODMORADOR = M.CODMORADOR AND bloco like @bloco";
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

        public DataTable BuscaPlaca(string placa)
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Proprietario, v.placa as Placa, v.modelo as Modelo, v.cor as Cor" +
                             " from MORADORES M, BA BA, VEICULOS v where" +
                             " V.ba_cod = ba.ba_cod AND V.CODMORADOR = M.CODMORADOR AND placa like @placa";
            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@Placa", placa);



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

