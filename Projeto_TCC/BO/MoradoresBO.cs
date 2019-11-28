using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class MoradoresBO
    {
        public void Gravar(Moradores mor) //Incluir
        {
            MoradorDAO morDao = new MoradorDAO();
            if ((mor.Nome != "") && (mor.DataNasc != null) && (mor.BA.Ba_Cod != 0))
            {
                morDao.Insert(mor);
            }
        }

        public void Deletar(Moradores mor) //Deletar
        {
            MoradorDAO morDao = new MoradorDAO();
            if (mor.Nome != "")
            {
                morDao.Delete(mor);
            }
        }

        public void Editar(Moradores mor) //Editar
        {
            MoradorDAO morDao = new MoradorDAO();
            if (mor.Nome != "")
            {
                morDao.Update(mor);
            }
        }

        public void Buscar(Moradores cliente) //Buscar
        {
            MoradorDAO morDao = new MoradorDAO();
            if (cliente.Nome != "")
            {
                var clienteTemp = morDao.BuscaPorNOME(cliente.Nome);

                cliente.Nome = clienteTemp.Nome;
                cliente.CodMorador = clienteTemp.CodMorador;
            }
        }
    }
}
