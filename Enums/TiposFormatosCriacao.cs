using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// ara a função Svr_Create
    /// </summary>
    public enum TiposFormatosCriacao
    {
        SVR_FORMAT_PDF = 0x01,
        SVR_FORMAT_RTF = 0x02,
        SVR_FORMAT_TXT_ASCII = 0x03,
        SVR_FORMAT_TXT_UNICODE = 0x04,
        SVR_FORMAT_XML = 0x05,
        SVR_FORMAT_PDFA = 0x06
    }
}
