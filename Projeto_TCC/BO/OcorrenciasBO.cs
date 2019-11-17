using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class OcorrenciasBO
    {
        public void Gravar(Ocorrencias ocorrencias)
        {
            OcorrenciasDAO ocorrenciasDao = new OcorrenciasDAO();
            if ((ocorrencias.BA.Ba_Cod != 0) && (ocorrencias.Moradores.CodMorador != 0) && (ocorrencias.Motivo != ""))
            {
                ocorrenciasDao.Insert(ocorrencias);
            }
        }       

        public void Editar(Ocorrencias ocorrencias)
        {
            OcorrenciasDAO ocorrenciasDao = new OcorrenciasDAO();
            if (ocorrencias.CodOcorrencia != 0)
            {
                ocorrenciasDao.Update(ocorrencias);
            }
        }
    }
}
