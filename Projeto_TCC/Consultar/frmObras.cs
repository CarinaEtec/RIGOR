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
    public partial class frmObras : Form
    {
        public frmObras()
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
            Obras obras = new Obras();
            ObrasBO obrasBO = new ObrasBO();
            ObrasDAO obrasDAO = new ObrasDAO();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            if (rbtApto.Checked)
            {
                try
                {
                    obras.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = obrasDAO.BuscaApto(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma obra encontrada");
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
                    obras.BA.Bloco = txtBusca.Text;

                    dataGridView1.DataSource = obrasDAO.BuscaBloco(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma obra encontrada");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
        }

        private void rbtApto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtBloco_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmObras_Load(object sender, EventArgs e)
        {
            rbtApto.Checked = true;

        }
    }
}
