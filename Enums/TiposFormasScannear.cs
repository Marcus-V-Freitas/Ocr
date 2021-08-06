using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para as funções Scan_ScanToImg e Scan_ScanToFile
    /// </summary>
    public enum TiposFormasScannear
    {
        SCAN_NOUI = 0x01,
        SCAN_SOURCEADF = 0x02,
        SCAN_SOURCEAUTO = 0x04,
        SCAN_DONTCLOSEDS = 0x08,
        SCAN_FILE_SEPARATE = 0x10
    }
}
