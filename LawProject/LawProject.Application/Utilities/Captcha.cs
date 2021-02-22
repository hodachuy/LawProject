using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace LawProject.Application.Utilities
{
    public class Captcha
    {
        private int _width, _height;
        private string _captchaCode;
        private Random rand = new Random();
        private Bitmap baseMap;
        private Graphics graph;
        public Captcha(int width, int height, string captchaCode)
        {
            _width = width;
            _height = height;
            _captchaCode = captchaCode;
        }
        public string GenerateCaptchaImage()
        {
            using (baseMap = new Bitmap(_width, _height))
            using (graph = Graphics.FromImage(baseMap))
            {
                graph.Clear(GetRandomLightColor());

                DrawCaptchaCode();
                DrawDisorderLine();
                AdjustRippleEffect();

                MemoryStream ms = new MemoryStream();

                baseMap.Save(ms, ImageFormat.Png);

                return Convert.ToBase64String(ms.ToArray());

                //return new CaptchaResult { _captchaCode = _captchaCode, CaptchaByteData = ms.ToArray(), Timestamp = DateTime.Now };
            }
        }
        int GetFontSize(int image_width, int captchCodeCount)
        {
            var averageSize = image_width / captchCodeCount;

            return Convert.ToInt32(averageSize);
        }

        Color GetRandomDeepColor()
        {
            Random rand = new Random();
            int redlow = 160, greenLow = 100, blueLow = 160;
            return Color.FromArgb(rand.Next(redlow), rand.Next(greenLow), rand.Next(blueLow));
        }

        Color GetRandomLightColor()
        {
            Random rand = new Random();
            int low = 180, high = 255;

            int nRend = rand.Next(high) % (high - low) + low;
            int nGreen = rand.Next(high) % (high - low) + low;
            int nBlue = rand.Next(high) % (high - low) + low;

            return Color.FromArgb(nRend, nGreen, nBlue);
        }

        void DrawCaptchaCode()
        {
            Random rand = new Random();
            SolidBrush fontBrush = new SolidBrush(Color.Black);
            int fontSize = GetFontSize(_width, _captchaCode.Length);
            Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            for (int i = 0; i < _captchaCode.Length; i++)
            {
                fontBrush.Color = GetRandomDeepColor();

                int shiftPx = fontSize / 6;

                float x = i * fontSize + rand.Next(-shiftPx, shiftPx) + rand.Next(-shiftPx, shiftPx);
                int maxY = _height - fontSize;
                if (maxY < 0) maxY = 0;
                float y = rand.Next(0, maxY);

                graph.DrawString(_captchaCode[i].ToString(), font, fontBrush, x, y);
            }
        }

        void DrawDisorderLine()
        {
            Pen linePen = new Pen(new SolidBrush(Color.Black), 3);
            for (int i = 0; i < rand.Next(3, 5); i++)
            {
                linePen.Color = GetRandomDeepColor();

                Point startPoint = new Point(rand.Next(0, _width), rand.Next(0, _height));
                Point endPoint = new Point(rand.Next(0, _width), rand.Next(0, _height));
                graph.DrawLine(linePen, startPoint, endPoint);

                //Point bezierPoint1 = new Point(rand.Next(0, _width), rand.Next(0, _height));
                //Point bezierPoint2 = new Point(rand.Next(0, _width), rand.Next(0, _height));

                //graph.DrawBezier(linePen, startPoint, bezierPoint1, bezierPoint2, endPoint);
            }
        }

        void AdjustRippleEffect()
        {
            short nWave = 6;
            int nWidth = baseMap.Width;
            int nHeight = baseMap.Height;

            Point[,] pt = new Point[nWidth, nHeight];

            for (int x = 0; x < nWidth; ++x)
            {
                for (int y = 0; y < nHeight; ++y)
                {
                    var xo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                    var yo = nWave * Math.Cos(2.0 * 3.1415 * x / 128.0);

                    var newX = x + xo;
                    var newY = y + yo;

                    if (newX > 0 && newX < nWidth)
                    {
                        pt[x, y].X = (int)newX;
                    }
                    else
                    {
                        pt[x, y].X = 0;
                    }


                    if (newY > 0 && newY < nHeight)
                    {
                        pt[x, y].Y = (int)newY;
                    }
                    else
                    {
                        pt[x, y].Y = 0;
                    }
                }
            }

            Bitmap bSrc = (Bitmap)baseMap.Clone();

            BitmapData bitmapData = baseMap.LockBits(new Rectangle(0, 0, baseMap.Width, baseMap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int scanline = bitmapData.Stride;

            IntPtr scan0 = bitmapData.Scan0;
            IntPtr srcScan0 = bmSrc.Scan0;

            baseMap.UnlockBits(bitmapData);
            bSrc.UnlockBits(bmSrc);
            bSrc.Dispose();
        }
    }
}
