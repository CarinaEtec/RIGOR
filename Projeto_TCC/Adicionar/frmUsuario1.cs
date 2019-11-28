using Projeto_TCC;
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

namespace Projeto_TCC.Adicionar
{
    public partial class frmUsuario1 : Form
    {
        public frmUsuario1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 add = new Form1();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = mskCPF.Text;
                if (ValidaCPF.IsCpf(valor))
                {
                    Funcionarios func = new Funcionarios();
                    FuncionariosBO funcBO = new FuncionariosBO();

                    func.Nome = txtNome.Text;
                    func.Senha = txtSenha.Text;


                    if ((func.Nome == "") || (func.Nome == null) || (func.Senha == "") || (func.Senha == null))
                    {
                        MessageBox.Show("Preencha todos os campos");
                    }
                    else
                    {
                        func.Nome = txtNome.Text.ToUpper();
                        func.Cpf = Convert.ToInt64(mskCPF.Text);
                        func.Funcao = cbbFuncao.SelectedItem.ToString();
                        func.Telefone = mskTelefone.Text;
                        func.Celular = mskCelular.Text;
                        func.Senha = txtSenha.Text;

                        funcBO.Gravar(func);
                        MessageBox.Show("Funcionário cadastrado com sucesso");

                        txtNome.Clear();
                        mskCPF.Clear();
                        cbbFuncao.SelectedIndex = -1;
                        mskTelefone.Clear();
                        mskCelular.Clear();
                        txtSenha.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("CPF Inválido!");
                    mskCPF.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }
        }

        private void frmUsuario1_Load(object sender, EventArgs e)
        {
        }
    }
}
