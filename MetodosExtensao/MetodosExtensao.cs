using System;
using System.Drawing;

namespace Ocr.MetodosExtensao
{
    public static class MetodosExtensao
    {
        /// <summary>
        /// Método que retorna a representação de uma imagem em memória baseada
        /// nos parâmetros passados como argumento
        /// </summary>
        /// <param name="strTexto"> Texto a ser transformado </param>
        /// <param name="strFont"> Fonte padrão a ser utilizada </param>
        /// <param name="intTamanhoFont"> Tamanho da fonte a ser utilizada </param>
        /// <param name="corFundo"> Cor do plano de fundo a ser empregado  </param>
        /// <param name="corFonte"> Cor da fonte do texto a ser empregado</param>
        /// <param name="intLargura"> Largura definida para a imagem </param>
        /// <param name="intAltura"> Altura definida para a imagem </param>
        /// <returns> Imagem criada em Bitmap </returns>
        public static Bitmap ConverterTextoImagem(string strTexto, string strFont, int intTamanhoFont, Color corFundo, Color corFonte, int intLargura, int intAltura)
        {
            //Definição da imagem
            Bitmap bmp = new Bitmap(intLargura, intAltura);
            //Criação de Gráficos para a imagem
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                using (Font font = new Font(strFont, intTamanhoFont))
                {
                    graphics.FillRectangle(new SolidBrush(corFundo), 0, 0, bmp.Width, bmp.Height);
                    graphics.DrawString(strTexto, font, new SolidBrush(corFonte), 0, 0);
                    graphics.Flush();
                }
            }
            return bmp;
        }

        /// <summary>
        /// Método que faz o tratamento de exceções de acordo com a pilha de execução.
        /// 1º Chamada: Exceção gerada em formulários (ex.message)
        /// 2º Chamada em diante: Exceção gerada por método/classe auxiliar (ex.InnerException.Message)
        /// </summary>
        /// <param name="ex"> Exceção atual a ser tratada </param>
        /// <returns> Mensagem de erro e método gerador da exceção </returns>
        public static string TratamentoDeExcecoes(this Exception ex)
        {
            if (ex.InnerException != null)
                return $"{ex.InnerException.Message} - {ex.InnerException.TargetSite.Name}";

            return $"{ex.Message} - {ex.TargetSite.Name}";
        }

        /// <summary>
        /// Método para simular uso do WITH do VB.NET
        /// </summary>
        /// <typeparam name="T"> Tipo Genérico </typeparam>
        /// <param name="item"> Item atual a ser usado </param>
        /// <param name="action"> Ações que poderão ser feitas através de lambda </param>
        /// <returns> A referência do Objeto </returns>
        public static T With<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }
    }
}
