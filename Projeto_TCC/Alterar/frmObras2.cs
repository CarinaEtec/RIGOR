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
    public partial class frmObras2 : Form
    {
        public frmObras2()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAltDados menuzinho = new frmAltDados();
            menuzinho.Closed += (s, args) => this.Close();
            menuzinho.Show();
        }

        private void frmObras2_Load(object sender, EventArgs e)
        {
            lblCodObra.Visible = false;
            rbtApto.Checked = true;

            panel1.Enabled = false;
            panel2.Visible = true;

            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Obras obras = new Obras();
            ObrasBO obrasBO = new ObrasBO();
            ObrasDAO obrasDAO = new ObrasDAO();

            if (rbtApto.Checked)
            {
                try
                {
                    obras.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = obrasDAO.BuscaAptoComCod(txtBusca.Text);
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

                    dataGridView1.DataSource = obrasDAO.BuscaBlocoComCod(txtBusca.Text);
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DataGridView.Columns.Clear();
            }

            Obras obras = new Obras();
            ObrasBO obrasBO = new ObrasBO();

            try
            {
                obras.CodObras = Convert.ToInt16(lblCodObra.Text);
                obrasBO.Deletar(obras);

                MessageBox.Show("Obra excluída com sucesso");

                mskData.Clear();
                txtApto.Clear();
                txtBloco.Clear(); ;
                txtProprietario.Clear();

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
                    {   //pega codigo morador
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
                            //altera a obra
                            try
                            {
                                Obras obras = new Obras();
                                ObrasBO obrasBO = new ObrasBO();

                                obras.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                obras.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                obras.DataHora = Convert.ToDateTime(mskData.Text);
                                obras.CodObras = Convert.ToInt16(lblCodObra.Text);

                                obrasBO.Editar(obras);
                                MessageBox.Show("Obra editada com sucesso");

                                txtProprietario.Clear();
                                txtApto.Clear();
                                txtBloco.Clear();
                                mskData.Clear();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaSelecionada;
            linhaSelecionada = dataGridView1.CurrentRow;

            txtApto.Text = linhaSelecionada.Cells[0].Value.ToString();
            txtBloco.Text = linhaSelecionada.Cells[1].Value.ToString();
            txtProprietario.Text = linhaSelecionada.Cells[2].Value.ToString();
            mskData.Text = linhaSelecionada.Cells[3].Value.ToString();
            lblCodObra.Text = linhaSelecionada.Cells[4].Value.ToString();

            panel1.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
