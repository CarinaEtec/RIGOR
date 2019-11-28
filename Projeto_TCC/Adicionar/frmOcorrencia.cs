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
    public partial class frmOcorrencia : Form
    {
        public frmOcorrencia()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddDados add = new frmAddDados();
            add.Closed += (s, args) => this.Close();
            add.Show();
        }

        private void frmOcorrencia_Load(object sender, EventArgs e)
        {
            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //puxar codigo do ba
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
                    //puxar codigo do morador
                    try
                    {
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
                            try
                            {
                                //cadastrar ocorrencias
                                Ocorrencias ocorrencias = new Ocorrencias();
                                OcorrenciasBO ocorrenciasBO = new OcorrenciasBO();
                                ocorrencias.Motivo = txtMotivo.Text;

                                if ((ocorrencias.Motivo == "") || (ocorrencias.Motivo == null))
                                {
                                    MessageBox.Show("Motivo não identificado");
                                }
                                else
                                {
                                    ocorrencias.Motivo = txtMotivo.Text.ToUpper();
                                    ocorrencias.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    ocorrencias.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    ocorrencias.Data = Convert.ToDateTime(mskData.Text);

                                    ocorrenciasBO.Gravar(ocorrencias);
                                    MessageBox.Show("Ocorrência cadastrada com sucesso");

                                    txtProprietario.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear();
                                    txtMotivo.Clear();
                                    mskData.Clear();
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
    }
}
