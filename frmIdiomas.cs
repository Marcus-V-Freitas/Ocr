using NSOCR;
using Ocr.Enums;
using Ocr.MetodosExtensao;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Ocr
{
    public partial class frmIdiomas : Form
    {
        public frmInicial frmInicial;
        private readonly FileVersionInfo file = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        private readonly Dictionary<string, string> dicIdiomasPrincipais = new Dictionary<string, string>()
        {
            { "Búlgaro", "Bulgarian"},
            { "Catalão","Catalan" },
            { "Croata","Croatian" },
            { "Tcheco","Czech" },
            { "Dinamarquês","Danish"},
            { "Holandês","Dutch"},
            { "Inglês","English" },
            { "Estoniano","Estonian" },
            { "Finlandês","Finnish" },
            { "Francês","French" },
            { "Alemão","German" },
            {"Húngaro","Hungarian" },
            {"Indonésio","Indonesian" },
            {"Italiano","Italian" },
            {"Letão","Latvian" },
            {"Lituano","Lithuanian" },
            {"Norueguês","Norwegian" },
            {"Polonês","Polish" },
            {"Português","Portuguese" },
            {"Romena","Romanian" },
            {"Russo","Russian" },
            {"Eslovaco","Slovak" },
            {"Esloveno","Slovenian" },
            {"Espanhol","Spanish" },
            {"Sueco","Swedish" },
            {"Turco","Turkish" }
        };

        private readonly Dictionary<string, string> dicIdiomasAsiaticos = new Dictionary<string, string>()
        {
            { "Árabe","Arabic" },
            {"Chinês Simplificado","Chinese_Simplified" },
            {"Chinês tradicional","Chinese_Traditional" },
            {"Japonês","Japanese" },
            {"Coreano","Korean" }
        };


        public frmIdiomas()
        {
            InitializeComponent();
        }

        public void CarregarIdiomas()
        {
            try
            {
                int intIndice;
                string strVal;
                //Define o idioma padrão do OCR com base no parâmetro "1" no arquivo de configuração

                //Percorre verificando no combo de opções principais
                for (intIndice = 0; intIndice < cboIdiomas.Items.Count; intIndice++)
                {
                    if (TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Languages/" + dicIdiomasPrincipais[cboIdiomas.Items[intIndice].ToString()], out strVal) < (int)TiposErrosOCR.ERROR_FIRST)
                        cboIdiomas.SetItemChecked(intIndice, strVal == "1");
                    else
                        cboIdiomas.SetItemChecked(intIndice, false);
                }

                //Percorre verificando no combo de opções asiáticas
                for (intIndice = 0; intIndice < cboIdiomasAsiaticos.Items.Count; intIndice++)
                {
                    if (TNSOCR.clsNsOCR.Cfg_GetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Languages/" + dicIdiomasAsiaticos[cboIdiomasAsiaticos.Items[intIndice].ToString()], out strVal) < (int)TiposErrosOCR.ERROR_FIRST)
                        cboIdiomasAsiaticos.SetItemChecked(intIndice, strVal == "1");
                    else
                        cboIdiomasAsiaticos.SetItemChecked(intIndice, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool AplicarIdiomas()
        {
            try
            {
                //Função que verifica se os critérios para escolha dos combos podem ser aplicados ou não
                //no motor de busca do OCR
                int intIndice;
                bool bOpcaoPrincipal = false;

                //Verifica opções selecionadas no combo principal
                for (intIndice = 0; intIndice < cboIdiomas.Items.Count; intIndice++)
                    if (cboIdiomas.GetItemChecked(intIndice))
                    {
                        bOpcaoPrincipal = true;
                        break;
                    }

                //Verifica opções selecionadas no combo asiático
                int bOpcaoAsiatico = 0;
                for (intIndice = 0; intIndice < cboIdiomasAsiaticos.Items.Count; intIndice++)
                    if (cboIdiomasAsiaticos.GetItemChecked(intIndice))
                        bOpcaoAsiatico++;

                //Se nenhuma opção em ambos for escolhida
                if (!bOpcaoPrincipal && (bOpcaoAsiatico == 0))
                {
                    MessageBox.Show("Por favor selecione pelos menos um idioma para a recognição!", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //Se for selecionada pelo menos uma opção principal e uma asiática
                if (bOpcaoPrincipal && (bOpcaoAsiatico > 0))
                {
                    MessageBox.Show("Não é suportado usar dois tipos de idiomas ao mesmo tempo!", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //Se for selecionada mais de uma opção asiática
                if (bOpcaoAsiatico > 1)
                {
                    MessageBox.Show("Não é suportado usar mais de 2 idiomas do módulo asiático ao mesmo tempo!", file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //Seta as opções de busca do OCR para os idiomas definidos
                for (intIndice = 0; intIndice < cboIdiomas.Items.Count; intIndice++)
                    TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Languages/" + dicIdiomasPrincipais[cboIdiomas.Items[intIndice].ToString()], cboIdiomas.GetItemChecked(intIndice) ? "1" : "0");
                for (intIndice = 0; intIndice < cboIdiomasAsiaticos.Items.Count; intIndice++)
                    TNSOCR.clsNsOCR.Cfg_SetOption(TNSOCR.intObjCfg, (int)TiposBlocos.BT_DEFAULT, "Languages/" + dicIdiomasAsiaticos[cboIdiomasAsiaticos.Items[intIndice].ToString()], cboIdiomasAsiaticos.GetItemChecked(intIndice) ? "1" : "0");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CarregamentoFormulario(object sender, EventArgs e)
        {
            IniciarCombos();
            CarregarIdiomas();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void Ok(object sender, EventArgs e)
        {
            if (AplicarIdiomas())
                Close();
        }

        private void IniciarCombos()
        {
            PreencherDicionario(dicIdiomasPrincipais, cboIdiomas);
            PreencherDicionario(dicIdiomasAsiaticos, cboIdiomasAsiaticos);
        }

        private void PreencherDicionario(Dictionary<string, string> dicAtual, CheckedListBox check)
        {
            try
            {
                if (check.Items.Count == 0)
                {
                    foreach (var item in dicAtual.Keys)
                    {
                        check.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TratamentoDeExcecoes(), file.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
