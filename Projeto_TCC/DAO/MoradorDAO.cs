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
    class MoradorDAO
    {
        public void Insert(Moradores mor) //Inserir
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Moradores(nome,dataNasc,situacao,telefone,celular,Ba_Cod) " +
                    "values(@nome,@dataNasc,@situacao,@telefone,@celular,@Ba_Cod)";

                comando.Parameters.AddWithValue("@nome", mor.Nome);
                comando.Parameters.AddWithValue("@dataNasc", mor.DataNasc);
                comando.Parameters.AddWithValue("@situacao", mor.Situacao);
                comando.Parameters.AddWithValue("@telefone", mor.Telefone);
                comando.Parameters.AddWithValue("@celular", mor.Celular);
                comando.Parameters.AddWithValue("@Ba_Cod", mor.BA.Ba_Cod);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Delete(Moradores mor) //Deletar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Delete from Moradores where CodMorador=@CodMorador";

                comando.Parameters.AddWithValue("@CodMorador", mor.CodMorador);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Moradores mor) //Editar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update Moradores set nome=@nome, dataNasc=@dataNasc, situacao=@situacao, telefone=@telefone, " +
                    "celular=@celular, Ba_Cod=@Ba_Cod  where CodMorador=@CodMorador";

                comando.Parameters.AddWithValue("@nome", mor.Nome);
                comando.Parameters.AddWithValue("@dataNasc", mor.DataNasc);
                comando.Parameters.AddWithValue("@situacao", mor.Situacao);
                comando.Parameters.AddWithValue("@telefone", mor.Telefone);
                comando.Parameters.AddWithValue("@celular", mor.Celular);
                comando.Parameters.AddWithValue("@Ba_Cod", mor.BA.Ba_Cod);
                comando.Parameters.AddWithValue("@CodMorador", mor.CodMorador);


                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }

        }

        public Moradores BuscaPorNOME(string Nome) //Busca por nome
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select codMorador,nome from moradores " +
                "where nome=@nome";

            comando.Parameters.AddWithValue("@nome", Nome);

            MySqlDataReader dr = ConexaoBanco.Selecionar(comando);

            Moradores cliente = new Moradores();
            if (dr.HasRows)
            {
                dr.Read();
                cliente.CodMorador = (int)dr["CodMorador"];
                cliente.Nome = (string)dr["Nome"];
            }
            else
            {
                cliente.CodMorador = 0;
                cliente.Nome = "";
            }
            return cliente;
        }
        
        public DataTable BuscaMenor(string nome) //BUSCA DE MENOR DE IDADE PELO NOME
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " nome like @nome and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) < 18)";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

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

        public DataTable BuscaAptoMenor(string apto) //BUSCA DE MENOR DE IDADE PELO APTO
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " apto like @apto and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) < 18)";

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
           
        public DataTable BuscaBlocoMenor(string bloco) // BUSCA DE MENOR DE IDADE PELO BLOCO
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " bloco like @bloco and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) < 18)";

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
    
        public DataTable BuscaMaior(string nome)//BUSCA DE MAIOR DE IDADE PELO NOME
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;


            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " nome like @nome and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) > 18)";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

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
             
        public DataTable BuscaAptoMaior(string apto) //BUSCA DE MENOR DE IDADE PELO APTO
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;


            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " apto like @apto and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) > 18)";

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
               
        public DataTable BuscaBlocoMaior(string bloco) //BUSCA DE MENOR DE IDADE PELO BLOCO
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select ba.apto as Apto, ba.bloco as Bloco, m.nome as Nome, m.situacao as Situacao, m.telefone as Telefone, m.celular as Celular, m.datanasc as DataNascimento" +
                  " from BA BA, MORADORES M where" +
                 " bloco like @bloco and m.ba_cod = ba.ba_cod " +
                 "AND (YEAR(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(DATANASC))) > 18)";

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


