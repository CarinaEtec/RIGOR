using Projeto_TCC.DAO;
using Projeto_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.BO
{
    class PetsBO
    {

        public void Gravar(Pets pets)
        {
            PetsDAO petsDao = new PetsDAO();
            if ((pets.Nome != null) && (pets.Moradores.CodMorador != 0) && (pets.BA.Ba_Cod != 0) && (pets.Especie != null))
            {
                petsDao.Insert(pets);
            }
        }


        public void Deletar(Pets pets)
        {
            PetsDAO petsDao = new PetsDAO();
            if (pets.CodPet != 0)
            {
                petsDao.Delete(pets);
            }
        }

        public void Editar(Pets pets)
        {
            PetsDAO petsDao = new PetsDAO();
            if (pets.CodPet != 0)
            {
                petsDao.Update(pets);
            }
        }

     

    }
}
