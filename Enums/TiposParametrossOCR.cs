using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para a função Img_OCR
    /// </summary>
    public enum TiposParametrossOCR
    {
        OCRSTEP_FIRST = 0x00, //Primeiro passo
        OCRSTEP_PREFILTERS = 0x10, //Filtros para utilizar antes daa binarização: escala, inversão, rotação, etc.
        OCRSTEP_BINARIZE = 0x20, //Binarização
        OCRSTEP_POSTFILTERS = 0x50, //Filtro para limpeza (garbage collector)
        OCRSTEP_REMOVELINES = 0x60, //Encontra e remove as linhas
        OCRSTEP_ZONING = 0x70, //Analisa o layout da página
        OCRSTEP_OCR = 0x80, //Próprio ocr
        OCRSTEP_LAST = 0xFF //último passo
    }
}
