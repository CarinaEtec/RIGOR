using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.Model
{
    class Moradores
    {
        private int codMorador;
        private string nome;
        private DateTime dataNasc;
        private string situacao;
        private string telefone;
        private string celular;
        private BA bA;

        public Moradores()
        {
            BA = new BA();
        }

        public int CodMorador { get => codMorador; set => codMorador = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataNasc { get => dataNasc; set => dataNasc = value; }
        public string Situacao { get => situacao; set => situacao = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Celular { get => celular; set => celular = value; }
        public BA BA { get => bA; set => bA = value; }

        public override string ToString()
        {
            return CodMorador.ToString();
        }
    }
}
