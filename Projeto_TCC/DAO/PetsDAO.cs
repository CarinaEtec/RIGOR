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
    class PetsDAO
    {
        public void Insert(Pets pets) //Inserir
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Pets(nome,CodMorador,Especie,BA_Cod) " +
                    "values(@nome,@CodMorador,@Especie,@BA_Cod)";

                comando.Parameters.AddWithValue("@nome", pets.Nome);
                comando.Parameters.AddWithValue("@CodMorador", pets.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Especie", pets.Especie);
                comando.Parameters.AddWithValue("@Ba_Cod", pets.BA.Ba_Cod);


                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Delete(Pets pets) //Deletar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Delete from Pets where CodPet=@CodPet";

                comando.Parameters.AddWithValue("@CodPet", pets.CodPet);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Pets pets) //Editar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update Pets set nome=@nome, CodMorador=@CodMorador, Especie=@Especie, " +
                    "Ba_Cod=@Ba_Cod where CodPet=@CodPet";

                comando.Parameters.AddWithValue("@nome", pets.Nome);
                comando.Parameters.AddWithValue("@CodMorador", pets.Moradores.CodMorador);
                comando.Parameters.AddWithValue("@Especie", pets.Especie);
                comando.Parameters.AddWithValue("@Ba_Cod", pets.BA.Ba_Cod);
                comando.Parameters.AddWithValue("@CodPet", pets.CodPet);


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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as NomeTutor, p.Nome as NomePet, p.Especie as Especie" +
                             " from MORADORES M, BA BA, PETS P where" +
                             " P.ba_cod = ba.ba_cod AND P.CODMORADOR = M.CODMORADOR AND apto like @apto";
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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as NomeTutor, p.Nome as NomePet, p.Especie as Especie" +
                                         " from MORADORES M, BA BA, PETS P where" +
                                         " P.ba_cod = ba.ba_cod AND P.CODMORADOR = M.CODMORADOR AND bloco like @bloco";
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

        public DataTable BuscaAptoComCod(string apto) //Busca pelo apto, contendo o campo código, para tela de alteração
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as NomeTutor, p.Nome as NomePet, p.Especie as Especie, P.codPet as CodPet" +
                             " from MORADORES M, BA BA, PETS P where" +
                             " P.ba_cod = ba.ba_cod AND P.CODMORADOR = M.CODMORADOR AND apto like @apto";
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

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as NomeTutor, p.Nome as NomePet, p.Especie as Especie, P.codPet as CodPet" +
                                         " from MORADORES M, BA BA, PETS P where" +
                                         " P.ba_cod = ba.ba_cod AND P.CODMORADOR = M.CODMORADOR AND bloco like @bloco";
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
