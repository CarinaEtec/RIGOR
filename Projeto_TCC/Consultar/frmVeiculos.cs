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
    public partial class frmVeiculos : Form
    {
        public frmVeiculos()
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
           Veiculos veiculos = new Veiculos();
            VeiculosBO veiculosBO = new VeiculosBO();
            VeiculosDAO veiculosdao = new VeiculosDAO();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            if (rbtPlaca.Checked)
            {
                try
                {
                    veiculos.Placa = mskPlaca.Text;

                    dataGridView1.DataSource = veiculosdao.BuscaPlaca(mskPlaca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhum veículo encontrado");
                        mskPlaca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }

            if (rbtApto.Checked)
            {
                try
                {
                    veiculos.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = veiculosdao.BuscaApto(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhum veículo encontrado");
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
                    veiculos.BA.Bloco = txtBusca.Text;

                    dataGridView1.DataSource = veiculosdao.BuscaBloco(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhum veículo encontrado");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
        }

        private void frmVeiculos_Load(object sender, EventArgs e)
        {
            rbtApto.Checked = true;
        }

        private void rbtBloco_CheckedChanged(object sender, EventArgs e)
        {
            mskPlaca.Clear();
            mskPlaca.Enabled = false;
            txtBusca.Enabled = true;
        }

        private void rbtApto_CheckedChanged(object sender, EventArgs e)
        {
            mskPlaca.Clear();
            mskPlaca.Enabled = false;
            txtBusca.Enabled = true;
        }

        private void rbtPlaca_CheckedChanged(object sender, EventArgs e)
        {
            mskPlaca.Clear();
            mskPlaca.Enabled = true;
            txtBusca.Enabled = false;
            txtBusca.Clear();

        }
    }
}
