using Ocr.Classes.MetodosOCR.Interfaces;
using System;
using System.IO;
using System.Text;

namespace Ocr.Classes.MetodosOCR.Implementacoes
{
    public class MetodosTxt : IMetodosDocumentos
    {
        public string Resultado(string CaminhoArquivo, int intPaginaAtual, out int intQuantidadePaginas)
        {
            try
            {
                intQuantidadePaginas = 1;
                var fileStream = new FileStream(CaminhoArquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //Abre o arquivo para somente leitura e permite que leitura e escrita possam ser feitas enquanto isso
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)) //Abre fluxo de memória e lê o documento na decodificação padrão (UTF8)
                {
                    return streamReader.ReadToEnd(); //Ler todo o contêudo
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
