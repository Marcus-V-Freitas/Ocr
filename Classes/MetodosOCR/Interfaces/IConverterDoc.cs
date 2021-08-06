using System.Windows.Forms;

namespace Ocr.Classes.MetodosOCR.Interfaces
{
    public interface IConverterDoc
    {
        string CaminhoArquivo { get; set; }

        void AjustarEscalaDocumento();

        void AbrirDocumento(string strCaminhoArquivo);

        string Recognizar(bool b);

        string MostrarTexto(bool b);

        void MudarPagina(string strPagina);

        void MouseUp();

        void MouseMove(MouseEventArgs e);

        void MouseDown(MouseEventArgs e);

        void DeletarBlocos(int intTipos);

        int Ocorrencias(string strTexto, string strFiltro);
    }
}
