using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para a função Blk_Rotation
    /// </summary>
    public enum TiposRotacao
    {
        BLK_ROTATE_GET = -1,
        BLK_ROTATE_NONE = 0x00,
        BLK_ROTATE_90 = 0x01,
        BLK_ROTATE_180 = 0x02,
        BLK_ROTATE_270 = 0x03,
        BLK_ROTATE_ANGLE = 0x100000,
        BLK_ROTATE_DETECT = 0x100
    }
}
