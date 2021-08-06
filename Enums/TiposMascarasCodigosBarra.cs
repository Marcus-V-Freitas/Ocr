using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para as configurações de códigos de barras "BarCode/TypesMask"
    /// </summary>
    public enum TiposMascarasCodigosBarra
    {
        BARCODE_TYPE_MASK_EAN8 = 0x01,
        BARCODE_TYPE_MASK_UPCE = 0x02,
        BARCODE_TYPE_MASK_ISBN10 = 0x04,
        BARCODE_TYPE_MASK_UPCA = 0x08,
        BARCODE_TYPE_MASK_EAN13 = 0x10,
        BARCODE_TYPE_MASK_ISBN13 = 0x20,
        BARCODE_TYPE_MASK_ZBAR_I25 = 0x40,
        BARCODE_TYPE_MASK_CODE39 = 0x80,
        BARCODE_TYPE_MASK_QRCODE = 0x100,
        BARCODE_TYPE_MASK_CODE128 = 0x200
    }
}
