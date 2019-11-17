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

namespace Projeto_TCC.Consultar
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Funcionarios func = new Funcionarios();
            FuncionariosBO funcBO = new FuncionariosBO();
            FuncionariosDAO funcDAO = new FuncionariosDAO();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            try
            {
                func.Nome = txtBusca.Text;
                dataGridView1.DataSource = funcDAO.BuscaNome(txtBusca.Text);

                for (int i = 0; i == dataGridView1.RowCount; i++)
                {
                    MessageBox.Show("Nenhum funcionário encontrado");
                    txtBusca.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Preencha corretamente as informações");
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
