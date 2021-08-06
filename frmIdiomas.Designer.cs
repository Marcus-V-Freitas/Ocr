namespace Ocr
{
    partial class frmIdiomas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdiomas));
            this.btnOk = new System.Windows.Forms.Button();
            this.cboIdiomas = new System.Windows.Forms.CheckedListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIdiomasPrincipais = new System.Windows.Forms.Label();
            this.lblIdiomasAsiaticos = new System.Windows.Forms.Label();
            this.cboIdiomasAsiaticos = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(157, 599);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.Ok);
            // 
            // cboIdiomas
            // 
            this.cboIdiomas.CheckOnClick = true;
            this.cboIdiomas.FormattingEnabled = true;
            this.cboIdiomas.Location = new System.Drawing.Point(16, 31);
            this.cboIdiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboIdiomas.Name = "cboIdiomas";
            this.cboIdiomas.Size = new System.Drawing.Size(203, 497);
            this.cboIdiomas.Sorted = true;
            this.cboIdiomas.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(265, 599);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.Cancelar);
            // 
            // lblIdiomasPrincipais
            // 
            this.lblIdiomasPrincipais.AutoSize = true;
            this.lblIdiomasPrincipais.Location = new System.Drawing.Point(16, 11);
            this.lblIdiomasPrincipais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdiomasPrincipais.Name = "lblIdiomasPrincipais";
            this.lblIdiomasPrincipais.Size = new System.Drawing.Size(125, 17);
            this.lblIdiomasPrincipais.TabIndex = 3;
            this.lblIdiomasPrincipais.Text = "Idiomas Principais:";
            // 
            // lblIdiomasAsiaticos
            // 
            this.lblIdiomasAsiaticos.AutoSize = true;
            this.lblIdiomasAsiaticos.Location = new System.Drawing.Point(317, 11);
            this.lblIdiomasAsiaticos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdiomasAsiaticos.Name = "lblIdiomasAsiaticos";
            this.lblIdiomasAsiaticos.Size = new System.Drawing.Size(120, 17);
            this.lblIdiomasAsiaticos.TabIndex = 5;
            this.lblIdiomasAsiaticos.Text = "Idiomas Asiáticos:";
            // 
            // cboIdiomasAsiaticos
            // 
            this.cboIdiomasAsiaticos.CheckOnClick = true;
            this.cboIdiomasAsiaticos.FormattingEnabled = true;
            this.cboIdiomasAsiaticos.Location = new System.Drawing.Point(321, 31);
            this.cboIdiomasAsiaticos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboIdiomasAsiaticos.Name = "cboIdiomasAsiaticos";
            this.cboIdiomasAsiaticos.Size = new System.Drawing.Size(203, 157);
            this.cboIdiomasAsiaticos.Sorted = true;
            this.cboIdiomasAsiaticos.TabIndex = 4;
            // 
            // frmIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 636);
            this.Controls.Add(this.lblIdiomasAsiaticos);
            this.Controls.Add(this.cboIdiomasAsiaticos);
            this.Controls.Add(this.lblIdiomasPrincipais);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboIdiomas);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIdiomas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Idiomas";
            this.Load += new System.EventHandler(this.CarregamentoFormulario);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckedListBox cboIdiomas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIdiomasPrincipais;
        private System.Windows.Forms.Label lblIdiomasAsiaticos;
        private System.Windows.Forms.CheckedListBox cboIdiomasAsiaticos;
    }
}