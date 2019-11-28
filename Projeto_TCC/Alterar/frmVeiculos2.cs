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

namespace Projeto_TCC.Alterar
{
    public partial class frmVeiculos2 : Form
    {
        public frmVeiculos2()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltDados menu = new frmAltDados();
            menu.Closed += (s, args) => this.Close();
            menu.Show();
        }

        private void frmVeiculos2_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
            rbtApto.Checked = true;
            mskPlaca.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Veiculos veiculos = new Veiculos();
            VeiculosBO veiculosBO = new VeiculosBO();
            VeiculosDAO veiculosdao = new VeiculosDAO();

            if (rbtPlaca.Checked)
            {
                try
                {
                    veiculos.Placa = mskPlacaBusca.Text;

                    dataGridView1.DataSource = veiculosdao.BuscaPlaca(mskPlacaBusca.Text);
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DataGridView.Columns.Clear();
            }

            Veiculos veiculos = new Veiculos();
            VeiculosBO veiculosBO = new VeiculosBO();
            try
            {
                veiculos.Placa = mskPlaca.Text;
                veiculosBO.Deletar(veiculos);

                MessageBox.Show("Veículo excluído com sucesso");

                txtProprietario.Clear();
                txtApto.Clear();
                txtBloco.Clear(); ;
                mskPlaca.Clear();
                txtModelo.Clear();
                cbbCor.SelectedIndex = -1;
                txtBusca.Clear();

                panel1.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DataGridView.Columns.Clear();
            }
            try
            {
                //pega codigo bloco apartamento
                BA ba = new BA();
                BABO babo = new BABO();

                ba.Apto = txtApto.Text;
                ba.Bloco = txtBloco.Text;

                babo.BuscaCodBA(ba);

                if ((ba.Bloco == "") || (ba.Apto == ""))
                {
                    MessageBox.Show("Bloco/Apartamento não encontrado");
                    txtApto.Clear();
                    txtBloco.Clear();
                }

                else
                {
                    lblBACod.Text = Convert.ToString(ba.Ba_Cod);


                    try
                    {
                        //pega codigo morador
                        Moradores mor = new Moradores();
                        MoradoresBO morBO = new MoradoresBO();

                        mor.Nome = txtProprietario.Text;
                        morBO.Buscar(mor);

                        if (mor.Nome == "")
                        {
                            MessageBox.Show("Proprietário não encontrado");
                            txtProprietario.Clear();
                        }
                        else
                        {
                            lblMoradorCod.Text = Convert.ToString(mor.CodMorador);
                            //altera o veiculo
                            try
                            {
                                Veiculos veiculos = new Veiculos();
                                VeiculosBO veiculosBO = new VeiculosBO();
                                veiculos.Modelo = txtModelo.Text;

                                if ((veiculos.Modelo == "") || (veiculos.Modelo == null) || (veiculos.Placa == "   -"))
                                {
                                    MessageBox.Show("Preencha todos os campos");
                                }
                                else
                                {

                                    veiculos.Placa = mskPlaca.Text.ToUpper();
                                    veiculos.Modelo = txtModelo.Text.ToUpper();
                                    veiculos.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    veiculos.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    veiculos.Cor = cbbCor.SelectedItem.ToString();

                                    veiculosBO.Editar(veiculos);
                                    MessageBox.Show("Veículo editado com sucesso");

                                    mskPlaca.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear(); ;
                                    txtModelo.Clear();
                                    txtProprietario.Clear();
                                    txtBusca.Clear();
                                    cbbCor.SelectedIndex = -1;

                                    panel1.Enabled = false;
                                    btnAlterar.Enabled = false;
                                    btnExcluir.Enabled = false;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Verifique os dados e tente novamente");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Verifique os dados e tente novamente");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }
        }

        private void rbtBloco_CheckedChanged(object sender, EventArgs e)
        {
            mskPlacaBusca.Clear();
            mskPlacaBusca.Enabled = false;
            txtBusca.Enabled = true;
        }

        private void rbtPlaca_CheckedChanged(object sender, EventArgs e)
        {
            mskPlacaBusca.Clear();
            mskPlacaBusca.Enabled = true;
            txtBusca.Enabled = false;
            txtBusca.Clear();
        }

        private void rbtApto_CheckedChanged(object sender, EventArgs e)
        {
            mskPlacaBusca.Clear();
            mskPlacaBusca.Enabled = false;
            txtBusca.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaSelecionada;
            linhaSelecionada = dataGridView1.CurrentRow;

            txtApto.Text = linhaSelecionada.Cells[0].Value.ToString();
            txtBloco.Text = linhaSelecionada.Cells[1].Value.ToString();
            txtProprietario.Text = linhaSelecionada.Cells[2].Value.ToString();
            mskPlaca.Text = linhaSelecionada.Cells[3].Value.ToString();
            txtModelo.Text = linhaSelecionada.Cells[4].Value.ToString();
            cbbCor.Text = linhaSelecionada.Cells[5].Value.ToString();

            panel1.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;

            try
            {
                //puxar codigo do BA
                BA ba = new BA();
                BABO babo = new BABO();

                ba.Apto = txtApto.Text;
                ba.Bloco = txtBloco.Text;

                babo.BuscaCodBA(ba);
                lblBACod.Text = Convert.ToString(ba.Ba_Cod);

                //puxar codigo do MORADOR
                Moradores mor = new Moradores();
                MoradoresBO morBO = new MoradoresBO();

                mor.Nome = txtProprietario.Text;
                morBO.Buscar(mor);

                lblMoradorCod.Text = Convert.ToString(mor.CodMorador);

            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }
        }
    }
}
