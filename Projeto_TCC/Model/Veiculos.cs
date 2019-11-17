using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_TCC.Model
{
    class Veiculos
    {
        private Moradores moradores;
        private string placa;
        private string modelo;
        private string cor;
        private BA bA;

        public Veiculos()
        {
            bA = new BA();
            moradores = new Moradores();
        }


        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Cor { get => cor; set => cor = value; }

        public Moradores Moradores { get => moradores; set => moradores = value; }
        public BA BA { get => bA; set => bA = value; }
    }
}
