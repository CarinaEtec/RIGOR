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
    public partial class frmPets2 : Form
    {
        public frmPets2()
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



        private void frmPets2_Load(object sender, EventArgs e)
        {
            lblCodPet.Visible = false;

            rbtApto.Checked = true;

            panel1.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            lblMoradorCod.Visible = false;
            lblBACod.Visible = false;
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
                            //altera o pet
                            try
                            {
                                Pets pets = new Pets();
                                PetsBO petsBO = new PetsBO();
                                pets.Nome = txtNome.Text;


                                if ((pets.Nome == "") || (pets.Nome == null))
                                {
                                    MessageBox.Show("Nome do pet não identificado");
                                }
                                else
                                {

                                    pets.CodPet = Convert.ToInt16(lblCodPet.Text);
                                    pets.Nome = txtNome.Text.ToUpper(); 
                                    pets.Moradores.CodMorador = Convert.ToInt16(lblMoradorCod.Text);
                                    pets.BA.Ba_Cod = Convert.ToInt16(lblBACod.Text);
                                    pets.Especie = cbbEspecie.SelectedItem.ToString();

                                    petsBO.Editar(pets);
                                    MessageBox.Show("Pet editado com sucesso");

                                    txtNome.Clear();
                                    txtApto.Clear();
                                    txtBloco.Clear(); ;
                                    txtTutor.Clear();
                                    cbbEspecie.SelectedIndex = -1;
                                    txtBusca.Clear();
                                    panel1.Enabled = false;
                                    btnAlterar.Enabled = false;
                                    btnExcluir.Enabled = false;
                                    lblCodPet.Text = "";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DataGridView.Columns.Clear();
            }

            Pets pet = new Pets();
            PetsBO petBO = new PetsBO();

            try
            {
                pet.CodPet = Convert.ToInt16(lblCodPet.Text);
                petBO.Deletar(pet);

                MessageBox.Show("Pet excluído com sucesso");

                txtNome.Clear();
                txtApto.Clear();
                txtBloco.Clear(); ;
                txtTutor.Clear();
                cbbEspecie.SelectedIndex = -1;
                txtBusca.Clear();
                panel1.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;

                lblCodPet.Text = "";
            }
            catch
            {
                MessageBox.Show("Verifique os dados e tente novamente");
            }

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            Pets pet = new Pets();
            PetsBO petBO = new PetsBO();
            PetsDAO petsDAO = new PetsDAO();


            if (rbtApto.Checked)
            {
                try
                {
                    pet.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = petsDAO.BuscaAptoComCod(txtBusca.Text);

                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhum pet encontrado");
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
                    pet.BA.Bloco = txtBusca.Text;

                    dataGridView1.DataSource = petsDAO.BuscaBlocoComCod(txtBusca.Text);

                    for (int i = 0; i == dataGridView1.RowCount; i++)
                    {
                        MessageBox.Show("Nenhum pet encontrado");
                        txtBusca.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Preencha corretamente as informações");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaSelecionada;
            linhaSelecionada = dataGridView1.CurrentRow;


            txtApto.Text = linhaSelecionada.Cells[0].Value.ToString();
            txtBloco.Text = linhaSelecionada.Cells[1].Value.ToString();
            txtTutor.Text = linhaSelecionada.Cells[2].Value.ToString();
            txtNome.Text = linhaSelecionada.Cells[3].Value.ToString();
            cbbEspecie.Text = linhaSelecionada.Cells[4].Value.ToString();
            lblCodPet.Text = linhaSelecionada.Cells[5].Value.ToString();

            panel1.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;

        }
    }
}
