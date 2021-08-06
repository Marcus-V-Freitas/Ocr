using NSOCR;
using Ocr.Enums;
using Ocr.MetodosExtensao;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Ocr
{
    public partial class frmOpcoesFiltro : Form
    {
        public frmInicial frmInicial;
        private readonly FileVersionInfo file = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location); //Informações do documento

        public frmOpcoesFiltro()
        {
            InitializeComponent();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregarFormulario(object sender, EventArgs e)
        {
            try
            {
                string strValor;
                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/FindBarcodes", out strValor);
                chkCodigoBarras.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/Inversion", out strValor);
                chkImagemInversa.Checked = (strValor == "2");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/DetectInversion", out strValor);
                chkZonasInversas.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/SkewAngle", out strValor);
                chkDistorcao.Checked = (strValor == "360");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/AutoRotate", out strValor);
                chkRotacao.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/NoiseFilter", out strValor);
                chkFiltroRuido.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "PixLines/RemoveLines", out strValor);
                chkRemoverLinhas.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/GrayMode", out strValor);
                chkModoCinza.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/FastMode", out strValor);
                chkModoRapido.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Binarizer/BinTwice", out strValor);
                chkBinzarizacaoDupla.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "WordAlizer/CorrectMixed", out strValor);
                chkCharMistos.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Dictionaries/UseDictionary", out strValor);
                chkDicionario.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/OneColumn", out strValor);
                chkCombinarZonaHorizontal.Checked = (strValor == "1");

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/EnabledChars", out strValor);
                txtLetrasProcurar.Text = strValor;

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/DisabledChars", out strValor);
                txtLetrasExcluir.Text = strValor;

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Binarizer/SimpleThr", out strValor);
                txtLimiarBinarizacao.Text = strValor;

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "WordAlizer/TextQual", out strValor);
                txtQualidadeTexto.Text = strValor;

                TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/PdfDPI", out strValor);
                txtRenderizacaoPDF.Text = strValor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ok(object sender, EventArgs e)
        {
            try
            {
                string strValor;

                strValor = chkCodigoBarras.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/FindBarcodes", strValor);

                strValor = chkImagemInversa.Checked ? "2" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/Inversion", strValor);

                strValor = chkZonasInversas.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/DetectInversion", strValor);

                strValor = chkDistorcao.Checked ? "360" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/SkewAngle", strValor);

                strValor = chkRotacao.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/AutoRotate", strValor);

                strValor = chkFiltroRuido.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/NoiseFilter", strValor);

                strValor = chkRemoverLinhas.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "PixLines/RemoveLines", strValor);
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "PixLines/FindHorLines", strValor);
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "PixLines/FindVerLines", strValor);

                strValor = chkModoCinza.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/GrayMode", strValor);

                strValor = chkModoRapido.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/FastMode", strValor);

                strValor = chkBinzarizacaoDupla.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Binarizer/BinTwice", strValor);

                strValor = chkCharMistos.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "WordAlizer/CorrectMixed", strValor);

                strValor = chkDicionario.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Dictionaries/UseDictionary", strValor);

                strValor = chkCombinarZonaHorizontal.Checked ? "1" : "0";
                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Zoning/OneColumn", strValor);

                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/EnabledChars", txtLetrasProcurar.Text);

                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/DisabledChars", txtLetrasExcluir.Text);

                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Binarizer/SimpleThr", txtLimiarBinarizacao.Text);

                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "WordAlizer/TextQual", txtQualidadeTexto.Text);

                TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Main/PdfDPI", txtRenderizacaoPDF.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
