using NSOCR;
using Ocr.Classes.MetodosOCR.Implementacoes;
using Ocr.Classes.MetodosOCR.Interfaces;
using Ocr.Enums;
using Ocr.MetodosExtensao;
using Sample.Classes.MetodosOCR.Implementacoes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ocr
{
    public partial class frmInicial : Form
    {
        private IConverterDoc doc;
        private readonly string strMsgNaoImplementado = "Método não implementado para esse documento"; //Mensagem para quando o usuário conseguir acessar um método sem carregar um documento (NotImplementedException)
        private readonly FileVersionInfo file = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location); //Informações do documento
        public readonly frmCarregamento frmCarregamento = new frmCarregamento();
        public readonly frmOpcoesFiltro frmOpcoes = new frmOpcoesFiltro();
        public readonly frmIdiomas frmIdiomas = new frmIdiomas();
        private static bool bIntegracaoAutomatica;

        public frmInicial()
        {
            InitializeComponent();
        }

        private void CarregarFormulario(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //Instânciar classe dentro do bloco try catch a fim de evitar erros quando a DLL não estiver devidamente registrada
                    TNSOCR.clsNsOCR = new NSOCRLib.NSOCRClass();
                    TNSOCR.clsNsOCR.Engine_SetLicenseKey(TNSOCR.strChaveAcesso); //Licença gratuita (Perpétua)
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show(strMsgNaoImplementado, file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Verique se está referenciando a DLL NSOCR.dll, ou se esta não está registrada com Regsvr32 {ex.TratamentoDeExcecoes()}", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                Text += $" [ V{file.ProductVersion} ] ";

                TNSOCR.bSemEvento = true;
                cboEscala.SelectedIndex = 0;
                TNSOCR.bSemEvento = false;

                // Habilitar a escolha da escala caso esteja tudo configurado
                cboEscala.Enabled = TNSOCR.IniciarMotorOCR(ref PicBox);
                PreencherComboTempo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FecharFormulario(object sender, FormClosedEventArgs e)
        {
            try
            {
                TNSOCR.FinalizarMotor();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IdentificarDocumento(string extensao)
        {
            //Verifica se o Documento está definido para o motor do OCR
            if (Enum.IsDefined(typeof(TiposDocumentos), extensao))
            {
                //Especifica a conversão para cada tipo de documento
                switch ((TiposDocumentos)Enum.Parse(typeof(TiposDocumentos), extensao))
                {
                    case TiposDocumentos.pdf:
                    case TiposDocumentos.jpeg:
                    case TiposDocumentos.jpg:
                    case TiposDocumentos.png:
                        doc = new ConversaoGeralOCR(this);
                        break;
                    case TiposDocumentos.docx:
                    case TiposDocumentos.doc:
                        doc = new ConversaoGeralOCR(this, new MetodosWord());
                        break;
                    case TiposDocumentos.xls:
                    case TiposDocumentos.xlsx:
                        doc = new ConversaoGeralOCR(this, new MetodosExcel());
                        break;
                    case TiposDocumentos.txt:
                        doc = new ConversaoGeralOCR(this, new MetodosTxt());
                        break;
                    case TiposDocumentos.clipBoard:
                        doc = new ConversaoGeralOCR(this, new MetodosClipBoard());
                        break;
                }
                doc.AbrirDocumento(opdImagemUpload.FileName);
            }
            else
            {
                doc = null;
                MessageBox.Show("Escolha um formato válido!", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirDocumento(object sender, EventArgs e)
        {
            try
            {
                if (opdImagemUpload.ShowDialog() != DialogResult.OK) return;

                if (File.Exists(opdImagemUpload.FileName)) //Verifica existência do arquivo
                {
                    IdentificarDocumento(Path.GetExtension(opdImagemUpload.FileName).Replace(".", "")); //Pega a extensão do documento
                }
                else
                {
                    doc = null;
                    MessageBox.Show("Escolha um arquivo existente!", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtOcorrencias.Text = "0";
            }
        }

        private void MudarPagina(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.MudarPagina(txtNumeroPagina.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void MouseDOWN(object sender, MouseEventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.MouseDown(e));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void MouseUP(object sender, MouseEventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.MouseUp());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void MovimentoMouse(object sender, MouseEventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.MouseMove(e));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void Recognizar(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => txtTextoArquivo.Text = doc.Recognizar(chkCopiaExata.Checked));
                PermitirAcao(() => txtOcorrencias.Text = doc.Ocorrencias(txtTextoArquivo.Text.ToUpper(), txtProcurar.Text.ToUpper()).ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void SelecionarEscala(object sender, EventArgs e)
        {
            try
            {
                if (TNSOCR.bSemEvento) return;
                btnRecognizar.Enabled = false;
                IdentificarDocumento(Path.GetExtension(opdImagemUpload.FileName).Replace(".", "")); //Pega a extensão do documento
                //AbrirDocumento(null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        private void SelecionarCopiaExata(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => txtTextoArquivo.Text = doc.MostrarTexto(chkCopiaExata.Checked));
                PermitirAcao(() => txtOcorrencias.Text = doc.Ocorrencias(txtTextoArquivo.Text.ToUpper(), txtProcurar.Text.ToUpper()).ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        private void RedimensionamentoPainel(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.AjustarEscalaDocumento());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void Binarizacao(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.AjustarEscalaDocumento()); //rearranjar documento
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void LimparBlocos(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.DeletarBlocos(1));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void DetectarDeteletarBlocos(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.DeletarBlocos(2));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void SelecionarIdioma(object sender, EventArgs e)
        {
            try
            {
                frmIdiomas.frmInicial = this;
                frmIdiomas.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void VisualizarCharacteres(object sender, EventArgs e)
        {
            try
            {
                PermitirAcao(() => doc.AjustarEscalaDocumento()); //rearranjar documento
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        private void SelecionarOpcoesAdicionais(object sender, EventArgs e)
        {
            try
            {
                frmOpcoes.frmInicial = this;
                frmOpcoes.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

        }

        /// <summary>
        /// Método que verifica se já uma implementação (se há um arquivo carregado) a 
        /// fim de utilizar o método
        /// </summary>
        /// <param name="action"> método a ser chamado </param>
        private void PermitirAcao(Action action)
        {
            if (doc != null)
            {
                action.Invoke();
            }
        }

        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            try
            {
                IdentificarDocumento("clipBoard");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIntegracoes_Click(object sender, EventArgs e)
        {
            timerIntegracao.Enabled = !bIntegracaoAutomatica;
            bIntegracaoAutomatica = !bIntegracaoAutomatica;
            btnClipBoard.Enabled = !bIntegracaoAutomatica;
            btnAbrirArquivo.Enabled = !bIntegracaoAutomatica;
            txtPastaIntegracao.Enabled = bIntegracaoAutomatica;
            cboTempoIntegracao.Enabled = bIntegracaoAutomatica;
            btnIntegracoes.Text = (bIntegracaoAutomatica) ? "Desativar Integrações" : "Ativar Integrações";
        }

        private void Buscar(string strPalavra)
        {
            try
            {
                //Colore todo o textBox com a cor padrão (remover filtros anteriores)
                txtTextoArquivo.Select(0, txtTextoArquivo.TextLength);
                txtTextoArquivo.SelectionColor = Color.Black;

                string palavra = chkCaseSensitive.Checked ? strPalavra.ToUpper() : strPalavra;
                string arquivo = chkCaseSensitive.Checked ? txtTextoArquivo.Text.ToUpper() : txtTextoArquivo.Text;

                //Verificar número de ocorrências
                PermitirAcao(() => txtOcorrencias.Text = doc.Ocorrencias(arquivo, palavra).ToString());

                //Pintar de vermelho todo o texto que corresponder ao procurado.
                if (arquivo.Contains(palavra))
                {
                    var matchString = Regex.Escape(palavra);
                    foreach (Match match in Regex.Matches(arquivo, matchString))
                    {
                        txtTextoArquivo.Select(match.Index, palavra.Length);
                        txtTextoArquivo.SelectionColor = Color.Red;
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtProcurar.Text);
        }

        private void PreencherComboTempo()
        {
            cboTempoIntegracao.Items.Add(new { intValor = 10000, strValor = "10 Segundos" });
            cboTempoIntegracao.Items.Add(new { intValor = 60000, strValor = "1 Minuto" });
            cboTempoIntegracao.Items.Add(new { intValor = 600000, strValor = "10 Minutos" });
            cboTempoIntegracao.Items.Add(new { intValor = 3600000, strValor = "1 hora" });
            cboTempoIntegracao.Items.Add(new { intValor = 86400000, strValor = "1 dia" });
            cboTempoIntegracao.SelectedIndex = cboTempoIntegracao.Items.Count - 1;
        }

        private void cboTempoIntegracao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                timerIntegracao.Interval = Convert.ToInt32((cboTempoIntegracao.SelectedItem as dynamic).intValor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerIntegracao_Tick(object sender, EventArgs e)
        {
            timerIntegracao.Stop();
            try
            {
                if (Directory.Exists(txtPastaIntegracao.Text))
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "WriteLines.txt")))
                    {
                        foreach (var item in Directory.GetFiles(txtPastaIntegracao.Text))
                        {
                            opdImagemUpload.FileName = item;
                            IdentificarDocumento(Path.GetExtension(item).Replace(".", "")); //Pega a extensão do documento
                            PermitirAcao(() => txtTextoArquivo.Text = doc.Recognizar(chkCopiaExata.Checked));
                            outputFile.WriteLine(ExtrairPalavra("ADEGA ALENTEJANA", 20));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                timerIntegracao.Start();
            }
        }


        private string ExtrairPalavra(string strTexto, int Tamanho)
        {
            try
            {
                if (txtTextoArquivo.Text.ToUpper().Contains(strTexto.ToUpper()))
                {
                    int Start = txtTextoArquivo.Text.IndexOf(strTexto) + strTexto.Length;
                    return txtTextoArquivo.Text.Substring(Start, Tamanho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return string.Empty;
        }
    }
}
