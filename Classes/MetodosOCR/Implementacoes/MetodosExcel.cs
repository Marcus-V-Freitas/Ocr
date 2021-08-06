using Microsoft.Office.Interop.Excel;
using Ocr.Classes.MetodosOCR.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ocr.Classes.MetodosOCR.Implementacoes
{
    public class MetodosExcel : IMetodosDocumentos
    {
        public string Resultado(string CaminhoArquivo, int intPaginaAtual, out int intQuantidadePaginas)
        {
            StringBuilder sbs = new StringBuilder();
            Application app = new Application(); //Define uma aplicação Excel
            Workbook xlWorkbook = app.Workbooks.Open(CaminhoArquivo, ReadOnly: true); //Abre o documento em modo somente leitura (Não afetar o documento em casos de erros extremos)
            _Worksheet xlWorksheet = xlWorkbook.Sheets[intPaginaAtual]; //Pega a planilha especifica da pasta de trabalho
            intQuantidadePaginas = 1;
            try
            {
                Range rng = xlWorksheet.UsedRange;//Pega todas as células da planilha atual
                //Adiciona ao StringBuilder o conteúdo de cada linha
                foreach (Range c in rng.Rows.Cells)
                {
                    sbs.AppendLine(Convert.ToString(c.Value));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                xlWorkbook.Close(); //Fechar o documento
                //Finalizar aplicação
                Marshal.FinalReleaseComObject(xlWorkbook);
                Marshal.FinalReleaseComObject(app);
            }
            return sbs.ToString();
        }
    }
}
