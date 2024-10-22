using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR2ImageOrSearchablePDF
{
    public class WhiteUpLogic
    {

        /// <summary>
        /// 毫米转像素： x * dpi_x /25.4;垂直方向的换算： y * dpi_y /25.4(其中，x为毫米宽度，y为毫米高度)
        /// </summary>
        /// <param name="milimeter">毫米尺寸大小</param>
        /// <param name="dpi">分辨率DPI</param>
        /// <returns></returns>
        protected static float MillimetersToPixels(float milimeter, float dpi)
        {
            float result = (float)(milimeter * dpi / 25.4);
            return result;
        }

        /// <summary>
        /// 像素转毫米。
        /// </summary>
        /// <param name="pixel"></param>
        /// <param name="dpi">设定的DPI</param>
        /// <returns></returns>
        protected static float PixelsToMillimeters(float pixel, float dpi)
        {
            float result = (float)(pixel * 25.4 / dpi);
            return result;
        }

        protected static void VerifyIfUseA4orA3orA2(int width, int height, float dpiX, float dpiY, ref float newWidth, ref float newHeight)
        {
            float milliWidth = PixelsToMillimeters(width, dpiX);
            float milliHeight = PixelsToMillimeters(height, dpiY);
            if (width <= height)
            {
                if (milliHeight <= PaperSize.A4Height && milliWidth <= PaperSize.A4Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A4Width, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A4Height, dpiY);
                }
                else if (milliHeight > PaperSize.A4Height && milliWidth > PaperSize.A4Width && milliHeight <= PaperSize.A3Height && milliWidth <= PaperSize.A3Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A3Width, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A3Height, dpiY);
                }
                else if (milliHeight > PaperSize.A3Height && milliWidth > PaperSize.A3Width && milliHeight <= PaperSize.A2Height && milliWidth <= PaperSize.A2Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A2Width, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A2Height, dpiY);
                }
                else if (milliHeight > PaperSize.A2Height && milliWidth > PaperSize.A2Width && milliHeight <= PaperSize.A1Height && milliWidth <= PaperSize.A1Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A1Width, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A1Height, dpiY);
                }
                else if (milliHeight > PaperSize.A1Height && milliWidth > PaperSize.A1Width && milliHeight <= PaperSize.A0Height && milliWidth <= PaperSize.A0Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A0Width, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A0Height, dpiY);
                }
                else
                {
                    newWidth = float.MaxValue;
                    newHeight = float.MaxValue;
                }
            }
            else
            {
                if (milliWidth <= PaperSize.A4Height && milliHeight <= PaperSize.A4Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A4Height, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A4Width, dpiY);
                }
                else if (milliWidth > PaperSize.A4Height && milliHeight > PaperSize.A4Width && milliWidth <= PaperSize.A3Height && milliHeight <= PaperSize.A3Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A3Height, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A3Width, dpiY);
                }
                else if (milliWidth > PaperSize.A3Height && milliHeight > PaperSize.A3Width && milliWidth <= PaperSize.A2Height && milliHeight <= PaperSize.A2Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A2Height, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A2Width, dpiY);
                }
                else if (milliWidth > PaperSize.A2Height && milliHeight > PaperSize.A2Width && milliWidth <= PaperSize.A1Height && milliHeight <= PaperSize.A1Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A1Height, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A1Width, dpiY);
                }
                else if (milliWidth > PaperSize.A1Height && milliHeight > PaperSize.A1Width && milliWidth <= PaperSize.A0Height && milliHeight <= PaperSize.A0Width)
                {
                    newWidth = MillimetersToPixels(PaperSize.A0Height, dpiX);
                    newHeight = MillimetersToPixels(PaperSize.A0Width, dpiY);
                }
                else
                {
                    newWidth = float.MaxValue;
                    newHeight = float.MaxValue;
                }
            }
        }

        public static string VerifyIfUseA4orA3orA2orA1orA0(int width, int height, float dpiX, float dpiY)
        {
            float milliWidth = PixelsToMillimeters(width, dpiX);
            float milliHeight = PixelsToMillimeters(height, dpiY);
            float diff = 10.0f; //误差
            if (width <= height)
            {
                double regularPercent = Math.Round(PaperSize.A4Width / PaperSize.A4Height, 4);
                double percent = Math.Round((double)width / height, 4);

                if (milliHeight <= (PaperSize.A4Height + diff) && milliWidth <= (PaperSize.A4Width + diff))
                {
                    return "A4";
                }
                else if (((percent >= regularPercent && milliWidth > PaperSize.A4Width) || (percent <= regularPercent && milliHeight > PaperSize.A4Height))
                    && milliHeight <= (PaperSize.A3Height + diff) && milliWidth <= (PaperSize.A3Width + diff))
                {
                    return "A3";
                }
                else if (((percent >= regularPercent && milliWidth > PaperSize.A3Width) || (percent <= regularPercent && milliHeight > PaperSize.A3Height))
                    && milliHeight <= (PaperSize.A2Height + diff) && milliWidth <= (PaperSize.A2Width + diff))
                {
                    return "A2";
                }
                else if (((percent >= regularPercent && milliWidth > PaperSize.A2Width) || (percent <= regularPercent && milliHeight > PaperSize.A2Height))
                    && milliHeight <= (PaperSize.A1Height + diff) && milliWidth <= (PaperSize.A1Width + diff))
                {
                    return "A1";
                }
                else if (((percent >= regularPercent && milliWidth > PaperSize.A1Width) || (percent <= regularPercent && milliHeight > PaperSize.A1Height))
                    && milliHeight <= (PaperSize.A0Height + diff) && milliWidth <= (PaperSize.A0Width + diff))
                {
                    return "A0";
                }
                else
                {
                    return "AMAX";
                }
            }
            else
            {
                double regularPercent = Math.Round(PaperSize.A4Width / PaperSize.A4Height, 4);
                double percent = Math.Round((double)height / width, 4);
                if (milliWidth <= (PaperSize.A4Height + diff) && milliHeight <= (PaperSize.A4Width + diff))
                {
                    return "A4";
                }
                else if (((percent >= regularPercent && milliHeight >= PaperSize.A4Width) || (percent <= regularPercent && milliWidth > PaperSize.A4Height))
                    && milliWidth <= (PaperSize.A3Height + diff) && milliHeight <= (PaperSize.A3Width + diff))
                {
                    return "A3";
                }
                else if (((percent >= regularPercent && milliHeight >= PaperSize.A3Width) || (percent <= regularPercent && milliWidth > PaperSize.A3Height))
                    && milliWidth <= (PaperSize.A2Height + diff) && milliHeight <= (PaperSize.A2Width + diff))
                {
                    return "A2";
                }
                else if (((percent >= regularPercent && milliHeight >= PaperSize.A2Width) || (percent <= regularPercent && milliWidth > PaperSize.A2Height))
                    && milliWidth <= (PaperSize.A1Height + diff) && milliHeight <= (PaperSize.A1Width + diff))
                {
                    return "A1";
                }
                else if (((percent >= regularPercent && milliHeight >= PaperSize.A1Width) || (percent <= regularPercent && milliWidth > PaperSize.A1Height))
                    && milliWidth <= (PaperSize.A0Height + diff) && milliHeight <= (PaperSize.A0Width + diff))
                {
                    return "A0";
                }
                else
                {
                    return "AMAX";
                }
            }
        }

        public static string VerifyIfUseA4orA3orA2orA1orA0(int width, int height, float dpiX, float dpiY, float blanceDeta)
        {
            float milliWidth = PixelsToMillimeters(width, dpiX);
            float milliHeight = PixelsToMillimeters(height, dpiY);
            //float diff = 10.0f; //误差
            float deta = blanceDeta;

            if (width <= height)
            {
                //double regularPercent = Math.Round(PaperSize.A4Width / PaperSize.A4Height, 4);//标准百分百
                //double percent = Math.Round((double)width / height, 4);//实际百分比 

                float diff = (float)(milliWidth * deta); //误差

                if (milliHeight <= (PaperSize.A4Height + diff) && milliWidth <= (PaperSize.A4Width + diff))
                {
                    return "A4";
                }
                else if (milliHeight <= (PaperSize.A3Height + diff) && milliWidth <= (PaperSize.A3Width + diff))
                {
                    return "A3";
                }
                else if (milliHeight <= (PaperSize.A2Height + diff) && milliWidth <= (PaperSize.A2Width + diff))
                {
                    return "A2";
                }
                else if (milliHeight <= (PaperSize.A1Height + diff) && milliWidth <= (PaperSize.A1Width + diff))
                {
                    return "A1";
                }
                else if (milliHeight <= (PaperSize.A0Height + diff) && milliWidth <= (PaperSize.A0Width + diff))
                {
                    return "A0";
                }
                else
                {
                    //return "AMAX";
                    return "A0";
                }
            }
            else
            {
                //double regularPercent = Math.Round(PaperSize.A4Width / PaperSize.A4Height, 4);
                //double percent = Math.Round((double)height / width, 4);

                float diff = (float)(milliHeight * deta); //误差
                if (milliWidth <= (PaperSize.A4Height + diff) && milliHeight <= (PaperSize.A4Width + diff))
                {
                    return "A4";
                }
                else if (milliWidth <= (PaperSize.A3Height + diff) && milliHeight <= (PaperSize.A3Width + diff))
                {
                    return "A3";
                }
                else if (milliWidth <= (PaperSize.A2Height + diff) && milliHeight <= (PaperSize.A2Width + diff))
                {
                    return "A2";
                }
                else if (milliWidth <= (PaperSize.A1Height + diff) && milliHeight <= (PaperSize.A1Width + diff))
                {
                    return "A1";
                }
                else if (milliWidth <= (PaperSize.A0Height + diff) && milliHeight <= (PaperSize.A0Width + diff))
                {
                    return "A0";
                }
                else
                {
                    //return "AMAX";
                    return "A0";
                }
            }
        }

        // <summary>
        /// 在图片周围加入白边形成A4或A3大小
        /// </summary>
        /// <param name="Img">图片</param>
        /// <param name="Margin">白边的高度，单位是像素</param>
        /// <returns>Bitmap</returns>
        public static Bitmap WhiteUp(Image img)
        {
            //获取图片宽高
            int width = img.Width;
            int height = img.Height;
            //获取图片水平和垂直的分辨率
            float dpiX = img.HorizontalResolution;
            float dpiY = img.VerticalResolution;

            float newWidth = float.NaN;
            float newHeight = float.NaN;
            VerifyIfUseA4orA3orA2(width, height, dpiX, dpiY, ref newWidth, ref newHeight);

            //创建一个位图文件
            Bitmap BitmapResult = new Bitmap((int)newWidth, (int)newHeight, PixelFormat.Format24bppRgb);
            //设置位图文件的水平和垂直分辨率  与Img一致
            BitmapResult.SetResolution(dpiX, dpiY);
            //在位图文件上填充一个矩形框
            Graphics Grp = Graphics.FromImage(BitmapResult);
            System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(0, 0, (int)newWidth, (int)newHeight);
            //定义一个白色的画刷
            SolidBrush mySolidBrush = new SolidBrush(System.Drawing.Color.White);
            //Grp.Clear(Color.White);
            //将矩形框填充为白色
            Grp.FillRectangle(mySolidBrush, Rec);
            //Grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //Grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //向矩形框内填充Img

            float left = (newWidth - width) / 2;
            float top = (newHeight - height) / 2;

            Grp.DrawImage(img, left, top, Rec, GraphicsUnit.Pixel);
            //返回位图文件
            Grp.Dispose();
            GC.Collect();
            return BitmapResult;
        }


        /// <summary>
        /// 根据指定大小（单位：厘米）在图片周围加白边
        /// </summary>
        /// <param name="img"></param>
        /// <param name="outerSize">指定大小</param>
        /// <returns></returns>
        public static Bitmap WhiteUp(Image img, int outerSize)
        {
            //获取图片宽高
            int width = img.Width;
            int height = img.Height;
            //获取图片水平和垂直的分辨率
            float dpiX = img.HorizontalResolution;
            float dpiY = img.VerticalResolution;

            float balance = MillimetersToPixels(outerSize, dpiX);
            float newWidth = width + balance;
            float newHeight = height + balance;
            //VerifyIfUseA4orA3orA2(width, height, dpiX, dpiY, ref newWidth, ref newHeight);

            //创建一个位图文件
            Bitmap BitmapResult = new Bitmap((int)newWidth, (int)newHeight, PixelFormat.Format24bppRgb);
            //设置位图文件的水平和垂直分辨率  与Img一致
            BitmapResult.SetResolution(dpiX, dpiY);
            //在位图文件上填充一个矩形框
            Graphics Grp = Graphics.FromImage(BitmapResult);
            System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(0, 0, (int)newWidth, (int)newHeight);
            //定义一个白色的画刷
            SolidBrush mySolidBrush = new SolidBrush(System.Drawing.Color.White);
            //Grp.Clear(Color.White);
            //将矩形框填充为白色
            Grp.FillRectangle(mySolidBrush, Rec);
            //Grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //Grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //向矩形框内填充Img

            float left = (newWidth - width) / 2;
            float top = (newHeight - height) / 2;

            Grp.DrawImage(img, left, top, Rec, GraphicsUnit.Pixel);
            //返回位图文件
            Grp.Dispose();
            GC.Collect();
            return BitmapResult;
        }
    }
}
