using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.Model
{
    class Obras
    {
        private int codObras;
        private Moradores moradores;
        private DateTime dataHora;
        private BA bA;

        public Obras()
        {
            bA = new BA();
            moradores = new Moradores();

        }

        public override string ToString()
        {
            return CodObras.ToString();
        }

        public int CodObras { get => codObras; set => codObras = value; }
        public DateTime DataHora { get => dataHora; set => dataHora = value; }
        public Moradores Moradores { get => moradores; set => moradores = value; }
        public BA BA { get => bA; set => bA = value; }
    }
}
