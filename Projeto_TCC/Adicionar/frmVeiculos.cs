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
    public partial class frmVeiculos : Form
    {
        public frmVeiculos()
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

        private void frmVeiculos_Load(object sender, EventArgs e)
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
                                //  add veiculos
                                Veiculos veiculos = new Veiculos();
                                VeiculosBO veiculosBO = new VeiculosBO();
                                veiculos.Modelo = txtModelo.Text;
                                veiculos.Placa = mskPlaca.Text.ToUpper(); ;

                                if ((veiculos.Modelo == "") || (veiculos.Modelo == null) || (veiculos.Placa == "   -"))
                                {
                                    MessageBox.Show("Preencha todos os campos");
                                }

                                else
                                {


                                    veiculos.Placa = mskPlaca.Text.ToUpper(); ;
                                    veiculos.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    veiculos.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    veiculos.Modelo = txtModelo.Text.ToUpper();
                                    veiculos.Cor = cbbCor.SelectedItem.ToString();


                                    veiculosBO.Gravar(veiculos);
                                    MessageBox.Show("Veículo cadastrado com sucesso");

                                    txtProprietario.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear();
                                    txtModelo.Clear();
                                    cbbCor.SelectedIndex = -1;
                                    mskPlaca.Clear();
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