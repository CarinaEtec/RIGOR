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
            frmCriancas pirralhos = new frmCriancas();
            pirralhos.Closed += (s, args) => this.Close();
            pirralhos.Show();
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
            frmLocacao add = new frmLocacao();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnOcorrencias_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmOcorrencia add = new frmOcorrencia();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnVeiculos_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmVeiculos add = new frmVeiculos();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnObras_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmObras add = new frmObras();
            add.Closed += (s, args) => this.Close();
            add.Show();
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
