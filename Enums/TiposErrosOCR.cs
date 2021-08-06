﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Tipos de erros lançados pelo OCR
    /// </summary>
    public enum TiposErrosOCR
    {
        ERROR_FIRST = 0x70000000,
        ERROR_FILENOTFOUND = 0x70000001,
        ERROR_LOADFILE = 0x70000002,
        ERROR_SAVEFILE = 0x70000003,
        ERROR_MISSEDIMGLOADER = 0x70000004,
        ERROR_OPTIONNOTFOUND = 0x70000005,
        ERROR_NOBLOCKS = 0x70000006,
        ERROR_BLOCKNOTFOUND = 0x70000007,
        ERROR_INVALIDINDEX = 0x70000008,
        ERROR_INVALIDPARAMETER = 0x70000009,
        ERROR_FAILED = 0x7000000A,
        ERROR_INVALIDBLOCKTYPE = 0x7000000B,
        ERROR_EMPTYTEXT = 0x7000000D,
        ERROR_LOADINGDICTIONARY = 0x7000000E,
        ERROR_LOADCHARBASE = 0x7000000F,
        ERROR_NOMEMORY = 0x70000010,
        ERROR_CANNOTLOADGS = 0x70000011,
        ERROR_CANNOTPROCESSPDF = 0x70000012,
        ERROR_NOIMAGE = 0x70000013,
        ERROR_MISSEDSTEP = 0x70000014,
        ERROR_OUTOFIMAGE = 0x70000015,
        ERROR_EXCEPTION = 0x70000016,
        ERROR_NOTALLOWED = 0x70000017,
        ERROR_NODEFAULTDEVICE = 0x70000018,
        ERROR_NOTAPPLICABLE = 0x70000019,
        ERROR_MISSEDBARCODEDLL = 0x7000001A,
        ERROR_PENDING = 0x7000001B,
        ERROR_OPERATIONCANCELLED = 0x7000001C,
        ERROR_TOOMANYLANGUAGES = 0x7000001D,
        ERROR_OPERATIONTIMEOUT = 0x7000001E,
        ERROR_LOAD_ASIAN_MODULE = 0x7000001F,
        ERROR_LOAD_ASIAN_LANG = 0x70000020,

        ERROR_INVALIDOBJECT = 0x70010000,
        ERROR_TOOMANYOBJECTS = 0x70010001,
        ERROR_DLLNOTLOADED = 0x70010002,
        ERROR_DEMO = 0x70010003,
    }
}