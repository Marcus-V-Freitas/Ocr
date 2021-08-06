using NSOCR;
using Ocr.Enums;
using Ocr.Classes.MetodosOCR.Interfaces;
using Ocr.Enums;
using Ocr.MetodosExtensao;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;

namespace Ocr.Classes.MetodosOCR.Implementacoes
{
    public class ConversaoGeralOCR : IConverterDoc
    {
        public string CaminhoArquivo { get; set; }
        private readonly frmInicial frmInicial;
        private int intNumeroPaginas = 1;
        private Image Images = null;
        private IMetodosDocumentos Metodos = null;
        private TiposModosCarregamentoOCR intModoCarregamento = TiposModosCarregamentoOCR.arquivo;
        private int intQuantidadePaginas = 1;

        /// <summary>
        /// Construtor padrão para documentos PDF e Imagem (PNG, JPEG ou JPG)
        /// </summary>
        /// <param name="inicial"> Referência para o Formulário principal </param>
        public ConversaoGeralOCR(frmInicial inicial)
        {
            frmInicial = inicial;
            Metodos = null;
            intModoCarregamento = TiposModosCarregamentoOCR.arquivo; //0
        }

        /// <summary>
        /// Construtor padrão para documentos DOC, DOCX, TXT, XLS e XLSX
        /// </summary>
        /// <param name="inicial"> Referência para o Formulário principal </param>
        /// <param name="metodos"> Método que definirá como será a extração do texto especifica </param>
        public ConversaoGeralOCR(frmInicial inicial, IMetodosDocumentos metodos) : this(inicial)
        {
            Metodos = metodos;
            intModoCarregamento = TiposModosCarregamentoOCR.memóriaBitman; //2
        }

        /// <summary>
        /// Função que verifica se a imagem já está carregada
        /// </summary>
        /// <returns> true/false </returns>
        private bool ImagemCarregada()
        {
            if (!TNSOCR.bIniciado) return false;
            int intLargura, intAltura;
            if (TNSOCR.clsNsOCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura) > (int)TiposErrosOCR.ERROR_FIRST) return false;
            return (intLargura > 0) && (intAltura > 0);
        }

        /// <summary>
        /// Função que retorna o tamanho da escala do documento
        /// </summary>
        /// <returns> Escala do documento </returns>
        private float EscalaAtualDocumento()
        {
            float dblEscala = 1.0f;
            if (!ImagemCarregada()) return dblEscala;
            frmInicial.With(FORM =>
            {
                Rectangle retangulo = FORM.splitContainer1.Bounds;
                int intLarguraAjustada = FORM.splitContainer1.SplitterDistance - 15;
                int intAlturaAjustada = retangulo.Height - 45;

                //Pegar definições de tamanho e escala para o documento
                int intLargura, intAltura;
                TNSOCR.clsNsOCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);
                float intHorizontal = (float)intLarguraAjustada / intLargura;
                float intVertical = (float)intAlturaAjustada / intAltura;
                if (intHorizontal > intVertical)
                {
                    dblEscala = intVertical;
                }
                else
                {
                    dblEscala = intHorizontal;
                }
            });
            return dblEscala;
        }

        /// <summary>
        /// Função que desenha a imagem de acordo com as especificações de palavras,
        /// escalas, e profunidade encontradas
        /// </summary>
        private void MostrarImagem()
        {
            try
            {
                if (!ImagemCarregada()) return;
                float dblEscala = EscalaAtualDocumento();

                Color color;
                Rectangle retangulo = new Rectangle();
                int intLarguraBit = TNSOCR.ImagemBMP.Width;
                int intAlturaBit = TNSOCR.ImagemBMP.Height;

                Image ImagePicBox = new Bitmap(intLarguraBit, intAlturaBit, TNSOCR.Graficos);
                Graphics graphic = Graphics.FromImage(ImagePicBox);
                graphic.DrawImage(TNSOCR.ImagemBMP, 0, 0);

                //Caso marcada Visualizar as linhas Pix
                if (frmInicial.chkVisualizarLinhasPix.Checked)
                    DesenharLinhasPix(graphic);

                //Caso marcada visualizar as delimitações de letras e linhas
                if (frmInicial.chkVisualizarCaracteres.Checked)
                    DesenharRentangulosDeLetras(graphic);

                //Pega definições de blocos formadores da imagem e seus tipos
                int intIndice, intBlocoAtual, intPosHorizontal, intPosVertical, intLarguraBloco, intAlturaBloco;
                Pen pen = new Pen(Color.Green);
                int intQuantidadeBlocos = TNSOCR.clsNsOCR.Img_GetBlockCnt(TNSOCR.intObjImagem);
                for (intIndice = 0; intIndice < intQuantidadeBlocos; intIndice++)
                {
                    TNSOCR.clsNsOCR.Img_GetBlock(TNSOCR.intObjImagem, intIndice, out intBlocoAtual);
                    TNSOCR.clsNsOCR.Blk_GetRect(intBlocoAtual, out intPosHorizontal, out intPosVertical, out intLarguraBloco, out intAlturaBloco);
                    retangulo.X = (int)(dblEscala * intPosHorizontal);
                    retangulo.Y = (int)(dblEscala * intPosVertical);
                    retangulo.Width = (int)(dblEscala * intLarguraBloco);
                    retangulo.Height = (int)(dblEscala * intAlturaBloco);

                    color = Color.Red;
                    switch (TNSOCR.clsNsOCR.Blk_GetType(intBlocoAtual))
                    {
                        case (int)TiposBlocos.BT_OCRTEXT: color = Color.Green; break;
                        case (int)TiposBlocos.BT_OCRDIGIT: color = Color.Lime; break;
                        case (int)TiposBlocos.BT_ICRDIGIT: color = Color.Blue; break;
                        case (int)TiposBlocos.BT_BARCODE: color = Color.Navy; break;
                        case (int)TiposBlocos.BT_PICTURE: color = Color.Aqua; break;
                        case (int)TiposBlocos.BT_CLEAR: color = Color.Gray; break;
                        case (int)TiposBlocos.BT_ZONING: color = Color.Black; break;
                        case (int)TiposBlocos.BT_TABLE: color = Color.Olive; break;
                        case (int)TiposBlocos.BT_MRZ: color = Color.Black; break;
                    }

                    pen.Width = 2;
                    pen.Color = color;
                    graphic.DrawRectangle(pen, retangulo);

                    Font font = new Font("Arial", 8);
                    Brush brush = new SolidBrush(Color.Lime);
                    PointF point = new PointF(retangulo.X, retangulo.Y);
                    retangulo.Width = 12;
                    retangulo.Height = 14;
                    graphic.FillRectangle(brush, retangulo);
                    brush = new SolidBrush(Color.Black);
                    graphic.DrawString(intIndice.ToString(), font, brush, point);
                }

                //Verifica se usuário está criando um novo bloco, desenhando no picturebox
                if (TNSOCR.bDesenhar)
                {
                    retangulo.X = (int)(dblEscala * TNSOCR.Retangulo.Left);
                    retangulo.Y = (int)(dblEscala * TNSOCR.Retangulo.Top);
                    retangulo.Width = (int)(dblEscala * TNSOCR.Retangulo.Width);
                    retangulo.Height = (int)(dblEscala * TNSOCR.Retangulo.Height);

                    if (retangulo.Width >= intLarguraBit) retangulo.Width = intLarguraBit - 1;
                    if (retangulo.Height >= intAlturaBit) retangulo.Height = intAlturaBit - 1;

                    pen = new Pen(Color.Red);
                    graphic.DrawRectangle(pen, retangulo);
                }

                frmInicial.PicBox.Image = ImagePicBox;

            }
            catch
            {
                throw;
            }
            finally
            {
                GC.Collect(); //Limpeza forçada a fim de remover resquicios da operação na memória
            }
        }

        /// <summary>
        /// Função que define as linhas que serão apresentadas no PictureBox
        /// </summary>
        /// <param name="graphic"> Gráficos definidos para a imagem </param>
        private void DesenharLinhasPix(Graphics graphic)
        {
            int intIndice, intQtdeLinhas, intHorizontal1, intVertical1, intHorizontal2, intVertical2, intAltura;
            float dblEscala;

            dblEscala = EscalaAtualDocumento();
            intQtdeLinhas = TNSOCR.clsNsOCR.Img_GetPixLineCnt(TNSOCR.intObjImagem);
            for (intIndice = 0; intIndice < intQtdeLinhas; intIndice++)
            {
                TNSOCR.clsNsOCR.Img_GetPixLine(TNSOCR.intObjImagem, intIndice, out intHorizontal1, out intVertical1, out intHorizontal2, out intVertical2, out intAltura);
                intHorizontal1 = (int)(dblEscala * intHorizontal1);
                intVertical1 = (int)(dblEscala * intVertical1);
                intHorizontal2 = (int)(dblEscala * intHorizontal2);
                intVertical2 = (int)(dblEscala * intVertical2);

                Point point1, point2;
                point1 = new Point(intHorizontal1, intVertical1);
                point2 = new Point(intHorizontal2, intVertical2);

                Pen pen = new Pen(Color.Red);
                pen.Width = 2;
                graphic.DrawLine(pen, point1, point2);
            }
        }

        /// <summary>
        /// Função que delimita o texto e as linhas encontradas com retângulos a fim de
        /// maximizar a recognição do documento
        /// </summary>
        /// <param name="graphic"> Gráficos a serem utilizados </param>
        private void DesenharRentangulosDeLetras(Graphics graphic)
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                int intQtdeBlocos, intBlocoAtual, intQtdeLinhas, intQtdePalavras, intQtdeCaracteres, intIndice1, intIndice2, intIndice3, intIndice4, intHorizontal, intVertical, intLargura, intAltura;
                float dblEscala;
                dblEscala = EscalaAtualDocumento();

                intQtdeBlocos = OCR.Img_GetBlockCnt(TNSOCR.intObjImagem);
                for (intIndice1 = 0; intIndice1 < intQtdeBlocos; intIndice1++)
                {
                    OCR.Img_GetBlock(TNSOCR.intObjImagem, intIndice1, out intBlocoAtual);
                    intQtdeLinhas = OCR.Blk_GetLineCnt(intBlocoAtual);
                    for (intIndice2 = 0; intIndice2 < intQtdeLinhas; intIndice2++)
                    {
                        intQtdePalavras = OCR.Blk_GetWordCnt(intBlocoAtual, intIndice2);
                        for (intIndice3 = 0; intIndice3 < intQtdePalavras; intIndice3++)
                        {
                            intQtdeCaracteres = OCR.Blk_GetCharCnt(intBlocoAtual, intIndice2, intIndice3);
                            for (intIndice4 = 0; intIndice4 < intQtdeCaracteres; intIndice4++)
                            {
                                OCR.Blk_GetCharRect(intBlocoAtual, intIndice2, intIndice3, intIndice4, out intHorizontal, out intVertical, out intLargura, out intAltura);

                                Pen pen = new Pen(Color.Blue);
                                graphic.DrawRectangle(pen, dblEscala * intHorizontal, dblEscala * intVertical, dblEscala * intLargura, dblEscala * intAltura);
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Função que reajusta a escala do documento para o tamanho normal
        /// </summary>
        public void AjustarEscalaDocumento()
        {
            frmInicial.With(FORM =>
            {
                if (!ImagemCarregada()) return;
                int intLarguraAjustada, intAlturaAjustada;

                Rectangle retangulo = FORM.splitContainer1.Bounds;
                intLarguraAjustada = FORM.splitContainer1.SplitterDistance - 15;
                intAlturaAjustada = retangulo.Height - 45;

                if ((intLarguraAjustada <= 0) || (intAlturaAjustada <= 0))
                    return;
                TNSOCR.ImagemBMP = new Bitmap(intLarguraAjustada, intAlturaAjustada, TNSOCR.Graficos);
                Graphics graphics = Graphics.FromImage(TNSOCR.ImagemBMP);
                IntPtr ptr = graphics.GetHdc();
                if (FORM.chkVisualizarBinarizacao.Checked) TNSOCR.clsNsOCR.Img_DrawToDC(TNSOCR.intObjImagem, (int)ptr, 0, 0, ref intLarguraAjustada, ref intAlturaAjustada, /*TNSOCR.DRAW_BINARY*/(int)TiposDesenho.DRAW_BINARY);
                else TNSOCR.clsNsOCR.Img_DrawToDC(TNSOCR.intObjImagem, (int)ptr, 0, 0, ref intLarguraAjustada, ref intAlturaAjustada, /*TNSOCR.DRAW_NORMAL*/(int)TiposDesenho.DRAW_NORMAL);
                graphics.ReleaseHdc(ptr);

                MostrarImagem();
            });
        }

        /// <summary>
        /// Função de abertura e de iniciação das configurações definidas
        /// para a recognição do documento
        /// </summary>
        /// <param name="strCaminhoArquivo"> Caminho do arquivo </param>
        public void AbrirDocumento(string strCaminhoArquivo)
        {
            CaminhoArquivo = strCaminhoArquivo;
            AjustarEscala();
            DefinicaoCarregamentoArquivo();
            ExecutarImagemCarregada();
        }

        private void DefinicaoCarregamentoArquivo()
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                // É possível carregar a imagem no arquivo, na memória ou nos dados de bitmap na memória
                //int intModoCarregamento = 2; //0 - arquivo; 1 - memória; 2 - memória bitmap
                int intResultadoErros;
                if (intModoCarregamento == TiposModosCarregamentoOCR.arquivo) //Carregamento no arquivo
                {
                    intResultadoErros = OCR.Img_LoadFile(TNSOCR.intObjImagem, CaminhoArquivo);
                }
                else if (intModoCarregamento == TiposModosCarregamentoOCR.memória) //carrega a imagem no OCR a partir da imagem na memória
                {
                    Array FileArray = File.ReadAllBytes(CaminhoArquivo);
                    intResultadoErros = OCR.Img_LoadFromMemory(TNSOCR.intObjImagem, ref FileArray, FileArray.Length);
                }
                else //carrega a imagem no mecanismo OCR do bitmap de memória
                {
                    CarregamentoImagem();

                    if (Images is null) throw new Exception("Documento colado não é uma imagem!");


                    Bitmap bmpImagem = new Bitmap(Images); //OBS: a classe "Bitmap" do .NET compreende apenas alguns formatos de imagem como BMP, JPG

                    // Bloqueia os bits do bitmap.
                    BitmapData DadosBMP = bmpImagem.LockBits(new Rectangle(0, 0, bmpImagem.Width, bmpImagem.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // Pega o endereço da primeira linha.
                    IntPtr ptr = DadosBMP.Scan0;

                    // Declaração de matriz para armazenar os bytes do bitmap.
                    int intBytes = Math.Abs(DadosBMP.Stride) * bmpImagem.Height;
                    byte[] rgbValues = new byte[intBytes];

                    //Copia os valores RGB para a matriz.
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, intBytes);

                    //Desbloqueia os bits.
                    bmpImagem.UnlockBits(DadosBMP);

                    //Converte para um array de tipos
                    Array BytesArray = rgbValues;

                    //Carrega a imagem no motor do OCR
                    intResultadoErros = OCR.Img_LoadBmpData(TNSOCR.intObjImagem, ref BytesArray, bmpImagem.Width, bmpImagem.Height, /*TNSOCR.BMP_24BIT*/(int)TiposImagemBMP.BMP_24BIT, 0);
                }

                if (intResultadoErros > (int)TiposErrosOCR.ERROR_FIRST)
                {
                    if (intResultadoErros == (int)TiposErrosOCR.ERROR_CANNOTLOADGS) //Acontece quando não existe o GhostScript (necessário para abertura de PDF's)
                    {
                        throw new Exception($"A biblioteca do GhostSript é necessária para arquivos de PDF.{/*TNSOCR.ERROR_CANNOTLOADGS*/(int)TiposErrosOCR.ERROR_CANNOTLOADGS}");
                    }
                    else
                        throw new Exception($"Img_LoadFile {intResultadoErros}");
                }
            });
        }

        /// <summary>
        /// Função que carrega a imagem no motor do OCR e retorna ao usuário
        /// as definições encontradas para a imagem
        /// </summary>
        private void ExecutarImagemCarregada()
        {
            frmInicial.With(FORM =>
            {
                TNSOCR.clsNsOCR.With(OCR =>
                {
                    int intResultado, intLargura, intAltura;

                    // verifica se a imagem possui várias páginas e pergunta ao usuário se ele deseja processar e salve todas as páginas automaticamente
                    intResultado = OCR.Img_GetPageCount(TNSOCR.intObjImagem);
                    if (intResultado > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        throw new Exception($"Img_GetPageCount {intResultado}");
                    }

                    //intNumeroPaginas = intResultado; //Número de Páginas

                    // Aplicar a escala de imagem, binarize a imagem, incline-a etc,
                    // tudo, exceto o próprio OCR
                    intResultado = OCR.Img_OCR(TNSOCR.intObjImagem, /*TNSOCR.OCRSTEP_FIRST*/(int)TiposParametrossOCR.OCRSTEP_FIRST, /*TNSOCR.OCRSTEP_ZONING */(int)TiposParametrossOCR.OCRSTEP_ZONING - 1, (int)TiposFlagsOCR.OCRFLAG_NONE);
                    if (intResultado > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        throw new Exception($"Img_OCR {intResultado}");
                    }

                    MostrarParametrosDeImagem();

                    intResultado = OCR.Img_GetSkewAngle(TNSOCR.intObjImagem);
                    if (intResultado > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        FORM.lblInclinar.Text = "";
                        throw new Exception($"Img_GetSkewAngle {intResultado}");
                    }
                    else FORM.lblInclinar.Text = "Ângulo de Inclinação (graus): " + (intResultado / 1000.0);

                    // Informações de linhas de pixel
                    intResultado = OCR.Img_GetPixLineCnt(TNSOCR.intObjImagem);
                    if (intResultado > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        throw new Exception($"Img_GetPixLineCnt {intResultado}");
                    }
                    FORM.lblLinhas.Text = $"Linhas: {intResultado}";

                    intResultado = OCR.Img_GetProperty(TNSOCR.intObjImagem, (int)TiposParametrosImagem.IMG_PROP_INVERTED);
                    FORM.lblInvertido.Text = (intResultado == 1) ? "Imagem Invertida: Sim" : "Imagem Invertida: Não";

                    FORM.txtNumeroPagina.Text = $"{((intModoCarregamento == 0) ? "1" : intNumeroPaginas.ToString())}";
                    FORM.lblNumeroPagina.Text = $"de {((intModoCarregamento == 0) ? OCR.Img_GetPageCount(TNSOCR.intObjImagem).ToString() : intQuantidadePaginas.ToString())}";

                    // tamanho final após o pré-processamento
                    OCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);

                    TNSOCR.Retangulo.X = 0;
                    TNSOCR.Retangulo.Y = 0;
                    TNSOCR.Retangulo.Width = 0;
                    TNSOCR.Retangulo.Height = 0;
                    AjustarEscalaDocumento();

                    FORM.btnRecognizar.Enabled = true;
                    FORM.txtTextoArquivo.Text = "";

                    FORM.btnLimparBlocos.Enabled = true;
                    FORM.btnDetectarBlocos.Enabled = true;
                });
            });
        }

        /// <summary>
        /// Função que pega as principais definições da imagem e configura
        /// para a visualização do usuário
        /// </summary>
        private void MostrarParametrosDeImagem()
        {
            frmInicial.With(FORM =>
            {
                TNSOCR.clsNsOCR.With(OCR =>
                {
                    int intLargura, intAltura, intValorLargura, intValorAltura, intValorbpp, intValordpi;
                    //Propriedades originais da imagem
                    intValordpi = OCR.Img_GetProperty(TNSOCR.intObjImagem, (int)TiposParametrosImagem.IMG_PROP_DPIX);
                    intValorbpp = OCR.Img_GetProperty(TNSOCR.intObjImagem, (int)TiposParametrosImagem.IMG_PROP_BPP);
                    intValorLargura = OCR.Img_GetProperty(TNSOCR.intObjImagem, (int)TiposParametrosImagem.IMG_PROP_WIDTH);
                    intValorAltura = OCR.Img_GetProperty(TNSOCR.intObjImagem, (int)TiposParametrosImagem.IMG_PROP_HEIGHT);
                    //Tamanho atual
                    OCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);

                    FORM.lblTamanho.Text = "";
                    if (intValordpi != 0)
                        FORM.lblTamanho.Text = $"DPI: {intValordpi}, ";
                    FORM.lblTamanho.Text += $"BPP: {intValorbpp}, ";
                    FORM.lblTamanho.Text += $"Tamanho: {intValorLargura}x{intValorAltura} => {intLargura}x{intAltura}";
                });
            });
        }

        /// <summary>
        /// Função que aciona o motor de reconhecimento do OCR
        /// </summary>
        /// <param name="bCopiaExata"> Define se o documento será uma cópia exata ou se baseará na configuração padrão </param>
        /// <returns> Texto encontrado na imagem </returns>
        public string Recognizar(bool bCopiaExata)
        {
            frmInicial.With(FORM =>
            {
                if (!ImagemCarregada())
                {
                    throw new Exception("Imagem não carregada!");
                }

                FORM.btnRecognizar.Enabled = false;
                //FORM.lblCarregamento.Visible = true;
                FORM.Refresh();


                int intResultadoErro;

                bool bMesmaThread = false; //Melhora a performance do OCR não bloqueando a GUI do usuário

                //Se a performance estiver ativa OCR
                if (bMesmaThread)
                    intResultadoErro = TNSOCR.clsNsOCR.Img_OCR(TNSOCR.intObjImagem, (int)TiposParametrossOCR.OCRSTEP_ZONING, (int)TiposParametrossOCR.OCRSTEP_LAST, (int)TiposFlagsOCR.OCRFLAG_NONE);
                else
                {
                    //Senão esperar os resultados
                    intResultadoErro = TNSOCR.clsNsOCR.Img_OCR(TNSOCR.intObjImagem, (int)TiposParametrossOCR.OCRSTEP_ZONING, (int)TiposParametrossOCR.OCRSTEP_LAST, (int)TiposFlagsOCR.OCRFLAG_THREAD);
                    if (intResultadoErro > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        throw new Exception($"Ocr_OcrImg {intResultadoErro}");
                    }
                    FORM.frmCarregamento.intModoCarregamento = 0;
                    FORM.frmCarregamento.frmInicial = FORM;
                    FORM.frmCarregamento.ShowDialog();
                    intResultadoErro = FORM.frmCarregamento.intResultadoErro;
                }

                //FORM.lblCarregamento.Visible = false;
                FORM.btnRecognizar.Enabled = true;

                if (intResultadoErro > (int)TiposErrosOCR.ERROR_FIRST)
                {
                    if (intResultadoErro == (int)TiposErrosOCR.ERROR_OPERATIONCANCELLED)
                        throw new Exception("Operação foi cancelada.");
                    else
                    {
                        throw new Exception($"Img_OCR {intResultadoErro}");
                    }
                }
            });
            AjustarEscalaDocumento(); //rearranjar imagem (a imagem binarizada pode mudar)
            return MostrarTexto(bCopiaExata);
        }

        /// <summary>
        /// Função que retorna o texto encontrado pelo motor de reconhecimento
        /// </summary>
        /// <param name="bCopiaExata"> Define se o documento será uma cópia exata ou se baseará na configuração padrão  </param>
        /// <returns> Texto encontrado na imagem </returns>
        public string MostrarTexto(bool bCopiaExata)
        {
            int intFlags = bCopiaExata ? (int)TiposFormatacaoCopia.FMT_EXACTCOPY : (int)TiposFormatacaoCopia.FMT_EDITCOPY;
            TNSOCR.clsNsOCR.Img_GetImgText(TNSOCR.intObjImagem, out string strTexto, intFlags);
            return strTexto;
        }

        /// <summary>
        /// Função que muda a página do documento
        /// </summary>
        /// <param name="strPagina"> número da página </param>
        public void MudarPagina(string strPagina)
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                if (intModoCarregamento == TiposModosCarregamentoOCR.memóriaBitman)//2
                {
                    intNumeroPaginas = Convert.ToInt32(strPagina);
                    AbrirDocumento(CaminhoArquivo);
                }
                else
                {
                    if (!ImagemCarregada()) return;
                    int intQtdePaginas = OCR.Img_GetPageCount(TNSOCR.intObjImagem);
                    int intValorPagina, intLargura, intAltura;
                    if (!int.TryParse(strPagina, out intValorPagina)) intValorPagina = 1;
                    intValorPagina--;
                    if (intValorPagina < 0) intValorPagina = 0;
                    if (intValorPagina >= intQtdePaginas) intValorPagina = intQtdePaginas - 1;
                    OCR.Img_SetPage(TNSOCR.intObjImagem, intValorPagina);

                    //Tamanho nativo
                    OCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);

                    //Aplica escala de imagem, binarização, deskew etc,
                    //Tudo exceto o próprio OCR
                    OCR.Img_OCR(TNSOCR.intObjImagem, /*TNSOCR.OCRSTEP_FIRST*/(int)TiposParametrossOCR.OCRSTEP_FIRST, /*TNSOCR.OCRSTEP_ZONING */(int)TiposParametrossOCR.OCRSTEP_ZONING - 1, (int)TiposFlagsOCR.OCRFLAG_NONE);

                    int res = OCR.Img_GetSize(TNSOCR.intObjImagem, out int intValorLargura, out int intValorAltura);
                    if (res > (int)TiposErrosOCR.ERROR_FIRST)
                    {
                        throw new Exception($"Img_OCR {res}");
                    }

                    MostrarParametrosDeImagem();

                    AjustarEscalaDocumento();
                }
            });
        }

        /// <summary>
        /// Função que detecta o movimento de passagem do mouse sobre o PictureBox
        /// </summary>
        public void MouseUp()
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                int intBlocoAtual, intLargura, intAltura, intBlocos;
                if (!TNSOCR.bDesenhar) return;
                TNSOCR.bDesenhar = false;

                if (!ImagemCarregada()) return;

                OCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);
                if (TNSOCR.Retangulo.Right >= intLargura) TNSOCR.Retangulo.Width = intLargura - TNSOCR.Retangulo.Left - 1;
                if (TNSOCR.Retangulo.Bottom >= intAltura) TNSOCR.Retangulo.Height = intAltura - TNSOCR.Retangulo.Top - 1;

                intLargura = TNSOCR.Retangulo.Right - TNSOCR.Retangulo.Left + 1;
                intAltura = TNSOCR.Retangulo.Bottom - TNSOCR.Retangulo.Top + 1;
                if ((intLargura < 8) || (intAltura < 8))
                {
                    MostrarImagem();
                    return;
                }
                intBlocos = OCR.Img_AddBlock(TNSOCR.intObjImagem, TNSOCR.Retangulo.Left, TNSOCR.Retangulo.Top, intLargura, intAltura, out intBlocoAtual);
                if (intBlocos > (int)TiposErrosOCR.ERROR_FIRST)
                {
                    throw new Exception($"Img_AddBlock {intBlocos}");
                }

                //detectar inversão de bloco de texto
                OCR.Blk_Inversion(intBlocoAtual, (int)TiposInversao.BLK_INVERSE_DETECT);

                //detectar rotação do bloco de texto
                OCR.Blk_Rotation(intBlocoAtual, (int)TiposRotacao.BLK_ROTATE_DETECT);

                MostrarImagem();
            });
        }

        /// <summary>
        /// Função que detecta o movimento do mouse sobre o PictureBox
        /// </summary>
        /// <param name="e"> Objeto atual </param>
        public void MouseMove(MouseEventArgs e)
        {
            GC.Collect();
            if (!TNSOCR.bDesenhar) return;

            if (!ImagemCarregada()) return;

            int intLargura, intAltura;
            TNSOCR.clsNsOCR.Img_GetSize(TNSOCR.intObjImagem, out intLargura, out intAltura);

            float dblEscala = EscalaAtualDocumento();
            TNSOCR.Retangulo.Width = (int)(1 / dblEscala * e.X) - TNSOCR.Retangulo.Left + 1;
            if (TNSOCR.Retangulo.Width < 0) TNSOCR.Retangulo.Width = 0;
            if (TNSOCR.Retangulo.Width > intLargura) TNSOCR.Retangulo.Width = intLargura;

            TNSOCR.Retangulo.Height = (int)(1 / dblEscala * e.Y) - TNSOCR.Retangulo.Top + 1;
            if (TNSOCR.Retangulo.Height < 0) TNSOCR.Retangulo.Height = 0;
            if (TNSOCR.Retangulo.Height > intAltura) TNSOCR.Retangulo.Height = intAltura;

            MostrarImagem();
        }

        /// <summary>
        /// Função que detecta a saída da passagem do mouse sobre o PictureBox
        /// </summary>
        /// <param name="e"> Objeto Atual </param>
        public void MouseDown(MouseEventArgs e)
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                if (!ImagemCarregada()) return;

                if (e.Button == MouseButtons.Right)
                {
                    Point point = new Point(e.X, e.Y);
                    float dblEscala = EscalaAtualDocumento();
                    int intQtdeBlocos = OCR.Img_GetBlockCnt(TNSOCR.intObjImagem);
                    int intBlocoMenor = -1;
                    int intTamanhoMinimo = -1;
                    int intIndice, intBloco, intHorizontal, intVertical, intLargura, intAltura, intTamanho;
                    Rectangle retangulo = new Rectangle();
                    //Passagem por cada bloco que constitue a imagem
                    for (intIndice = 0; intIndice < intQtdeBlocos; intIndice++)
                    {
                        OCR.Img_GetBlock(TNSOCR.intObjImagem, intIndice, out intBloco);
                        OCR.Blk_GetRect(intBloco, out intHorizontal, out intVertical, out intLargura, out intAltura);
                        retangulo.X = (int)(dblEscala * intHorizontal);
                        retangulo.Y = (int)(dblEscala * intVertical);
                        retangulo.Width = (int)(dblEscala * intLargura);
                        retangulo.Height = (int)(dblEscala * intAltura);

                        //Verifica se o retângulo atual está nos extremos dos blocos da imagem (Deve ter uma dimensão arredondada, sem valores quebrados)
                        if (retangulo.Contains(point))
                        {
                            // precisa encontrar o menor bloco porque os blocos podem se sobrepor
                            if (intLargura < intAltura) intTamanho = intLargura;
                            else intTamanho = intAltura;

                            if ((intTamanhoMinimo == -1) || (intTamanho < intTamanhoMinimo))
                            {
                                intTamanhoMinimo = intTamanho;
                                intBlocoMenor = intIndice;
                            }
                        }
                    }

                    if (intBlocoMenor == -1) return; // bloco não encontrado
                    TNSOCR.pmBlockTag = intBlocoMenor; // Pega o índice do bloco

                    point = frmInicial.PicBox.PointToScreen(point);
                    return;
                }

                int intLarguraImagem, intAlturaImagem;
                OCR.Img_GetSize(TNSOCR.intObjImagem, out intLarguraImagem, out intAlturaImagem);

                TNSOCR.bDesenhar = true;
                float dblEscalaAtual = EscalaAtualDocumento();
                TNSOCR.Retangulo.X = (int)(1 / dblEscalaAtual * e.X);
                if (TNSOCR.Retangulo.X < 0) TNSOCR.Retangulo.X = 0;
                if (TNSOCR.Retangulo.X > intLarguraImagem) TNSOCR.Retangulo.X = intLarguraImagem;
                TNSOCR.Retangulo.Y = (int)(1 / dblEscalaAtual * e.Y);
                if (TNSOCR.Retangulo.Y < 0) TNSOCR.Retangulo.Y = 0;
                if (TNSOCR.Retangulo.Y > intAlturaImagem) TNSOCR.Retangulo.Y = intAlturaImagem;
                TNSOCR.Retangulo.Width = 0;
                TNSOCR.Retangulo.Height = 0;

                MostrarImagem();
            });
        }

        /// <summary>
        /// Função que detecta e elimina os blocos delimitadores (Retângulos) da imagem
        /// do PicBox
        /// </summary>
        /// <param name="intTipos"> Tipo de bloco </param>
        public void DeletarBlocos(int intTipos)
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                switch (intTipos)
                {
                    case (int)TiposFormasDeletar.DeletarBloco:
                        int BlkObj;
                        OCR.Img_GetBlock(TNSOCR.intObjImagem, TNSOCR.pmBlockTag, out BlkObj);
                        OCR.Img_DeleteBlock(TNSOCR.intObjImagem, BlkObj);
                        break;
                    case (int)TiposFormasDeletar.DeletarTodosBlocos:
                        OCR.Img_DeleteAllBlocks(TNSOCR.intObjImagem);
                        break;
                    case (int)TiposFormasDeletar.DeletarDetectar:
                        OCR.Img_DeleteAllBlocks(TNSOCR.intObjImagem);
                        OCR.Img_OCR(TNSOCR.intObjImagem, (int)TiposParametrossOCR.OCRSTEP_ZONING, (int)TiposParametrossOCR.OCRSTEP_ZONING,/* TNSOCR.OCRFLAG_NONE*/(int)TiposFlagsOCR.OCRFLAG_NONE);
                        break;
                }
                MostrarImagem();
            });
        }

        /// <summary>
        /// Função de carregamento de imagem para documentos que não sejam PDF ou imagem (PNG,JPEG ou JPG)
        /// </summary>
        private void CarregamentoImagem()
        {
            string resultado = Metodos.Resultado(CaminhoArquivo, intNumeroPaginas, out intQuantidadePaginas);

            if (resultado == TNSOCR.ClipBoard)
            {
                Images = Clipboard.GetImage();
            }
            else
            {
                Images = MetodosExtensao.MetodosExtensao.ConverterTextoImagem(resultado, "Arial", 8, Color.White, Color.Black, 500, 500);
                frmInicial.PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// Função que retorna o número de ocorrências da palavra definida pelo usuário (Caso haja)
        /// </summary>
        /// <param name="strTexto"> Texto onde será buscado </param>
        /// <param name="strFiltro"> Palavra a ser buscada </param>
        /// <returns> Número de ocorrências </returns>
        public int Ocorrencias(string strTexto, string strFiltro)
        {
            //Separa o texto num array de palavras (trazendo os parâmetros maiusculos na chamada) e verifica o número de aparições deste
            return (string.IsNullOrEmpty(strFiltro)) ? 0 : strTexto.Split(' ').Where(x => x.Contains(strFiltro)).Count();
        }

        private void AjustarEscala()
        {
            TNSOCR.clsNsOCR.With(OCR =>
            {
                frmInicial.With(FORM =>
                {
                    if (FORM.cboEscala.Enabled)
                    {
                        if (FORM.cboEscala.SelectedIndex < 1) //Auto Escala
                        {
                            OCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/AutoScale", "1");
                            OCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/ScaleFactor", "1.0"); //Define escala padrão caso não seja automaticamente
                        }
                        else //Escala Fixa
                        {
                            OCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/AutoScale", "0");
                            string strValorEscala = FORM.cboEscala.Items[FORM.cboEscala.SelectedIndex].ToString();
                            OCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/ScaleFactor", strValorEscala);
                        }
                    }
                });
            });
        }
    }
}
