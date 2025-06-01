using SkiaSharp.QrCode;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Utils
{
    public class QrCodeHelper
    {
        /// <summary>
        /// Генерирует QR-код и возвращает его в виде массива байтов (PNG).
        /// </summary>
        /// <param name="text">Текст для кодирования в QR-код.</param>
        /// <param name="size">Размер изображения (ширина и высота в пикселях).</param>
        /// <returns>Массив байтов, представляющий PNG-изображение QR-кода.</returns>
        public byte[] GenerateQrCodeBytes(string text, int size = 300)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(text, ECCLevel.L);

            int moduleCount = qrCodeData.ModuleMatrix.Count;
            float pixelsPerModule = size / (float)moduleCount;

            var info = new SKImageInfo(size, size);
            using var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            using var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Black,
                IsAntialias = false
            };

            for (int y = 0; y < moduleCount; y++)
            {
                for (int x = 0; x < moduleCount; x++)
                {
                    if (qrCodeData.ModuleMatrix[y][x])
                    {
                        var rect = new SKRect(
                            x * pixelsPerModule,
                            y * pixelsPerModule,
                            (x + 1) * pixelsPerModule,
                            (y + 1) * pixelsPerModule);
                        canvas.DrawRect(rect, paint);
                    }
                }
            }

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }

        /// <summary>
        /// Генерирует QR-код и возвращает его в виде потока (PNG).
        /// </summary>
        /// <param name="text">Текст для кодирования в QR-код.</param>
        /// <param name="size">Размер изображения (ширина и высота в пикселях).</param>
        /// <returns>Поток, содержащий PNG-изображение QR-кода.</returns>
        public Stream GenerateQrCodeStream(string text, int size = 300)
        {
            var bytes = GenerateQrCodeBytes(text, size);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// Генерирует QR-код и возвращает его в виде массива байтов (PNG).
        /// </summary>
        /// <param name="content">Содержание QR-кода.</param>
        /// <returns>Массив байтов, представляющий PNG-изображение QR-кода.</returns>
        public byte[] QrCodeGenerate(string content)
        {
            using var generator = new QRCodeGenerator();

            var qr = generator.CreateQrCode(content, ECCLevel.L);

            var info = new SKImageInfo(512, 512);
            using var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;
            canvas.Render(qr, info.Width, info.Height);

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }
    }
}