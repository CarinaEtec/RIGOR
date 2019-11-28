using Projeto_TCC.Adicionar;
using Projeto_TCC.BO;
using Projeto_TCC.Model;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnrar_Click(object sender, EventArgs e)
        {
            try
            {
                FuncionariosBO funcBo = new FuncionariosBO();
                Funcionarios func = new Funcionarios();
                func.Cpf = Convert.ToInt64(mskCPF.Text);
                func.Senha = txtSenha.Text;

                funcBo.Login(func);
                if (funcBo.tem == true)
                {
                    MessageBox.Show("Seja Bem Vindo!");

                    this.Hide();
                    frmMenu menuzin = new frmMenu();
                    menuzin.Closed += (s, args) => this.Close();
                    menuzin.Show();
                }
                else
                {
                    MessageBox.Show("Verifique os dados e tente novamente");
                }
            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUsuario1 add = new frmUsuario1();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }
    }
}
