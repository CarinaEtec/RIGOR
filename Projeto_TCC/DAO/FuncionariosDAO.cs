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
    class FuncionariosDAO
    {
        public void Insert(Funcionarios func) //Inserir
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Insert into Funcionarios(nome,cpf,funcao,telefone,celular,senha) " +
                    "values(@nome,@cpf,@funcao,@telefone,@celular,@senha)";

                comando.Parameters.AddWithValue("@nome", func.Nome);
                comando.Parameters.AddWithValue("@cpf", func.Cpf);
                comando.Parameters.AddWithValue("@funcao", func.Funcao);
                comando.Parameters.AddWithValue("@telefone", func.Telefone);
                comando.Parameters.AddWithValue("@celular", func.Celular);
                comando.Parameters.AddWithValue("@senha", func.Senha);

                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
        }

        public void Update(Funcionarios func) //Editar
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Update Funcionarios set nome=@nome, funcao=@funcao, telefone=@telefone, " +
                    "celular=@celular, senha=@senha where cpf=@cpf";

                comando.Parameters.AddWithValue("@nome", func.Nome);
                comando.Parameters.AddWithValue("@cpf", func.Cpf);
                comando.Parameters.AddWithValue("@funcao", func.Funcao);
                comando.Parameters.AddWithValue("@telefone", func.Telefone);
                comando.Parameters.AddWithValue("@celular", func.Celular);
                comando.Parameters.AddWithValue("@senha", func.Senha);


                ConexaoBanco.CRUD(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }

        }

        public DataTable BuscaNome(string nome) //Busca pelo nome
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "select nome as Nome, funcao as Cargo, telefone as Telefone, celular as Celular" +
                 " from Funcionarios where" +
                 " nome like @nome";

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

        public DataTable BuscaCPF(long cpf) //Busca pelo CPF
        {
            MySqlConnection con = ConexaoBanco.Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandType = CommandType.Text;

            MySqlDataAdapter da;

            comando.CommandText = "Select nome as Nome, Funcao as Cargo, CPF as CPF, Telefone as Telefone, " +
                "Celular as Celular, Senha as Senha from Funcionarios where cpf=@cpf";

            try
            {
                comando = new MySqlCommand(comando.CommandText, con);

                comando.Parameters.AddWithValue("@cpf", cpf);

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


        // Login
        public bool tem = false;
        public bool Login(long cpf, String senha)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Select * from Funcionarios where cpf=@cpf and senha=@senha";

                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader dr = ConexaoBanco.Selecionar(comando);
                Funcionarios funcionarios = new Funcionarios();

                if (dr.HasRows)
                {
                    tem = true;
                }
                else
                {
                    tem = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar" + ex.Message);
            }
            return tem;
        } 
    }
}
