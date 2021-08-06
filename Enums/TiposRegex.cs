using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para a função Blk_SetWordRegEx
    /// </summary>
    public enum TiposRegex
    {
        REGEX_SET = 0x00,
        REGEX_CLEAR = 0x01,
        REGEX_CLEAR_ALL = 0x02,
        REGEX_DISABLE_DICT = 0x04,
        REGEX_CHECK = 0x08,
    }
}
