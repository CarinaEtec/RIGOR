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
    public partial class frmPets : Form
    {
        public frmPets()
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
            Pets pet = new Pets();
            PetsBO petBO = new PetsBO();
            PetsDAO petsDAO = new PetsDAO();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            if (rbtApto.Checked)
            {
                try
                {
                    pet.BA.Apto = txtBusca.Text;

                    dataGridView1.DataSource = petsDAO.BuscaApto(txtBusca.Text);

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

                    dataGridView1.DataSource = petsDAO.BuscaBloco(txtBusca.Text);
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

        private void frmPets_Load(object sender, EventArgs e)
        {
            rbtApto.Checked = true;
        }
    }
}
