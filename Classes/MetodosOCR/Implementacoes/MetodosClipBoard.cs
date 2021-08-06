using Ocr.Classes.MetodosOCR.Interfaces;

namespace Sample.Classes.MetodosOCR.Implementacoes
{
    public class MetodosClipBoard : IMetodosDocumentos
    {
        public string Resultado(string CaminhoArquivo, int intPaginaAtual, out int intQuantidadePaginas)
        {
            intQuantidadePaginas = 1;
            return "ClipBoard";
        }
    }
}
