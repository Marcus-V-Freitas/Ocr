using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    ///Para a função Blk_GetBarcodeType
    /// </summary>
    public enum TiposCodigoBarra
    {
        BARCODE_TYPE_EAN8 = 0x01,
        BARCODE_TYPE_UPCE = 0x02,
        BARCODE_TYPE_ISBN10 = 0x03,
        BARCODE_TYPE_UPCA = 0x04,
        BARCODE_TYPE_EAN13 = 0x05,
        BARCODE_TYPE_ISBN13 = 0x06,
        BARCODE_TYPE_ZBAR_I25 = 0x07,
        BARCODE_TYPE_CODE39 = 0x08,
        BARCODE_TYPE_QRCODE = 0x09,
        BARCODE_TYPE_CODE128 = 0x0A
    }
}
