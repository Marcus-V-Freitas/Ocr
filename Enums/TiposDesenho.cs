using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para as funções Img_DrawToDC e Img_GetBmpData
    /// </summary>
    public enum TiposDesenho
    {
        DRAW_NORMAL = 0x00,
        DRAW_BINARY = 0x01,
        DRAW_GETBPP = 0x100
    }
}
