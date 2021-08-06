namespace Ocr
{
    partial class frmOpcoesFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcoesFiltro));
            this.lblAvisoDesempenho = new System.Windows.Forms.Label();
            this.lblAvisoRecarregar = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkCodigoBarras = new System.Windows.Forms.CheckBox();
            this.chkImagemInversa = new System.Windows.Forms.CheckBox();
            this.chkZonasInversas = new System.Windows.Forms.CheckBox();
            this.chkDistorcao = new System.Windows.Forms.CheckBox();
            this.chkRotacao = new System.Windows.Forms.CheckBox();
            this.chkFiltroRuido = new System.Windows.Forms.CheckBox();
            this.chkRemoverLinhas = new System.Windows.Forms.CheckBox();
            this.chkModoCinza = new System.Windows.Forms.CheckBox();
            this.chkModoRapido = new System.Windows.Forms.CheckBox();
            this.chkBinzarizacaoDupla = new System.Windows.Forms.CheckBox();
            this.lblLetrasProcurar = new System.Windows.Forms.Label();
            this.txtLetrasProcurar = new System.Windows.Forms.TextBox();
            this.txtLetrasExcluir = new System.Windows.Forms.TextBox();
            this.lblLetrasExcluir = new System.Windows.Forms.Label();
            this.txtQualidadeTexto = new System.Windows.Forms.TextBox();
            this.lblQualidade = new System.Windows.Forms.Label();
            this.txtLimiarBinarizacao = new System.Windows.Forms.TextBox();
            this.lblLimiar = new System.Windows.Forms.Label();
            this.txtRenderizacaoPDF = new System.Windows.Forms.TextBox();
            this.lblRenderizacaoPDF = new System.Windows.Forms.Label();
            this.chkCharMistos = new System.Windows.Forms.CheckBox();
            this.chkDicionario = new System.Windows.Forms.CheckBox();
            this.chkCombinarZonaHorizontal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblAvisoDesempenho
            // 
            this.lblAvisoDesempenho.AutoSize = true;
            this.lblAvisoDesempenho.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoDesempenho.Location = new System.Drawing.Point(16, 30);
            this.lblAvisoDesempenho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvisoDesempenho.Name = "lblAvisoDesempenho";
            this.lblAvisoDesempenho.Size = new System.Drawing.Size(581, 17);
            this.lblAvisoDesempenho.TabIndex = 0;
            this.lblAvisoDesempenho.Text = "Você pode melhorar o desempenho e a precisão do OCR alterando a configuração padr" +
    "ão";
            // 
            // lblAvisoRecarregar
            // 
            this.lblAvisoRecarregar.AutoSize = true;
            this.lblAvisoRecarregar.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoRecarregar.Location = new System.Drawing.Point(19, 639);
            this.lblAvisoRecarregar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvisoRecarregar.Name = "lblAvisoRecarregar";
            this.lblAvisoRecarregar.Size = new System.Drawing.Size(359, 17);
            this.lblAvisoRecarregar.TabIndex = 2;
            this.lblAvisoRecarregar.Text = "Recarregue a imagem para aplicar todas as alterações.";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(199, 671);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 33);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.Ok);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(307, 671);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 33);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.Cancelar);
            // 
            // chkCodigoBarras
            // 
            this.chkCodigoBarras.AutoSize = true;
            this.chkCodigoBarras.Location = new System.Drawing.Point(20, 85);
            this.chkCodigoBarras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCodigoBarras.Name = "chkCodigoBarras";
            this.chkCodigoBarras.Size = new System.Drawing.Size(205, 21);
            this.chkCodigoBarras.TabIndex = 5;
            this.chkCodigoBarras.Text = "Encontre códigos de barras";
            this.chkCodigoBarras.UseVisualStyleBackColor = true;
            // 
            // chkImagemInversa
            // 
            this.chkImagemInversa.AutoSize = true;
            this.chkImagemInversa.Location = new System.Drawing.Point(20, 113);
            this.chkImagemInversa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkImagemInversa.Name = "chkImagemInversa";
            this.chkImagemInversa.Size = new System.Drawing.Size(215, 21);
            this.chkImagemInversa.TabIndex = 6;
            this.chkImagemInversa.Text = "Detectar inversão de imagem";
            this.chkImagemInversa.UseVisualStyleBackColor = true;
            // 
            // chkZonasInversas
            // 
            this.chkZonasInversas.AutoSize = true;
            this.chkZonasInversas.Location = new System.Drawing.Point(20, 142);
            this.chkZonasInversas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkZonasInversas.Name = "chkZonasInversas";
            this.chkZonasInversas.Size = new System.Drawing.Size(204, 21);
            this.chkZonasInversas.TabIndex = 7;
            this.chkZonasInversas.Text = "Detectar inversão de zonas";
            this.chkZonasInversas.UseVisualStyleBackColor = true;
            // 
            // chkDistorcao
            // 
            this.chkDistorcao.AutoSize = true;
            this.chkDistorcao.Location = new System.Drawing.Point(20, 170);
            this.chkDistorcao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDistorcao.Name = "chkDistorcao";
            this.chkDistorcao.Size = new System.Drawing.Size(279, 21);
            this.chkDistorcao.TabIndex = 8;
            this.chkDistorcao.Text = "Detectar e corrigir distorção da imagem";
            this.chkDistorcao.UseVisualStyleBackColor = true;
            // 
            // chkRotacao
            // 
            this.chkRotacao.AutoSize = true;
            this.chkRotacao.Location = new System.Drawing.Point(20, 198);
            this.chkRotacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRotacao.Name = "chkRotacao";
            this.chkRotacao.Size = new System.Drawing.Size(385, 21);
            this.chkRotacao.TabIndex = 9;
            this.chkRotacao.Text = "Detectar e corrigir rotação da imagem 90/180/270 graus";
            this.chkRotacao.UseVisualStyleBackColor = true;
            // 
            // chkFiltroRuido
            // 
            this.chkFiltroRuido.AutoSize = true;
            this.chkFiltroRuido.Location = new System.Drawing.Point(20, 226);
            this.chkFiltroRuido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFiltroRuido.Name = "chkFiltroRuido";
            this.chkFiltroRuido.Size = new System.Drawing.Size(258, 21);
            this.chkFiltroRuido.TabIndex = 10;
            this.chkFiltroRuido.Text = "Aplicar filtro de ruído para a imagem";
            this.chkFiltroRuido.UseVisualStyleBackColor = true;
            // 
            // chkRemoverLinhas
            // 
            this.chkRemoverLinhas.AutoSize = true;
            this.chkRemoverLinhas.Location = new System.Drawing.Point(20, 255);
            this.chkRemoverLinhas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRemoverLinhas.Name = "chkRemoverLinhas";
            this.chkRemoverLinhas.Size = new System.Drawing.Size(193, 21);
            this.chkRemoverLinhas.TabIndex = 11;
            this.chkRemoverLinhas.Text = "Detectar e remover linhas";
            this.chkRemoverLinhas.UseVisualStyleBackColor = true;
            // 
            // chkModoCinza
            // 
            this.chkModoCinza.AutoSize = true;
            this.chkModoCinza.Location = new System.Drawing.Point(20, 283);
            this.chkModoCinza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModoCinza.Name = "chkModoCinza";
            this.chkModoCinza.Size = new System.Drawing.Size(102, 21);
            this.chkModoCinza.TabIndex = 12;
            this.chkModoCinza.Text = "Modo cinza";
            this.chkModoCinza.UseVisualStyleBackColor = true;
            // 
            // chkModoRapido
            // 
            this.chkModoRapido.AutoSize = true;
            this.chkModoRapido.Location = new System.Drawing.Point(20, 311);
            this.chkModoRapido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModoRapido.Name = "chkModoRapido";
            this.chkModoRapido.Size = new System.Drawing.Size(215, 21);
            this.chkModoRapido.TabIndex = 13;
            this.chkModoRapido.Text = "Modo rápido (menos preciso)";
            this.chkModoRapido.UseVisualStyleBackColor = true;
            // 
            // chkBinzarizacaoDupla
            // 
            this.chkBinzarizacaoDupla.AutoSize = true;
            this.chkBinzarizacaoDupla.Location = new System.Drawing.Point(20, 340);
            this.chkBinzarizacaoDupla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBinzarizacaoDupla.Name = "chkBinzarizacaoDupla";
            this.chkBinzarizacaoDupla.Size = new System.Drawing.Size(157, 21);
            this.chkBinzarizacaoDupla.TabIndex = 14;
            this.chkBinzarizacaoDupla.Text = "Binarize duas vezes";
            this.chkBinzarizacaoDupla.UseVisualStyleBackColor = true;
            // 
            // lblLetrasProcurar
            // 
            this.lblLetrasProcurar.AutoSize = true;
            this.lblLetrasProcurar.Location = new System.Drawing.Point(11, 459);
            this.lblLetrasProcurar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLetrasProcurar.Name = "lblLetrasProcurar";
            this.lblLetrasProcurar.Size = new System.Drawing.Size(143, 17);
            this.lblLetrasProcurar.TabIndex = 15;
            this.lblLetrasProcurar.Text = "Letras para procurar:";
            // 
            // txtLetrasProcurar
            // 
            this.txtLetrasProcurar.Location = new System.Drawing.Point(147, 459);
            this.txtLetrasProcurar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLetrasProcurar.Name = "txtLetrasProcurar";
            this.txtLetrasProcurar.Size = new System.Drawing.Size(425, 22);
            this.txtLetrasProcurar.TabIndex = 16;
            // 
            // txtLetrasExcluir
            // 
            this.txtLetrasExcluir.Location = new System.Drawing.Point(147, 487);
            this.txtLetrasExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLetrasExcluir.Name = "txtLetrasExcluir";
            this.txtLetrasExcluir.Size = new System.Drawing.Size(425, 22);
            this.txtLetrasExcluir.TabIndex = 18;
            // 
            // lblLetrasExcluir
            // 
            this.lblLetrasExcluir.AutoSize = true;
            this.lblLetrasExcluir.Location = new System.Drawing.Point(11, 487);
            this.lblLetrasExcluir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLetrasExcluir.Name = "lblLetrasExcluir";
            this.lblLetrasExcluir.Size = new System.Drawing.Size(130, 17);
            this.lblLetrasExcluir.TabIndex = 17;
            this.lblLetrasExcluir.Text = "Letras para Excluir:";
            // 
            // txtQualidadeTexto
            // 
            this.txtQualidadeTexto.Location = new System.Drawing.Point(340, 556);
            this.txtQualidadeTexto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQualidadeTexto.Name = "txtQualidadeTexto";
            this.txtQualidadeTexto.Size = new System.Drawing.Size(69, 22);
            this.txtQualidadeTexto.TabIndex = 22;
            // 
            // lblQualidade
            // 
            this.lblQualidade.AutoSize = true;
            this.lblQualidade.Location = new System.Drawing.Point(19, 560);
            this.lblQualidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQualidade.Name = "lblQualidade";
            this.lblQualidade.Size = new System.Drawing.Size(247, 17);
            this.lblQualidade.TabIndex = 21;
            this.lblQualidade.Text = "Qualidade do texto (0..100; -1 - auto):";
            // 
            // txtLimiarBinarizacao
            // 
            this.txtLimiarBinarizacao.Location = new System.Drawing.Point(340, 524);
            this.txtLimiarBinarizacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLimiarBinarizacao.Name = "txtLimiarBinarizacao";
            this.txtLimiarBinarizacao.Size = new System.Drawing.Size(69, 22);
            this.txtLimiarBinarizacao.TabIndex = 20;
            // 
            // lblLimiar
            // 
            this.lblLimiar.AutoSize = true;
            this.lblLimiar.Location = new System.Drawing.Point(19, 528);
            this.lblLimiar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLimiar.Name = "lblLimiar";
            this.lblLimiar.Size = new System.Drawing.Size(315, 17);
            this.lblLimiar.TabIndex = 19;
            this.lblLimiar.Text = "Limiar de binarização (0..254; 255 - automático):";
            // 
            // txtRenderizacaoPDF
            // 
            this.txtRenderizacaoPDF.Location = new System.Drawing.Point(340, 588);
            this.txtRenderizacaoPDF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRenderizacaoPDF.Name = "txtRenderizacaoPDF";
            this.txtRenderizacaoPDF.Size = new System.Drawing.Size(69, 22);
            this.txtRenderizacaoPDF.TabIndex = 24;
            // 
            // lblRenderizacaoPDF
            // 
            this.lblRenderizacaoPDF.AutoSize = true;
            this.lblRenderizacaoPDF.Location = new System.Drawing.Point(19, 592);
            this.lblRenderizacaoPDF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRenderizacaoPDF.Name = "lblRenderizacaoPDF";
            this.lblRenderizacaoPDF.Size = new System.Drawing.Size(173, 17);
            this.lblRenderizacaoPDF.TabIndex = 23;
            this.lblRenderizacaoPDF.Text = "Renderização DPI do PDF";
            // 
            // chkCharMistos
            // 
            this.chkCharMistos.AutoSize = true;
            this.chkCharMistos.Location = new System.Drawing.Point(20, 368);
            this.chkCharMistos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCharMistos.Name = "chkCharMistos";
            this.chkCharMistos.Size = new System.Drawing.Size(425, 21);
            this.chkCharMistos.TabIndex = 26;
            this.chkCharMistos.Text = "Caracteres mistos corretos (letras e dígitos na mesma palavra)";
            this.chkCharMistos.UseVisualStyleBackColor = true;
            // 
            // chkDicionario
            // 
            this.chkDicionario.AutoSize = true;
            this.chkDicionario.Location = new System.Drawing.Point(20, 396);
            this.chkDicionario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDicionario.Name = "chkDicionario";
            this.chkDicionario.Size = new System.Drawing.Size(120, 21);
            this.chkDicionario.TabIndex = 27;
            this.chkDicionario.Text = "Use dicionário";
            this.chkDicionario.UseVisualStyleBackColor = true;
            // 
            // chkCombinarZonaHorizontal
            // 
            this.chkCombinarZonaHorizontal.AutoSize = true;
            this.chkCombinarZonaHorizontal.Location = new System.Drawing.Point(20, 425);
            this.chkCombinarZonaHorizontal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCombinarZonaHorizontal.Name = "chkCombinarZonaHorizontal";
            this.chkCombinarZonaHorizontal.Size = new System.Drawing.Size(237, 21);
            this.chkCombinarZonaHorizontal.TabIndex = 28;
            this.chkCombinarZonaHorizontal.Text = "Combinar zonas horizontalmente";
            this.chkCombinarZonaHorizontal.UseVisualStyleBackColor = true;
            // 
            // frmOpcoesFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 719);
            this.Controls.Add(this.chkCombinarZonaHorizontal);
            this.Controls.Add(this.chkDicionario);
            this.Controls.Add(this.chkCharMistos);
            this.Controls.Add(this.txtRenderizacaoPDF);
            this.Controls.Add(this.lblRenderizacaoPDF);
            this.Controls.Add(this.txtQualidadeTexto);
            this.Controls.Add(this.lblQualidade);
            this.Controls.Add(this.txtLimiarBinarizacao);
            this.Controls.Add(this.lblLimiar);
            this.Controls.Add(this.txtLetrasExcluir);
            this.Controls.Add(this.lblLetrasExcluir);
            this.Controls.Add(this.txtLetrasProcurar);
            this.Controls.Add(this.lblLetrasProcurar);
            this.Controls.Add(this.chkBinzarizacaoDupla);
            this.Controls.Add(this.chkModoRapido);
            this.Controls.Add(this.chkModoCinza);
            this.Controls.Add(this.chkRemoverLinhas);
            this.Controls.Add(this.chkFiltroRuido);
            this.Controls.Add(this.chkRotacao);
            this.Controls.Add(this.chkDistorcao);
            this.Controls.Add(this.chkZonasInversas);
            this.Controls.Add(this.chkImagemInversa);
            this.Controls.Add(this.chkCodigoBarras);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblAvisoRecarregar);
            this.Controls.Add(this.lblAvisoDesempenho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpcoesFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções de Filtro";
            this.Load += new System.EventHandler(this.CarregarFormulario);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvisoDesempenho;
        private System.Windows.Forms.Label lblAvisoRecarregar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkCodigoBarras;
        private System.Windows.Forms.CheckBox chkImagemInversa;
        private System.Windows.Forms.CheckBox chkZonasInversas;
        private System.Windows.Forms.CheckBox chkDistorcao;
        private System.Windows.Forms.CheckBox chkRotacao;
        private System.Windows.Forms.CheckBox chkFiltroRuido;
        private System.Windows.Forms.CheckBox chkRemoverLinhas;
        private System.Windows.Forms.CheckBox chkModoCinza;
        private System.Windows.Forms.CheckBox chkModoRapido;
        private System.Windows.Forms.CheckBox chkBinzarizacaoDupla;
        private System.Windows.Forms.Label lblLetrasProcurar;
        private System.Windows.Forms.TextBox txtLetrasProcurar;
        private System.Windows.Forms.TextBox txtLetrasExcluir;
        private System.Windows.Forms.Label lblLetrasExcluir;
        private System.Windows.Forms.TextBox txtQualidadeTexto;
        private System.Windows.Forms.Label lblQualidade;
        private System.Windows.Forms.TextBox txtLimiarBinarizacao;
        private System.Windows.Forms.Label lblLimiar;
        private System.Windows.Forms.TextBox txtRenderizacaoPDF;
        private System.Windows.Forms.Label lblRenderizacaoPDF;
        private System.Windows.Forms.CheckBox chkCharMistos;
        private System.Windows.Forms.CheckBox chkDicionario;
        private System.Windows.Forms.CheckBox chkCombinarZonaHorizontal;
    }
}