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
    public partial class frmLocacao2 : Form
    {
        public frmLocacao2()
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //panel1.Enabled = true;
            //btnAlterar.Enabled = true;
            //btnExcluir.Enabled = true;

            Locacoes loc = new Locacoes();
            LocacoesBO locBO = new LocacoesBO();
            LocacoesDAO locDAO = new LocacoesDAO();

            if (rbtApto.Checked)
            {
                try
                {
                    loc.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = locDAO.BuscaAptoComCod(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma locação encontrada");
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
                    loc.BA.Bloco = txtBusca.Text;

                    dataGridView1.DataSource = locDAO.BuscaBlocoComCod(txtBusca.Text);
                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhuma locação encontrada");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
        }

        private void frmLocacao2_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Visible = true;

            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
            lblCodLocacao.Visible = false;
            rbtApto.Checked = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DataGridView.Columns.Clear();
            }

            Locacoes loc = new Locacoes();
            LocacoesBO locBO = new LocacoesBO();

            try
            {
                loc.CodLocacao = Convert.ToInt16(lblCodLocacao.Text);
                locBO.Deletar(loc);

                MessageBox.Show("Locação excluída com sucesso");

                txtProprietario.Clear();
                txtApto.Clear();
                txtBloco.Clear();

                mskHorarioInicio.Clear();
                mskHorarioTermino.Clear();
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

                if ((ba.Bloco == "") ||  (ba.Apto == ""))
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
                            //altera o pet
                            try
                            {
                                Locacoes loc = new Locacoes();
                                LocacoesBO locBO = new LocacoesBO();

                                loc.CodLocacao = Convert.ToInt16(lblCodLocacao.Text);
                                loc.Inicio = Convert.ToDateTime(mskHorarioInicio.Text);
                                loc.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                loc.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                loc.Termino = Convert.ToDateTime(mskHorarioTermino.Text);

                                locBO.Editar(loc);
                                MessageBox.Show("Locação editada com sucesso");

                                txtProprietario.Clear();
                                txtApto.Clear();
                                txtBloco.Clear(); ;
                                mskHorarioTermino.Clear();
                                mskHorarioInicio.Clear();
                                txtBusca.Clear();
                                panel1.Enabled = false;
                                btnAlterar.Enabled = false;
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

            mskHorarioInicio.Text = linhaSelecionada.Cells[3].Value.ToString();
            mskHorarioTermino.Text = linhaSelecionada.Cells[4].Value.ToString();
            lblCodLocacao.Text = linhaSelecionada.Cells[5].Value.ToString();

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
