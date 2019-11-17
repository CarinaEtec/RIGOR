using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class LocacoesBO
    {
        public void Gravar(Locacoes loc)
        {
            LocacoesDAO locDao = new LocacoesDAO();
            if ((loc.BA.Ba_Cod != 0) && (loc.Moradores.CodMorador != 0) && (loc.Inicio != null))
            {
                locDao.Insert(loc);
            }
        }

        public void Deletar(Locacoes loc)
        {
            LocacoesDAO locDao = new LocacoesDAO();
            if (loc.CodLocacao != 0)
            {
                locDao.Delete(loc);
            }
        }

        public void Editar(Locacoes loc)
        {
            LocacoesDAO locDao = new LocacoesDAO();
            if (loc.CodLocacao != 0)
            {
                locDao.Update(loc);
            }
        }
    }
}
