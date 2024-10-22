using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR2ImageOrSearchablePDF
{
    public class PdfHelper
    {
        ///// <summary>
        ///// 读取合并的pdf文件名称
        ///// </summary>
        ///// <param name="Directorypath">目录</param>
        ///// <param name="outpath">导出的路径</param>
        //public static void MergePDF(string Directorypath, string outpath)
        //{
        //    List<string> filelist2 = new List<string>();
        //    System.IO.DirectoryInfo di2 = new System.IO.DirectoryInfo(Directorypath);
        //    FileInfo[] ff2 = di2.GetFiles("*.pdf");
        //    BubbleSort(ff2);
        //    foreach (FileInfo temp in ff2)
        //    {
        //        filelist2.Add(Directorypath + "\\" + temp.Name);
        //    }
        //    mergePDFFiles(filelist2, outpath);
        //    DeleteAllPdf(Directorypath);
        //}


        ///// <summary>
        ///// 冒泡排序
        ///// </summary>
        ///// <param name="arr">文件名数组</param>
        //public static void BubbleSort(FileInfo[] arr)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        for (int j = i; j < arr.Length; j++)
        //        {
        //            if (arr[i].LastWriteTime > arr[j].LastWriteTime)//按创建时间（升序）
        //            {
        //                FileInfo temp = arr[i];
        //                arr[i] = arr[j];
        //                arr[j] = temp;
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 合成pdf文件
        ///// </summary>
        ///// <param name="fileList">文件名list</param>
        ///// <param name="outMergeFile">输出路径</param>
        //public static void mergePDFFiles(List<string> fileList, string outMergeFile)
        //{
        //    PdfReader reader;
        //    Rectangle rec = new Rectangle(1660, 1000);
        //    Document document = new Document(rec);
        //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
        //    document.Open();
        //    PdfContentByte cb = writer.DirectContent;
        //    PdfImportedPage newPage;
        //    for (int i = 0; i < fileList.Count; i++)
        //    {
        //        reader = new PdfReader(fileList[i]);
        //        int iPageNum = reader.NumberOfPages;
        //        for (int j = 1; j <= iPageNum; j++)
        //        {
        //            document.NewPage();
        //            newPage = writer.GetImportedPage(reader, j);
        //            cb.AddTemplate(newPage, 0, 0);
        //        }
        //    }
        //    document.Close();
        //}


        ///// <summary>
        ///// 删除一个文件里所有的文件
        ///// </summary>
        ///// <param name="Directorypath">文件夹路径</param>
        //public static void DeleteAllPdf(string Directorypath)
        //{
        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Directorypath);
        //    if (di.Exists)
        //    {
        //        FileInfo[] ff = di.GetFiles("*.pdf");
        //        foreach (FileInfo temp in ff)
        //        {
        //            File.Delete(Directorypath + "\\" + temp.Name);
        //        }
        //    }
        //}

        /// <summary>
        /// 合并多个PDF，不带标签
        /// </summary>
        /// <param name="fileList"></param>
        /// <param name="outMergeFile"></param>
        public static void MergePdfFiles(FileInfo[] fileList, string outMergeFile,out string exception)
        {
            exception = string.Empty;
            PdfReader reader = null;
            List<PdfReader> readerList = new List<PdfReader>();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage newPage;
            for (int i = 0; i < fileList.Length; i++)
            {
                try
                {
                    reader = new PdfReader(fileList[i].FullName);
                }
                catch
                {
                    exception = "合成" + outMergeFile + "出错！原因：原始图片列表中有不可读的图片...";
                    return;
                }

                int iPageNum = reader.NumberOfPages;
                for (int j = 1; j <= iPageNum; j++)
                {
                    newPage = writer.GetImportedPage(reader, j);
                    iTextSharp.text.Rectangle r = reader.GetPageSize(j);
                    document.SetPageSize(r);
                    document.NewPage();
                    cb.AddTemplate(newPage, 0, 0);
                }
                readerList.Add(reader);
            }
            document.Close();

            foreach (var rd in readerList)//清理占用
            {
                rd.Dispose();
            }
        }
        public static void fnOCR(string v_strTesseractPath, string v_strSourceImgPath, string v_strOutputPath, string v_strLangPath)
        {
            using (Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = v_strTesseractPath;
                process.StartInfo.Arguments = v_strSourceImgPath + " " + v_strOutputPath + " -l " + v_strLangPath; // 参数中 +" pdf" ，就能输出双层PDF
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();
            }
        }

        //图像二值化
        public static Bitmap BinarizeImage(Bitmap b, byte threshold)
        {
            int width = b.Width;
            int height = b.Height;
            BitmapData data = b.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int offset = data.Stride - width * 4;
                byte R, G, B, gray;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        R = p[2];
                        G = p[1];
                        B = p[0];
                        gray = (byte)((R * 19595 + G * 38469 + B * 7472) >> 16);
                        if (gray >= threshold)
                        {
                            p[0] = p[1] = p[2] = 255;
                        }
                        else
                        {
                            p[0] = p[1] = p[2] = 0;
                        }
                        p += 4;
                    }
                    p += offset;
                }
                b.UnlockBits(data);
                return b;
            }
        }

        public static void ImageToSingleTierPDF(string source, string output)//图片转PDF
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(source);//
            using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (Document doc = new Document(image))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        //writer.CompressionLevel = 0;
                        writer.SetFullCompression();
                        writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_7);
                        //writer.CompressionLevel = PdfStream.NO_COMPRESSION; 

                        doc.Open();
                        image.SetAbsolutePosition(0, 0);
                        doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image.Width, image.Height, 0));
                        doc.NewPage();

                        writer.DirectContent.AddImage(image, false);
                        doc.Close();
                    }
                }
            }
        }


    }
}
