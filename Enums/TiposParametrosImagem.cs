using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocr.Enums
{
    /// <summary>
    /// Para o parâmetro "PropertyID" da funções Img_GetProperty
    /// </summary>
    public enum TiposParametrosImagem
    {
        IMG_PROP_DPIX = 0x01,  //DPI Origial
        IMG_PROP_DPIY = 0x02,
        IMG_PROP_BPP = 0x03, //cor de profundidade
        IMG_PROP_WIDTH = 0x04, //Largura original
        IMG_PROP_HEIGHT = 0x05,    //Altura original
        IMG_PROP_INVERTED = 0x06,   //Sinalizador de inversão de imagem após a etapa OCR_STEP_PREFILTERS
        IMG_PROP_SKEW = 0x07,  //Ângulo de inclinação da imagem realizado após a etapa OCR_STEP_PREFILTERS, multiplicado por 1000
        IMG_PROP_SCALE = 0x08, //Fator de escala da imagem realizado após a etapa OCR_STEP_PREFILTERS, multiplicado por 1000
        IMG_PROP_PAGEINDEX = 0x09 //Índice da imagem da página atual
    }
}
