using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para a função Svr_SetDocumentInfo
    /// </summary>
    public enum TiposPropPDF
    {
        INFO_PDF_AUTHOR = 0x01,
        INFO_PDF_CREATOR = 0x02,
        INFO_PDF_PRODUCER = 0x03,
        INFO_PDF_TITLE = 0x04,
        INFO_PDF_SUBJECT = 0x05,
        INFO_PDF_KEYWORDS = 0x06
    }
}
