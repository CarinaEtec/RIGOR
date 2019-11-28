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
    public partial class frmOcorrencias2 : Form
    {
        public frmOcorrencias2()
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

        private void frmOcorrencias2_Load(object sender, EventArgs e)
        {
            rbtApto.Checked = true;

            panel1.Enabled = false;
            panel2.Visible = true;

            btnAlterar.Enabled = false;

            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
            lblCodOcorrencia.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Ocorrencias ocorrencias = new Ocorrencias();
            OcorrenciasBO ocorrenciasBO = new OcorrenciasBO();
            OcorrenciasDAO ocorrenciasDAO = new OcorrenciasDAO();


            if (rbtApto.Checked)
            {
                try
                {
                    ocorrencias.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = ocorrenciasDAO.BuscaAptoComCod(txtBusca.Text);
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

                    dataGridView1.DataSource = ocorrenciasDAO.BuscaBlocoComCod(txtBusca.Text);
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
                            //altera a ocorrencia
                            try
                            {
                                Ocorrencias ocorrencias = new Ocorrencias();
                                OcorrenciasBO ocorrenciasBO = new OcorrenciasBO();

                                ocorrencias.Motivo = txtMotivo.Text.ToUpper();
                                if ((ocorrencias.Motivo == "") || (ocorrencias.Motivo == null))
                                {
                                    MessageBox.Show("Motivo não identificado");
                                }
                                else
                                {
                                    ocorrencias.CodOcorrencia = Convert.ToInt16(lblCodOcorrencia.Text);
                                    ocorrencias.Motivo = txtMotivo.Text.ToUpper();
                                    ocorrencias.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    ocorrencias.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    ocorrencias.Data = Convert.ToDateTime(mskData.Text);

                                    ocorrenciasBO.Editar(ocorrencias);
                                    MessageBox.Show("Ocorrência editada com sucesso");

                                    txtProprietario.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear(); ;
                                    txtMotivo.Clear();
                                    mskData.Clear();
                                    txtBusca.Clear();
                                    panel1.Enabled = false;
                                    btnAlterar.Enabled = false;

                                    lblCodOcorrencia.Text = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaSelecionada;
            linhaSelecionada = dataGridView1.CurrentRow;

            txtApto.Text = linhaSelecionada.Cells[0].Value.ToString();
            txtBloco.Text = linhaSelecionada.Cells[1].Value.ToString();
            txtProprietario.Text = linhaSelecionada.Cells[2].Value.ToString();
            txtMotivo.Text = linhaSelecionada.Cells[3].Value.ToString();
            mskData.Text = linhaSelecionada.Cells[4].Value.ToString();
            lblCodOcorrencia.Text = linhaSelecionada.Cells[5].Value.ToString();

            panel1.Enabled = true;
            btnAlterar.Enabled = true;

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


