using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.Model
{
    class Locacoes
    {
        private int codLocacao;
        private Moradores moradores;
        private DateTime inicio;
        private DateTime termino;
        private BA bA;

        public Locacoes()
        {
            bA = new BA();
            moradores = new Moradores();
        }

        public override string ToString()
        {
            return CodLocacao.ToString();
        }

        internal Moradores Moradores { get => moradores; set => moradores = value; }
        public int CodLocacao { get => codLocacao; set => codLocacao = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
        public DateTime Termino { get => termino; set => termino = value; }
        public BA BA { get => bA; set => bA = value; }

    }
}
