using Projeto_TCC.BO;
using Projeto_TCC.DAO;
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
    public partial class frmUsuario3Cond : Form
    {
        public frmUsuario3Cond()
        {
            InitializeComponent();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUsuario1 fim = new frmUsuario1();
            fim.Closed += (s, args) => this.Close();
            fim.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddDados add = new frmAddDados();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }


        private void frmUsuario3Cond_Load(object sender, EventArgs e)
        {
        }

        private void btnSalvarApto_Click(object sender, EventArgs e)
        {
            try
            {
                BA ba = new BA();
                BABO baBO = new BABO();

                ba.Bloco = txtBloco.Text;
                ba.Apto = txtApto.Text;
                if ((ba.Bloco != "") && (ba.Apto != ""))
                {
                    baBO.Gravar(ba);
                    MessageBox.Show("Apto cadastrado com sucesso");

                    grpCadApto.Visible = true;
                    txtBloco.Clear();
                    txtApto.Clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }

            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            BA ba = new BA();
            BABO baBO = new BABO();
            BADAO baDao = new BADAO();
            try
            {
                ba.Bloco = txtBlocoConsulta.Text;

                dataGridView1.DataSource = baDao.Consulta(txtBlocoConsulta.Text);
                for (int i = 1; i == dataGridView1.RowCount; i++)
                {
                    MessageBox.Show("Nenhum bloco encontrado");
                    txtBlocoConsulta.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Preencha corretamente as informações");
            }
        }
    }
}
