namespace Projeto_TCC.Adicionar
{
    partial class frmLocacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocacao));
            this.mskHorarioTermino = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mskHorarioInicio = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProprietario = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.txtBloco = new System.Windows.Forms.TextBox();
            this.txtApto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBACod = new System.Windows.Forms.Label();
            this.lblMoradorCod = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mskHorarioTermino
            // 
            this.mskHorarioTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHorarioTermino.Location = new System.Drawing.Point(311, 324);
            this.mskHorarioTermino.Mask = "00/00/0000 00:00";
            this.mskHorarioTermino.Name = "mskHorarioTermino";
            this.mskHorarioTermino.Size = new System.Drawing.Size(157, 29);
            this.mskHorarioTermino.TabIndex = 5;
            this.mskHorarioTermino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 94;
            this.label3.Text = "Término";
            // 
            // mskHorarioInicio
            // 
            this.mskHorarioInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskHorarioInicio.Location = new System.Drawing.Point(311, 276);
            this.mskHorarioInicio.Mask = "00/00/0000 00:00";
            this.mskHorarioInicio.Name = "mskHorarioInicio";
            this.mskHorarioInicio.Size = new System.Drawing.Size(157, 29);
            this.mskHorarioInicio.TabIndex = 4;
            this.mskHorarioInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 91;
            this.pictureBox1.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(514, 600);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(139, 59);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(514, 515);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(139, 59);
            this.btnCadastrar.TabIndex = 6;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(167, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(328, 39);
            this.label7.TabIndex = 88;
            this.label7.Text = "Cadastrar Locações";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 24);
            this.label6.TabIndex = 87;
            this.label6.Text = "Início";
            // 
            // txtProprietario
            // 
            this.txtProprietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProprietario.Location = new System.Drawing.Point(311, 226);
            this.txtProprietario.Name = "txtProprietario";
            this.txtProprietario.Size = new System.Drawing.Size(334, 29);
            this.txtProprietario.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(42, 226);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(106, 24);
            this.lbl.TabIndex = 84;
            this.lbl.Text = "Proprietário";
            // 
            // txtBloco
            // 
            this.txtBloco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBloco.Location = new System.Drawing.Point(311, 176);
            this.txtBloco.Name = "txtBloco";
            this.txtBloco.Size = new System.Drawing.Size(157, 29);
            this.txtBloco.TabIndex = 2;
            // 
            // txtApto
            // 
            this.txtApto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApto.Location = new System.Drawing.Point(311, 129);
            this.txtApto.Name = "txtApto";
            this.txtApto.Size = new System.Drawing.Size(157, 29);
            this.txtApto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 81;
            this.label2.Text = "Bloco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 80;
            this.label1.Text = "Apto";
            // 
            // lblBACod
            // 
            this.lblBACod.AutoSize = true;
            this.lblBACod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBACod.Location = new System.Drawing.Point(275, 140);
            this.lblBACod.Name = "lblBACod";
            this.lblBACod.Size = new System.Drawing.Size(2, 15);
            this.lblBACod.TabIndex = 95;
            // 
            // lblMoradorCod
            // 
            this.lblMoradorCod.AutoSize = true;
            this.lblMoradorCod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMoradorCod.Location = new System.Drawing.Point(275, 240);
            this.lblMoradorCod.Name = "lblMoradorCod";
            this.lblMoradorCod.Size = new System.Drawing.Size(2, 15);
            this.lblMoradorCod.TabIndex = 96;
            // 
            // frmLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 691);
            this.Controls.Add(this.lblMoradorCod);
            this.Controls.Add(this.lblBACod);
            this.Controls.Add(this.mskHorarioTermino);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskHorarioInicio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProprietario);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtBloco);
            this.Controls.Add(this.txtApto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmLocacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIGOR GESTÃO PARA CONDOMÍNIOS";
            this.Load += new System.EventHandler(this.frmLocacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskHorarioTermino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskHorarioInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProprietario;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtBloco;
        private System.Windows.Forms.TextBox txtApto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBACod;
        private System.Windows.Forms.Label lblMoradorCod;
    }
}