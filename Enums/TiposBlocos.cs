using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Tipos de bloco identificavéis pelo OCR
    /// </summary>
    public enum TiposBlocos
    {
        BT_DEFAULT = 0,
        BT_OCRTEXT = 1, //texto
        BT_ICRDIGIT = 2, //dígitos manuscritos
        BT_CLEAR = 3,
        BT_PICTURE = 4,
        BT_ZONING = 5,
        BT_OCRDIGIT = 6, //dígitos impressos à máquina
        BT_BARCODE = 7,
        BT_TABLE = 8,
        BT_MRZ = 9
    }
}
