namespace Ocr.Classes.MetodosOCR.Interfaces
{
    public interface IMetodosDocumentos
    {
        string Resultado(string CaminhoArquivo, int intPaginaAtual, out int intQuantidadePaginas);
    }
}
