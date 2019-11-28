using Projeto_TCC;
using Projeto_TCC.Adicionar;
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
    public partial class frmAddDados : Form
    {
        public frmAddDados()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menuzinho = new frmMenu();
            menuzinho.Closed += (s, args) => this.Close();
            menuzinho.Show();
        }

        private void btnMoradores_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmMorador morador = new frmMorador();
            morador.Closed += (s, args) => this.Close();
            morador.Show();
        }

        private void btnCriancas_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmCriancas criancas = new frmCriancas();
            criancas.Closed += (s, args) => this.Close();
            criancas.Show();
        }

        private void btnAnimais_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmPets pets = new frmPets();
            pets.Closed += (s, args) => this.Close();
            pets.Show();
        }

        private void btnLocacao_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLocacao locacao = new frmLocacao();
            locacao.Closed += (s, args) => this.Close();
            locacao.Show();
        }

        private void btnOcorrencias_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmOcorrencia ocorrencias = new frmOcorrencia();
            ocorrencias.Closed += (s, args) => this.Close();
            ocorrencias.Show();
        }

        private void btnVeiculos_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmVeiculos veiculos = new frmVeiculos();
            veiculos.Closed += (s, args) => this.Close();
            veiculos.Show();
        }

        private void btnObras_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmObras obras = new frmObras();
            obras.Closed += (s, args) => this.Close();
            obras.Show();
        }

        private void btnAptos_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUsuario3Cond apto = new frmUsuario3Cond();
            apto.Closed += (s, args) => this.Close();
            apto.Show();
        }
    }
} 
