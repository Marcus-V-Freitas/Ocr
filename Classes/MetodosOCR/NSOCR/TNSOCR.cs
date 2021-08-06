using NSOCRLib;
using Ocr.Enums;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NSOCR
{
    public static class TNSOCR
    {
        public const string strChaveAcesso = "AB2A4DD5FF2A";
        public const string ClipBoard = "ClipBoard";
        public static NSOCRClass clsNsOCR;
        public static int intObjImagem = 0;
        public static int intObjCfg = 0;
        public static int intObjSvr = 0;
        public static Image ImagemBMP;
        public static Graphics Graficos;
        public static int OcrObj = 0;
        public static int pmBlockTag = -1;
        public static bool bDesenhar = false;
        public static Rectangle Retangulo;
        public static int intObjScan = 0;
        public static bool bSemEvento;
        public static bool bIniciado = false;
        private const string LIBNAME = "..\\..\\..\\..\\Bin\\NSOCR.dll"; //Para a referenciar a "NSOCR.dll" na arquitetura x86 (32 bits)

        #region "Métodos Importados da DLL NSOCR"
        [DllImport(LIBNAME)]
        public static extern int Engine_Initialize();

        [DllImport(LIBNAME)]
        public static extern int Engine_InitializeAdvanced(out int CfgObj, out int OcrObj, out int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Engine_Uninitialize();

        [DllImport(LIBNAME)]
        public static extern int Engine_SetDataDirectory([MarshalAs(UnmanagedType.LPWStr)] string DirectoryPath);

        [DllImport(LIBNAME)]
        public static extern int Engine_GetVersion([MarshalAs(UnmanagedType.LPWStr)] StringBuilder OptionValue);

        [DllImport(LIBNAME)]
        public static extern int Engine_SetLicenseKey([MarshalAs(UnmanagedType.LPWStr)] string LicenseKey);

        [DllImport(LIBNAME)]
        public static extern int Cfg_Create(out int CfgObj);

        [DllImport(LIBNAME)]
        public static extern int Cfg_Destroy(int CfgObj);

        [DllImport(LIBNAME)]
        public static extern int Cfg_LoadOptions(int CfgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Cfg_SaveOptions(int CfgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Cfg_LoadOptionsFromString(int CfgObj, [MarshalAs(UnmanagedType.LPWStr)] string XMLString);

        [DllImport(LIBNAME)]
        public static extern int Cfg_SaveOptionsToString(int CfgObj, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder XMLString, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Cfg_GetOption(int CfgObj, int BlockType, [MarshalAs(UnmanagedType.LPWStr)] string OptionPath, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder OptionValue, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Cfg_SetOption(int CfgObj, int BlockType, [MarshalAs(UnmanagedType.LPWStr)] string OptionPath, [MarshalAs(UnmanagedType.LPWStr)] string OptionValue);

        [DllImport(LIBNAME)]
        public static extern int Cfg_DeleteOption(int CfgObj, int BlockType, [MarshalAs(UnmanagedType.LPWStr)] string OptionPath);

        [DllImport(LIBNAME)]
        public static extern int Ocr_Create(int CfgObj, out int OcrObj);

        [DllImport(LIBNAME)]
        public static extern int Ocr_Destroy(int OcrObj);

        [DllImport(LIBNAME)]
        public static extern int Ocr_Destroy(int ImgObj, int SvrObj, int PageIndexStart, int PageIndexEnd, int OcrObjCnt, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Ocr_ProcessPages(int ImgObj, int SvrObj, int PageIndexStart, int PageIndexEnd, int OcrObjCnt, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_Create(int OcrObj, out int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_Destroy(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_LoadFile(int ImgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Img_LoadFromMemory(int ImgObj, IntPtr Bytes, int DataSize);

        [DllImport(LIBNAME)]
        public static extern int Img_LoadBmpData(int ImgObj, IntPtr Bytes, int Width, int Height, int Flags, int Stride);

        [DllImport(LIBNAME)]
        public static extern int Img_Unload(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetPageCount(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_SetPage(int ImgObj, int PageIndex);

        [DllImport(LIBNAME)]
        public static extern int Img_GetSize(int ImgObj, out int Width, out int Height);

        [DllImport(LIBNAME)]
        public static extern int Img_DrawToDC(int ImgObj, int HandleDC, int X, int Y, ref int Width, ref int Height, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_DeleteAllBlocks(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_AddBlock(int ImgObj, int Xpos, int Ypos, int Width, int Height, out int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Img_DeleteBlock(int ImgObj, int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetBlockCnt(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetBlock(int ImgObj, int BlockIndex, out int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetImgText(int ImgObj, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_GetBmpData(int ImgObj, IntPtr Bits, ref int Width, ref int Height, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_OCR(int ImgObj, int FirstStep, int LastStep, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_SaveBlocks(int ImgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Img_LoadBlocks(int ImgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Img_GetSkewAngle(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetPixLineCnt(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_GetPixLine(int ImgObj, int LineInd, out int X1pos, out int Y1pos, out int X2pos, out int Y2pos, out int Width);

        [DllImport(LIBNAME)]
        public static extern int Img_GetScaleFactor(int ImgObj);

        [DllImport(LIBNAME)]
        public static extern int Img_CalcPointPosition(int ImgObj, ref int Xpos, ref int Ypos, int Mode);

        [DllImport(LIBNAME)]
        public static extern int Img_CopyCurrentPage(int ImgObjSrc, int ImgObjDst, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_GetProperty(int ImgObj, int PropertyID);

        [DllImport(LIBNAME)]
        public static extern int Img_SaveToFile(int ImgObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName, int Format, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Img_SaveToMemory(int ImgObj, IntPtr Bytes, int BufferSize, int Format, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetType(int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Blk_SetType(int BlkObj, int BlockType);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetRect(int BlkObj, out int Xpos, out int Ypos, out int Width, out int Height);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetText(int BlkObj, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetLineCnt(int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetLineText(int BlkObj, int LineIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordCnt(int BlkObj, int LineIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordText(int BlkObj, int LineIndex, int WordIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Blk_SetWordText(int BlkObj, int LineIndex, int WordIndex, [MarshalAs(UnmanagedType.LPWStr)] string TextStr);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetCharCnt(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetCharRect(int BlkObj, int LineIndex, int WordIndex, int CharIndex, out int Xpos, out int Ypos, out int Width, out int Height);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetCharText(int BlkObj, int LineIndex, int WordIndex, int CharIndex, int ResultIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetCharQual(int BlkObj, int LineIndex, int WordIndex, int CharIndex, int ResultIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetTextRect(int BlkObj, int LineIndex, int WordIndex, out int Xpos, out int Ypos, out int Width, out int Height);

        [DllImport(LIBNAME)]
        public static extern int Blk_Inversion(int BlkObj, int Inversion);

        [DllImport(LIBNAME)]
        public static extern int Blk_Rotation(int BlkObj, int Rotation);

        [DllImport(LIBNAME)]
        public static extern int Blk_Mirror(int BlkObj, int Mirror);

        [DllImport(LIBNAME)]
        public static extern int Blk_IsWordInDictionary(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_SetRect(int BlkObj, int Xpos, int Ypos, int Width, int Height);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordQual(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordFontColor(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordFontSize(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetWordFontStyle(int BlkObj, int LineIndex, int WordIndex);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetBackgroundColor(int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Blk_SetWordRegEx(int BlkObj, int LineIndex, int WordIndex, [MarshalAs(UnmanagedType.LPWStr)] string RegEx, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetBarcodeCnt(int BlkObj);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetBarcodeText(int BlkObj, int BarcodeInd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetBarcodeRect(int BlkObj, int BarcodeInd, out int Xpos, out int Ypos, out int Width, out int Height);

        [DllImport(LIBNAME)]
        public static extern int Blk_GetBarcodeType(int BlkObj, int BarcodeInd);

        [DllImport(LIBNAME)]
        public static extern int Svr_Create(int CfgObj, int Format, out int SvrObj);

        [DllImport(LIBNAME)]
        public static extern int Svr_Destroy(int SvrObj);

        [DllImport(LIBNAME)]
        public static extern int Svr_NewDocument(int SvrObj);

        [DllImport(LIBNAME)]
        public static extern int Svr_AddPage(int SvrObj, int ImgObj, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Svr_SaveToFile(int SvrObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName);

        [DllImport(LIBNAME)]
        public static extern int Svr_SaveToMemory(int SvrObj, IntPtr Bytes, int BufferSize);

        [DllImport(LIBNAME)]
        public static extern int Svr_GetText(int SvrObj, int PageIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder TextStr, int MaxLen);

        [DllImport(LIBNAME)]
        public static extern int Svr_SetDocumentInfo(int SvrObj, int InfoID, [MarshalAs(UnmanagedType.LPWStr)] string InfoStr);

        [DllImport(LIBNAME)]
        public static extern int Scan_Create(int CfgObj, out int ScanObj);

        [DllImport(LIBNAME)]
        public static extern int Scan_Destroy(int ScanObj);

        [DllImport(LIBNAME)]
        public static extern int Scan_Enumerate(int ScanObj, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder ScannerNames, int MaxLen, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Scan_ScanToImg(int ScanObj, int ImgObj, int ScannerIndex, int Flags);

        [DllImport(LIBNAME)]
        public static extern int Scan_ScanToFile(int ScanObj, [MarshalAs(UnmanagedType.LPWStr)] string FileName, int ScannerIndex, int Flags);

        #endregion
        public static bool IniciarMotorOCR(ref PictureBox PicBox)
        {
            Graficos = PicBox.CreateGraphics();

            bIniciado = true; //Instância de NSOCR criada com sucesso

            //Pega a versão do NSOCR
            clsNsOCR.Engine_GetVersion(out string strVersaoDLL);

            //Inicia o motor para criar objetos relacionados ao ocr
            clsNsOCR.Engine_Initialize();
            clsNsOCR.Cfg_Create(out intObjCfg);
            clsNsOCR.Cfg_LoadOptions(intObjCfg, "Config.dat");
            clsNsOCR.Ocr_Create(intObjCfg, out OcrObj);
            clsNsOCR.Img_Create(OcrObj, out intObjImagem);

            clsNsOCR.Scan_Create(intObjCfg, out intObjScan);

            if (clsNsOCR.Cfg_GetOption(intObjCfg, (int)TiposBlocos.BT_DEFAULT, "ImgAlizer/AutoScale", out strVersaoDLL) < (int)TiposErrosOCR.ERROR_FIRST)
                return (strVersaoDLL == "1");

            return false;
        }

        public static void FinalizarMotor()
        {
            if (bIniciado)
            {
                //Limpa os objetos da memória
                if (intObjImagem != 0) clsNsOCR.Img_Destroy(intObjImagem);
                if (OcrObj != 0) clsNsOCR.Ocr_Destroy(OcrObj);
                if (intObjCfg != 0) clsNsOCR.Cfg_Destroy(intObjCfg);
                if (intObjScan != 0) clsNsOCR.Scan_Destroy(intObjScan);
                clsNsOCR.Engine_Uninitialize();
            }
        }

    }
}
