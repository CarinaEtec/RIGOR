using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class BABO
    {
        public void Gravar(BA ba) //GRAVAR NOVO BLOCO/APTO
        {
            BADAO baDao = new BADAO();
            if (ba.Bloco != "")
            {
                baDao.Insert(ba);
            }
        }





        public void BuscaCodBA(BA ba)
        {
            BADAO baDao = new BADAO();

            if ((ba.Apto != "") && (ba.Bloco != ""))
            {

                var baTemp = baDao.BuscaCodBA(ba.Apto, ba.Bloco);
                ba.Ba_Cod = baTemp.Ba_Cod;
                ba.Apto = baTemp.Apto;
                ba.Bloco = baTemp.Bloco;

            }
        }




    }
}
