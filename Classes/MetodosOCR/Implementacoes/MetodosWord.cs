using Microsoft.Office.Interop.Word;
using Ocr.Classes.MetodosOCR.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ocr.Classes.MetodosOCR.Implementacoes
{
    public class MetodosWord : IMetodosDocumentos
    {
        public string Resultado(string CaminhoArquivo, int intPaginaAtual, out int intQuantidadePaginas)
        {
            StringBuilder sb = new StringBuilder();
            var app = new Application(); //Define uma aplicação Word
            var doc = app.Documents.Open(CaminhoArquivo, ReadOnly: true); //Abre o documento em modo somente leitura (Não afetar o documento em casos de erros extremos)
            try
            {
                //Pega o número total de páginas
                intQuantidadePaginas = doc.Range().GoTo(WdGoToItem.wdGoToPage, WdGoToDirection.wdGoToLast).get_Information(WdInformation.wdActiveEndPageNumber); ;
                foreach (Paragraph paragrafo in doc.Paragraphs)
                {
                    int intPaginaDoc = (int)paragrafo.Range.Information[WdInformation.wdActiveEndAdjustedPageNumber];
                    if (intPaginaDoc == intPaginaAtual)
                    {
                        Range rng = paragrafo.Range; //Pega o parágrafo inteiro
                        int intNumeroLinhas = rng.ComputeStatistics(WdStatistic.wdStatisticLines);
                        string[] strLinha = new string[intNumeroLinhas]; //Conteúdo da Linha

                        rng.Collapse(WdCollapseDirection.wdCollapseStart); //Seleciona desde o começo da linha
                        rng.Select(); //Inicia a seleção

                        //Definição de como será a movimentação até o fim da linha
                        for (int i = 0; i < intNumeroLinhas; i++)
                        {
                            app.Selection.MoveEnd(Unit: WdUnits.wdLine, Count: 1);
                            strLinha[i] = app.Selection.Text;
                            app.Selection.Collapse(WdCollapseDirection.wdCollapseEnd);
                        }
                        //Adiciona ao StringBuilder o conteúdo de cada linha
                        for (int i = 0; i < strLinha.Length; i++)
                        {
                            sb.AppendLine(strLinha[i]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                doc.Close(); //Fechar o documento
                             //Finalizar aplicação
                Marshal.FinalReleaseComObject(doc);
                Marshal.FinalReleaseComObject(app);
            }
            return sb.ToString();
        }
    }

}
