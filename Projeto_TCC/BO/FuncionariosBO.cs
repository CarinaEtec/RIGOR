using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class FuncionariosBO
    {
        public void Gravar(Funcionarios func)
        {
            FuncionariosDAO funcDao = new FuncionariosDAO();
            if ((func.Nome != "") && (func.Cpf != 0))
            {
                funcDao.Insert(func);
            }
        }

        public void Editar(Funcionarios func)
        {
            FuncionariosDAO funcDao = new FuncionariosDAO();
            if (func.Cpf != 0)
            {
                funcDao.Update(func);
            }
        }


        //public void BuscaCPF(Funcionarios func)
        //{
        //    FuncionariosDAO funcDao = new FuncionariosDAO();

        //    if (func.Cpf != 0)
        //    {
        //        var livroTemp = funcDao.BuscaCPF(func.Cpf);

        //        func.Nome = livroTemp.Nome;
        //        func.Funcao = livroTemp.Funcao;
        //        func.Telefone = livroTemp.Telefone;
        //        func.Celular = livroTemp.Celular;
        //        func.Senha = livroTemp.Senha;

        //    }
        //}

        public bool tem=false;
        public void Login(Funcionarios func)
        {
            FuncionariosDAO funcDao = new FuncionariosDAO();
            tem = funcDao.Login(func.Cpf,func.Senha);
            if ((func.Cpf != 0) && (func.Senha != null))
            {
                funcDao.Login(func.Cpf, func.Senha);
            }
        }



    }


}
