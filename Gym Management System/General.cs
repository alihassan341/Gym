using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Drawing;
using static Gym_Management_System.General;

namespace Gym_Management_System
{
    public class General
    {
        public static string CreateEmptyExcelFileAndGetGuid(string FileName)
        {
            using (ExcelPackage package = new ExcelPackage(/*new FileInfo("MyWorkbook.xlsx"*/))
            {
                FilePathDownlode Down = new FilePathDownlode();
                string Extention = ".xlsx";
                string path = Path.GetTempPath() + FileName.Replace('/', '-') + "-" + new Random().Next(1, 11) + Extention;
                package.Workbook.Worksheets.Add(FileName);
                package.SaveAs(new FileInfo(path));
                Down.Guid = Guid.NewGuid();
                Down.FileName = FileName;
                Down.FilePath = path;
                Down.FileExt = Extention;
                General.LstFileDown.Add(Down);
                return Down.Guid.ToString();
            }
        }

        public static string ExportBase64ToExcelAndGetGuid(string Filename, byte[] Format)
        {
            FilePathDownlode Down = new FilePathDownlode();
            string Extention = ".xlsx";
            string path = Path.GetTempPath() + Filename.Replace('/', '-') + '-' + new Random().Next(1, 11) + Extention;
            File.WriteAllBytes(path, Format);
            Down.Guid = new Guid();
            Down.FileName = Filename;
            Down.FilePath = path;
            Down.FileExt = Extention;
            LstFileDown.Add(Down);
            return Down.Guid.ToString();
        }


        public static byte[] ConvertExcelToByteArray(string excelFilePath)
        {
            using (FileStream fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                // Load the Excel workbook
                IWorkbook workbook = new XSSFWorkbook(fileStream);

                // Create a memory stream to store the Excel data
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Save the Excel workbook to the memory stream
                    workbook.Write(memoryStream);

                    // Get the byte array from the memory stream
                    byte[] byteArray = memoryStream.ToArray();

                    return byteArray;
                }
            }
        }



        public static List<FilePathDownlode> LstFileDown = new List<FilePathDownlode>();
        public class FilePathDownlode
        {
            public int Id { get; set; }
            public Guid Guid { get; set; }
            public string FilePath { get; set; } = string.Empty;
            public string FileName { get; set; } = string.Empty;
            public string FileExt { get; set; } = string.Empty;
            public byte[] FileBytes { get; set; } = new byte[1024];

        }
    }
}