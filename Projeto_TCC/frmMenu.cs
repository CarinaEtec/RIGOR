using Projeto_TCC;
using Projeto_TCC.Adicionar;
using Projeto_TCC.Consultar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_TCC
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnAdicionarDados_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddDados add = new frmAddDados();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnAlterarDados_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltDados add = new frmAltDados();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void btnMoradores_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMoradores morador = new frmMoradores();
            morador.Closed += (s, args) => this.Close();
            morador.Show();
        }

        private void btnCriancas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmCriancas criancas = new Consultar.frmCriancas();
            criancas.Closed += (s, args) => this.Close();
            criancas.Show();
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmPets pets = new Consultar.frmPets();
            pets.Closed += (s, args) => this.Close();
            pets.Show();
        }

        private void btnLocacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmLocacao locacao = new Consultar.frmLocacao();
            locacao.Closed += (s, args) => this.Close();
            locacao.Show();
        }

        private void btnOcorrencias_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOcorrencias Ocorrencias = new frmOcorrencias();
            Ocorrencias.Closed += (s, args) => this.Close();
            Ocorrencias.Show();
        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmVeiculos veiculos = new Consultar.frmVeiculos();
            veiculos.Closed += (s, args) => this.Close();
            veiculos.Show();
        }

        private void btnObras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmObras obras = new Consultar.frmObras();
            obras.Closed += (s, args) => this.Close();
            obras.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultar.frmUsuarios usu = new Consultar.frmUsuarios();
            usu.Closed += (s, args) => this.Close();
            usu.Show();
        }
    }
}
