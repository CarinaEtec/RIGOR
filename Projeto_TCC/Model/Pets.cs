using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.Model
{
    class Pets
    {
        private int codPet;
        private string nome;
        private Moradores moradores;
        private string especie;
        private BA bA;

        public Pets()
        {
            bA = new BA();
            moradores = new Moradores();
        }

        public override string ToString()
        {
            return CodPet.ToString();
        }

        public int CodPet { get => codPet; set => codPet = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Especie { get => especie; set => especie = value; }
        public Moradores Moradores { get => moradores; set => moradores = value; }
        public BA BA { get => bA; set => bA = value; }




    }
}
