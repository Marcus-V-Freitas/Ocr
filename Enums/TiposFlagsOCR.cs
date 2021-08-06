using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para os parâmetros da função Img_OCR
    /// </summary>
    public enum TiposFlagsOCR
    {
        OCRFLAG_NONE = 0x00, //modo normal (multithread)
        OCRFLAG_THREAD = 0x01, //pega o resultado no modo de thread única
        OCRFLAG_GETRESULT = 0x02, //pega o resultado no modo multithread
        OCRFLAG_GETPROGRESS = 0x03, //Pegar o progresso
        OCRFLAG_CANCEL = 0x04 //Cancelar ocr
    }
}
