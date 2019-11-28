using Projeto_TCC;
using Projeto_TCC.Alterar;
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
    public partial class frmAltDados : Form
    {
        public frmAltDados()
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

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmUsuario3Func usu = new frmUsuario3Func();
            usu.Closed += (s, args) => this.Close();
            usu.Show();
        }

        private void btnMoradores_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmMorador2 morador = new frmMorador2();
            morador.Closed += (s, args) => this.Close();
            morador.Show();
        }

        private void btnCriancas_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmCriancas2 criancas = new frmCriancas2();
            criancas.Closed += (s, args) => this.Close();
            criancas.Show();
        }

        private void btnAnimais_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmPets2 pets = new frmPets2();
            pets.Closed += (s, args) => this.Close();
            pets.Show();
        }

        private void btnLocacao_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmLocacao2 locacao = new frmLocacao2();
            locacao.Closed += (s, args) => this.Close();
            locacao.Show();
        }

        private void btnOcorrencias_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmOcorrencias2 ocorrencias = new frmOcorrencias2();
            ocorrencias.Closed += (s, args) => this.Close();
            ocorrencias.Show();
        }

        private void btnVeiculos_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmVeiculos2 veiculos = new frmVeiculos2();
            veiculos.Closed += (s, args) => this.Close();
            veiculos.Show();
        }

        private void btnObras_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmObras2 obras = new frmObras2();
            obras.Closed += (s, args) => this.Close();
            obras.Show();
        }
    }
}
