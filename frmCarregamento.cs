using NSOCR;
using Ocr.Enums;
using Ocr.Enums;
using Ocr.MetodosExtensao;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Ocr
{
    public partial class frmCarregamento : Form
    {
        public frmCarregamento()
        {
            InitializeComponent();
        }

        public frmInicial frmInicial;
        public int intResultadoErro;
        public int intModoCarregamento;
        private readonly FileVersionInfo file = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        private bool ChecarConclusao()
        {
            if (intModoCarregamento == 0)
                intResultadoErro = TNSOCR.clsNsOCR.Img_OCR(TNSOCR.intObjImagem, 0, 0, (int)TiposFlagsOCR.OCRFLAG_GETRESULT);
            else
                intResultadoErro = TNSOCR.clsNsOCR.Ocr_ProcessPages(TNSOCR.intObjImagem, 0, 0, 0, 0, (int)TiposFlagsOCR.OCRFLAG_GETRESULT);
            return intResultadoErro != (int)TiposErrosOCR.ERROR_PENDING;
        }

        private void CarregarFormulario(object sender, EventArgs e)
        {
            timer.Enabled = true;
            progressBar.Value = 0;
        }

        private void Timer(object sender, EventArgs e)
        {
            try
            {
                if (ChecarConclusao())
                    Close();
                int intPercCarregamento;

                if (intModoCarregamento == (int)TiposModosCarregamentoOCR.arquivo)
                    intPercCarregamento = TNSOCR.clsNsOCR.Img_OCR(TNSOCR.intObjImagem, 0, 0, (int)TiposFlagsOCR.OCRFLAG_GETPROGRESS);
                else
                    intPercCarregamento = TNSOCR.clsNsOCR.Ocr_ProcessPages(TNSOCR.intObjImagem, 0, 0, 0, 0, (int)TiposFlagsOCR.OCRFLAG_GETPROGRESS);

                if (intPercCarregamento < (int)TiposErrosOCR.ERROR_FIRST)
                    if (progressBar.Value != intPercCarregamento)
                        progressBar.Value = intPercCarregamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar(object sender, EventArgs e)
        {
            try
            {
                //Cancelar o trabalho
                if (intModoCarregamento == (int)TiposModosCarregamentoOCR.arquivo)
                    TNSOCR.clsNsOCR.Img_OCR(TNSOCR.intObjImagem, 0, 0, (int)TiposFlagsOCR.OCRFLAG_CANCEL);
                else
                    TNSOCR.clsNsOCR.Ocr_ProcessPages(TNSOCR.intObjImagem, 0, 0, 0, 0, (int)TiposFlagsOCR.OCRFLAG_CANCEL);

                // precisamos aguardar o resultado de qualquer maneira, já que a solicitação OCRFLAG_CANCEL retorna imediatamente, o trabalho ainda não foi interrompido
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close(); //Essa Função espera pelo resultado
            }
        }

        private void FecharFormulario(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                while (!ChecarConclusao()) //Verifica se a recognição foi finalizada
                    System.Threading.Thread.Sleep(10); //Aguarda enquanto outra thread continua
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
