using Projeto_TCC;
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

namespace Projeto_TCC.Adicionar
{
    public partial class frmPets : Form
    {
        public frmPets()
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

                        mor.Nome = txtTutor.Text;
                        morBO.Buscar(mor);

                        if (mor.Nome == "")
                        {
                            MessageBox.Show("Tutor não encontrado");
                            txtTutor.Clear();
                        }
                        else
                        {
                            lblMoradorCod.Text = Convert.ToString(mor.CodMorador);
                            try
                            {
                                //cadastra pet
                                Pets pets = new Pets();
                                PetsBO petsBO = new PetsBO();

                                pets.Nome = txtNome.Text;

                                if ((pets.Nome == "") || (pets.Nome == null))
                                {
                                    MessageBox.Show("Nome do pet não identificado");
                                }                              
                                else
                                {
                                    pets.Nome = txtNome.Text.ToUpper();
                                    pets.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    pets.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    pets.Especie = cbbEspecie.SelectedItem.ToString();
                                    petsBO.Gravar(pets);
                                    MessageBox.Show("Pet cadastrado com sucesso");

                                    txtNome.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear();
                                    txtTutor.Clear();
                                    cbbEspecie.SelectedIndex = -1;
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

        private void frmPets_Load(object sender, EventArgs e)
        {
            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
        }
    }
}
