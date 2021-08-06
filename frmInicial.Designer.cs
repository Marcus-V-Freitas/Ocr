namespace Ocr
{
    partial class frmInicial
    {

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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicial));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTamanho = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInclinar = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinhas = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInvertido = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.txtTextoArquivo = new System.Windows.Forms.RichTextBox();
            this.chkVisualizarCaracteres = new System.Windows.Forms.CheckBox();
            this.chkVisualizarLinhasPix = new System.Windows.Forms.CheckBox();
            this.btnDetectarBlocos = new System.Windows.Forms.Button();
            this.btnLimparBlocos = new System.Windows.Forms.Button();
            this.chkVisualizarBinarizacao = new System.Windows.Forms.CheckBox();
            this.chkCopiaExata = new System.Windows.Forms.CheckBox();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.btnRecognizar = new System.Windows.Forms.Button();
            this.opdImagemUpload = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroPagina = new System.Windows.Forms.TextBox();
            this.lblNumeroPagina = new System.Windows.Forms.Label();
            this.btnMudarPagina = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEscala = new System.Windows.Forms.ComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.opBlocks = new System.Windows.Forms.OpenFileDialog();
            this.svBlocks = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIntegracoes = new System.Windows.Forms.Button();
            this.btnClipBoard = new System.Windows.Forms.Button();
            this.btnMudarIdioma = new System.Windows.Forms.Button();
            this.btnOpcoes = new System.Windows.Forms.Button();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.txtOcorrencias = new System.Windows.Forms.TextBox();
            this.lblQtdeResultados = new System.Windows.Forms.Label();
            this.lblTextoProcurar = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpOpcoesImagem = new System.Windows.Forms.GroupBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPastaIntegracao = new System.Windows.Forms.TextBox();
            this.lblPastaIntegracao = new System.Windows.Forms.Label();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTempoIntegracao = new System.Windows.Forms.ComboBox();
            this.timerIntegracao = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOpcoesImagem.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTamanho,
            this.lblInclinar,
            this.lblLinhas,
            this.lblInvertido});
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1401, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTamanho
            // 
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(0, 16);
            // 
            // lblInclinar
            // 
            this.lblInclinar.Name = "lblInclinar";
            this.lblInclinar.Size = new System.Drawing.Size(0, 16);
            // 
            // lblLinhas
            // 
            this.lblLinhas.Name = "lblLinhas";
            this.lblLinhas.Size = new System.Drawing.Size(0, 16);
            // 
            // lblInvertido
            // 
            this.lblInvertido.Name = "lblInvertido";
            this.lblInvertido.Size = new System.Drawing.Size(0, 16);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 153);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicBox);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.RedimensionamentoPainel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTextoArquivo);
            this.splitContainer1.Size = new System.Drawing.Size(1388, 453);
            this.splitContainer1.SplitterDistance = 662;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
            // 
            // PicBox
            // 
            this.PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicBox.Location = new System.Drawing.Point(6, 4);
            this.PicBox.Margin = new System.Windows.Forms.Padding(4);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(649, 445);
            this.PicBox.TabIndex = 8;
            this.PicBox.TabStop = false;
            this.PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDOWN);
            this.PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovimentoMouse);
            this.PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUP);
            // 
            // txtTextoArquivo
            // 
            this.txtTextoArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextoArquivo.Location = new System.Drawing.Point(5, -1);
            this.txtTextoArquivo.Name = "txtTextoArquivo";
            this.txtTextoArquivo.ReadOnly = true;
            this.txtTextoArquivo.Size = new System.Drawing.Size(712, 450);
            this.txtTextoArquivo.TabIndex = 9;
            this.txtTextoArquivo.Text = "";
            // 
            // chkVisualizarCaracteres
            // 
            this.chkVisualizarCaracteres.AutoSize = true;
            this.chkVisualizarCaracteres.Location = new System.Drawing.Point(8, 76);
            this.chkVisualizarCaracteres.Margin = new System.Windows.Forms.Padding(4);
            this.chkVisualizarCaracteres.Name = "chkVisualizarCaracteres";
            this.chkVisualizarCaracteres.Size = new System.Drawing.Size(223, 21);
            this.chkVisualizarCaracteres.TabIndex = 15;
            this.chkVisualizarCaracteres.Text = "Mostrar gráficos de caracteres";
            this.chkVisualizarCaracteres.UseVisualStyleBackColor = true;
            this.chkVisualizarCaracteres.CheckedChanged += new System.EventHandler(this.RedimensionamentoPainel);
            // 
            // chkVisualizarLinhasPix
            // 
            this.chkVisualizarLinhasPix.AutoSize = true;
            this.chkVisualizarLinhasPix.Location = new System.Drawing.Point(7, 35);
            this.chkVisualizarLinhasPix.Margin = new System.Windows.Forms.Padding(4);
            this.chkVisualizarLinhasPix.Name = "chkVisualizarLinhasPix";
            this.chkVisualizarLinhasPix.Size = new System.Drawing.Size(192, 21);
            this.chkVisualizarLinhasPix.TabIndex = 14;
            this.chkVisualizarLinhasPix.Text = "Mostrar linhas da imagem";
            this.chkVisualizarLinhasPix.UseVisualStyleBackColor = true;
            this.chkVisualizarLinhasPix.CheckedChanged += new System.EventHandler(this.RedimensionamentoPainel);
            // 
            // btnDetectarBlocos
            // 
            this.btnDetectarBlocos.Location = new System.Drawing.Point(3, 84);
            this.btnDetectarBlocos.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetectarBlocos.Name = "btnDetectarBlocos";
            this.btnDetectarBlocos.Size = new System.Drawing.Size(161, 28);
            this.btnDetectarBlocos.TabIndex = 13;
            this.btnDetectarBlocos.Text = "Detectar zonas";
            this.btnDetectarBlocos.UseVisualStyleBackColor = true;
            this.btnDetectarBlocos.Click += new System.EventHandler(this.DetectarDeteletarBlocos);
            // 
            // btnLimparBlocos
            // 
            this.btnLimparBlocos.Enabled = false;
            this.btnLimparBlocos.Location = new System.Drawing.Point(166, 84);
            this.btnLimparBlocos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparBlocos.Name = "btnLimparBlocos";
            this.btnLimparBlocos.Size = new System.Drawing.Size(143, 28);
            this.btnLimparBlocos.TabIndex = 12;
            this.btnLimparBlocos.Text = "Limpar zonas";
            this.btnLimparBlocos.UseVisualStyleBackColor = true;
            this.btnLimparBlocos.Click += new System.EventHandler(this.LimparBlocos);
            // 
            // chkVisualizarBinarizacao
            // 
            this.chkVisualizarBinarizacao.AutoSize = true;
            this.chkVisualizarBinarizacao.Location = new System.Drawing.Point(7, 15);
            this.chkVisualizarBinarizacao.Margin = new System.Windows.Forms.Padding(4);
            this.chkVisualizarBinarizacao.Name = "chkVisualizarBinarizacao";
            this.chkVisualizarBinarizacao.Size = new System.Drawing.Size(187, 21);
            this.chkVisualizarBinarizacao.TabIndex = 9;
            this.chkVisualizarBinarizacao.Text = "Exibir imagem binarizada";
            this.chkVisualizarBinarizacao.UseVisualStyleBackColor = true;
            this.chkVisualizarBinarizacao.CheckedChanged += new System.EventHandler(this.Binarizacao);
            // 
            // chkCopiaExata
            // 
            this.chkCopiaExata.AutoSize = true;
            this.chkCopiaExata.Location = new System.Drawing.Point(8, 55);
            this.chkCopiaExata.Margin = new System.Windows.Forms.Padding(4);
            this.chkCopiaExata.Name = "chkCopiaExata";
            this.chkCopiaExata.Size = new System.Drawing.Size(221, 21);
            this.chkCopiaExata.TabIndex = 23;
            this.chkCopiaExata.Text = "Cópia exata (Sem formatação)";
            this.chkCopiaExata.UseVisualStyleBackColor = true;
            this.chkCopiaExata.CheckedChanged += new System.EventHandler(this.SelecionarCopiaExata);
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Location = new System.Drawing.Point(3, 23);
            this.btnAbrirArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(161, 28);
            this.btnAbrirArquivo.TabIndex = 9;
            this.btnAbrirArquivo.Text = "Abrir Arquivo Único";
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.AbrirDocumento);
            // 
            // btnRecognizar
            // 
            this.btnRecognizar.Location = new System.Drawing.Point(166, 116);
            this.btnRecognizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognizar.Name = "btnRecognizar";
            this.btnRecognizar.Size = new System.Drawing.Size(143, 28);
            this.btnRecognizar.TabIndex = 10;
            this.btnRecognizar.Text = "Recognizar";
            this.btnRecognizar.UseVisualStyleBackColor = true;
            this.btnRecognizar.Click += new System.EventHandler(this.Recognizar);
            // 
            // opdImagemUpload
            // 
            this.opdImagemUpload.Filter = "Image Files (bmp, jpg, tif, png, gif, pdf)|*.bmp;*.jpg;*.tif;*.png;*.gif;*.pdf|Al" +
    "l Files|*";
            this.opdImagemUpload.Title = "Open Image File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Página";
            // 
            // txtNumeroPagina
            // 
            this.txtNumeroPagina.Location = new System.Drawing.Point(67, 29);
            this.txtNumeroPagina.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Size = new System.Drawing.Size(103, 22);
            this.txtNumeroPagina.TabIndex = 13;
            this.txtNumeroPagina.Text = "1";
            // 
            // lblNumeroPagina
            // 
            this.lblNumeroPagina.AutoSize = true;
            this.lblNumeroPagina.Location = new System.Drawing.Point(178, 29);
            this.lblNumeroPagina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroPagina.Name = "lblNumeroPagina";
            this.lblNumeroPagina.Size = new System.Drawing.Size(36, 17);
            this.lblNumeroPagina.TabIndex = 14;
            this.lblNumeroPagina.Text = "de 1";
            // 
            // btnMudarPagina
            // 
            this.btnMudarPagina.Location = new System.Drawing.Point(10, 58);
            this.btnMudarPagina.Margin = new System.Windows.Forms.Padding(4);
            this.btnMudarPagina.Name = "btnMudarPagina";
            this.btnMudarPagina.Size = new System.Drawing.Size(228, 28);
            this.btnMudarPagina.TabIndex = 15;
            this.btnMudarPagina.Text = "Alterar Página";
            this.btnMudarPagina.UseVisualStyleBackColor = true;
            this.btnMudarPagina.Click += new System.EventHandler(this.MudarPagina);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Escala:";
            // 
            // cboEscala
            // 
            this.cboEscala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEscala.FormattingEnabled = true;
            this.cboEscala.Items.AddRange(new object[] {
            "Auto",
            "0.25",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "4.0"});
            this.cboEscala.Location = new System.Drawing.Point(67, 103);
            this.cboEscala.Margin = new System.Windows.Forms.Padding(4);
            this.cboEscala.Name = "cboEscala";
            this.cboEscala.Size = new System.Drawing.Size(169, 24);
            this.cboEscala.TabIndex = 17;
            this.cboEscala.SelectedIndexChanged += new System.EventHandler(this.SelecionarEscala);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(317, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(317, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(317, 6);
            // 
            // opBlocks
            // 
            this.opBlocks.DefaultExt = "blk";
            this.opBlocks.Filter = "blk files|*.blk";
            // 
            // svBlocks
            // 
            this.svBlocks.DefaultExt = "blk";
            this.svBlocks.Filter = "blk files|*.blk";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIntegracoes);
            this.groupBox1.Controls.Add(this.btnClipBoard);
            this.groupBox1.Controls.Add(this.btnLimparBlocos);
            this.groupBox1.Controls.Add(this.btnMudarIdioma);
            this.groupBox1.Controls.Add(this.btnDetectarBlocos);
            this.groupBox1.Controls.Add(this.btnOpcoes);
            this.groupBox1.Controls.Add(this.btnAbrirArquivo);
            this.groupBox1.Controls.Add(this.btnRecognizar);
            this.groupBox1.Location = new System.Drawing.Point(16, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(317, 145);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // btnIntegracoes
            // 
            this.btnIntegracoes.Location = new System.Drawing.Point(3, 116);
            this.btnIntegracoes.Name = "btnIntegracoes";
            this.btnIntegracoes.Size = new System.Drawing.Size(161, 28);
            this.btnIntegracoes.TabIndex = 32;
            this.btnIntegracoes.Text = "Ativar Integrações";
            this.btnIntegracoes.UseVisualStyleBackColor = true;
            this.btnIntegracoes.Click += new System.EventHandler(this.btnIntegracoes_Click);
            // 
            // btnClipBoard
            // 
            this.btnClipBoard.Location = new System.Drawing.Point(166, 22);
            this.btnClipBoard.Margin = new System.Windows.Forms.Padding(4);
            this.btnClipBoard.Name = "btnClipBoard";
            this.btnClipBoard.Size = new System.Drawing.Size(143, 28);
            this.btnClipBoard.TabIndex = 31;
            this.btnClipBoard.Text = "Colar ClipBoard";
            this.btnClipBoard.UseVisualStyleBackColor = true;
            this.btnClipBoard.Click += new System.EventHandler(this.btnClipBoard_Click);
            // 
            // btnMudarIdioma
            // 
            this.btnMudarIdioma.Location = new System.Drawing.Point(166, 52);
            this.btnMudarIdioma.Margin = new System.Windows.Forms.Padding(4);
            this.btnMudarIdioma.Name = "btnMudarIdioma";
            this.btnMudarIdioma.Size = new System.Drawing.Size(142, 28);
            this.btnMudarIdioma.TabIndex = 0;
            this.btnMudarIdioma.Text = "Selecione o idioma";
            this.btnMudarIdioma.UseVisualStyleBackColor = true;
            this.btnMudarIdioma.Click += new System.EventHandler(this.SelecionarIdioma);
            // 
            // btnOpcoes
            // 
            this.btnOpcoes.Location = new System.Drawing.Point(3, 53);
            this.btnOpcoes.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpcoes.Name = "btnOpcoes";
            this.btnOpcoes.Size = new System.Drawing.Size(161, 28);
            this.btnOpcoes.TabIndex = 30;
            this.btnOpcoes.Text = "Opções Avançadas";
            this.btnOpcoes.UseVisualStyleBackColor = true;
            this.btnOpcoes.Click += new System.EventHandler(this.SelecionarOpcoesAdicionais);
            // 
            // txtProcurar
            // 
            this.txtProcurar.Location = new System.Drawing.Point(127, 20);
            this.txtProcurar.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(420, 22);
            this.txtProcurar.TabIndex = 31;
            // 
            // txtOcorrencias
            // 
            this.txtOcorrencias.Enabled = false;
            this.txtOcorrencias.Location = new System.Drawing.Point(127, 48);
            this.txtOcorrencias.Margin = new System.Windows.Forms.Padding(4);
            this.txtOcorrencias.Name = "txtOcorrencias";
            this.txtOcorrencias.Size = new System.Drawing.Size(137, 22);
            this.txtOcorrencias.TabIndex = 32;
            // 
            // lblQtdeResultados
            // 
            this.lblQtdeResultados.AutoSize = true;
            this.lblQtdeResultados.Location = new System.Drawing.Point(17, 49);
            this.lblQtdeResultados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtdeResultados.Name = "lblQtdeResultados";
            this.lblQtdeResultados.Size = new System.Drawing.Size(108, 17);
            this.lblQtdeResultados.TabIndex = 33;
            this.lblQtdeResultados.Text = "Nº Ocorrências:";
            // 
            // lblTextoProcurar
            // 
            this.lblTextoProcurar.AutoSize = true;
            this.lblTextoProcurar.Location = new System.Drawing.Point(7, 25);
            this.lblTextoProcurar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoProcurar.Name = "lblTextoProcurar";
            this.lblTextoProcurar.Size = new System.Drawing.Size(118, 17);
            this.lblTextoProcurar.TabIndex = 34;
            this.lblTextoProcurar.Text = "Texto a Procurar:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNumeroPagina);
            this.groupBox2.Controls.Add(this.btnMudarPagina);
            this.groupBox2.Controls.Add(this.lblNumeroPagina);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboEscala);
            this.groupBox2.Location = new System.Drawing.Point(340, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 145);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Páginas";
            // 
            // grpOpcoesImagem
            // 
            this.grpOpcoesImagem.Controls.Add(this.cboTempoIntegracao);
            this.grpOpcoesImagem.Controls.Add(this.label3);
            this.grpOpcoesImagem.Controls.Add(this.chkVisualizarBinarizacao);
            this.grpOpcoesImagem.Controls.Add(this.chkVisualizarCaracteres);
            this.grpOpcoesImagem.Controls.Add(this.chkVisualizarLinhasPix);
            this.grpOpcoesImagem.Controls.Add(this.chkCopiaExata);
            this.grpOpcoesImagem.Location = new System.Drawing.Point(591, 8);
            this.grpOpcoesImagem.Name = "grpOpcoesImagem";
            this.grpOpcoesImagem.Size = new System.Drawing.Size(238, 138);
            this.grpOpcoesImagem.TabIndex = 36;
            this.grpOpcoesImagem.TabStop = false;
            this.grpOpcoesImagem.Text = "Filtros";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.chkCaseSensitive);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.lblTextoProcurar);
            this.grpFiltros.Controls.Add(this.txtOcorrencias);
            this.grpFiltros.Controls.Add(this.lblQtdeResultados);
            this.grpFiltros.Controls.Add(this.txtProcurar);
            this.grpFiltros.Location = new System.Drawing.Point(835, 8);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(554, 74);
            this.grpFiltros.TabIndex = 37;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de Procura";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscar.Location = new System.Drawing.Point(410, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(138, 24);
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPastaIntegracao);
            this.groupBox5.Controls.Add(this.lblPastaIntegracao);
            this.groupBox5.Location = new System.Drawing.Point(835, 84);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(554, 61);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Integração Automática";
            // 
            // txtPastaIntegracao
            // 
            this.txtPastaIntegracao.Enabled = false;
            this.txtPastaIntegracao.Location = new System.Drawing.Point(61, 23);
            this.txtPastaIntegracao.Name = "txtPastaIntegracao";
            this.txtPastaIntegracao.Size = new System.Drawing.Size(486, 22);
            this.txtPastaIntegracao.TabIndex = 1;
            this.txtPastaIntegracao.Text = "C:\\Users\\marcus.costa\\Desktop\\Testes";
            // 
            // lblPastaIntegracao
            // 
            this.lblPastaIntegracao.AutoSize = true;
            this.lblPastaIntegracao.Location = new System.Drawing.Point(11, 26);
            this.lblPastaIntegracao.Name = "lblPastaIntegracao";
            this.lblPastaIntegracao.Size = new System.Drawing.Size(44, 17);
            this.lblPastaIntegracao.TabIndex = 0;
            this.lblPastaIntegracao.Text = "Pasta";
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseSensitive.Location = new System.Drawing.Point(284, 48);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(120, 21);
            this.chkCaseSensitive.TabIndex = 38;
            this.chkCaseSensitive.Text = "Case Sentitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Integrar a cada:";
            // 
            // cboTempoIntegracao
            // 
            this.cboTempoIntegracao.DisplayMember = "strValor";
            this.cboTempoIntegracao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTempoIntegracao.Enabled = false;
            this.cboTempoIntegracao.FormattingEnabled = true;
            this.cboTempoIntegracao.Location = new System.Drawing.Point(111, 102);
            this.cboTempoIntegracao.Name = "cboTempoIntegracao";
            this.cboTempoIntegracao.Size = new System.Drawing.Size(121, 24);
            this.cboTempoIntegracao.TabIndex = 26;
            this.cboTempoIntegracao.ValueMember = "intValor";
            this.cboTempoIntegracao.SelectedIndexChanged += new System.EventHandler(this.cboTempoIntegracao_SelectedIndexChanged);
            // 
            // timerIntegracao
            // 
            this.timerIntegracao.Enabled = true;
            this.timerIntegracao.Interval = 3600;
            this.timerIntegracao.Tick += new System.EventHandler(this.timerIntegracao_Tick);
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 636);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpOpcoesImagem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInicial";
            this.Text = "OCR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FecharFormulario);
            this.Load += new System.EventHandler(this.CarregarFormulario);
            this.Resize += new System.EventHandler(this.RedimensionamentoPainel);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpOpcoesImagem.ResumeLayout(false);
            this.grpOpcoesImagem.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox PicBox;
        public System.Windows.Forms.Button btnAbrirArquivo;
        public System.Windows.Forms.Button btnRecognizar;
        public System.Windows.Forms.OpenFileDialog opdImagemUpload;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNumeroPagina;
        public System.Windows.Forms.Label lblNumeroPagina;
        public System.Windows.Forms.Button btnMudarPagina;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboEscala;
        public System.Windows.Forms.CheckBox chkCopiaExata;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.CheckBox chkVisualizarBinarizacao;
        public System.Windows.Forms.Button btnLimparBlocos;
        public System.Windows.Forms.OpenFileDialog opBlocks;
        public System.Windows.Forms.SaveFileDialog svBlocks;
        public System.Windows.Forms.Button btnDetectarBlocos;
        public System.Windows.Forms.ToolStripStatusLabel lblInclinar;
        public System.Windows.Forms.ToolStripStatusLabel lblTamanho;
        public System.Windows.Forms.ToolStripStatusLabel lblLinhas;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnMudarIdioma;
        public System.Windows.Forms.CheckBox chkVisualizarLinhasPix;
        public System.Windows.Forms.ToolStripStatusLabel lblInvertido;
        public System.Windows.Forms.Button btnOpcoes;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.CheckBox chkVisualizarCaracteres;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.TextBox txtOcorrencias;
        private System.Windows.Forms.Label lblQtdeResultados;
        private System.Windows.Forms.Label lblTextoProcurar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpOpcoesImagem;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtPastaIntegracao;
        private System.Windows.Forms.Label lblPastaIntegracao;
        public System.Windows.Forms.Button btnClipBoard;
        private System.Windows.Forms.Button btnIntegracoes;
        private System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.RichTextBox txtTextoArquivo;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.ComboBox cboTempoIntegracao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerIntegracao;
        private System.ComponentModel.IContainer components;
    }
}
