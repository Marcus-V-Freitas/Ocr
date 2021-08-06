using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para a função Img_SaveToFile
    /// </summary>
    public enum TiposSalvarArquivo
    {
        IMG_FORMAT_BMP = 0,
        IMG_FORMAT_JPEG = 2,
        IMG_FORMAT_PNG = 13,
        IMG_FORMAT_TIFF = 18,
        IMG_FORMAT_FLAG_BINARIZED = 0x100,
    }
}
