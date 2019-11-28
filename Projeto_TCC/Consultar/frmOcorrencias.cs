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
    public partial class frmOcorrencias : Form
    {
        public frmOcorrencias()
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
            Ocorrencias ocorrencias = new Ocorrencias();
            OcorrenciasBO ocorrenciasBO = new OcorrenciasBO();
            OcorrenciasDAO ocorrenciasDAO = new OcorrenciasDAO();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            if (rbtApto.Checked)
            {
                try
                {
                    ocorrencias.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = ocorrenciasDAO.BuscaApto(txtBusca.Text);

                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma ocorrência encontrada");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
            if (rbtBloco.Checked)
            {
                try
                {
                    ocorrencias.BA.Bloco = txtBusca.Text;

                    dataGridView1.DataSource = ocorrenciasDAO.BuscaBloco(txtBusca.Text);

                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma ocorrência encontrada");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
        }

        private void frmOcorrencias_Load(object sender, EventArgs e)
        {
            rbtApto.Checked = true;
        }
    }
}
