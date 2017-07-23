using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Excel
{
    /// <summary>
    /// Execl操作助手
    /// </summary>
    public class ExcelNpoiHelper
    {
        /// <summary>
        /// 导出Excel；DataTable列名即为Excel列名
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <returns></returns>
        public static Stream Export(DataTable sourceTable)
        {
            var ms = new MemoryStream();

            var workbook = new HSSFWorkbook();
            var sheet = (HSSFSheet)workbook.CreateSheet();
            var headerRow = (HSSFRow)sheet.CreateRow(0);

            // 设置表头
            foreach (DataColumn column in sourceTable.Columns)
            {
                int len = 0;
                DataRow dr = sourceTable.Rows[0];
                //根据内容显示列宽
                if (dr[column.Ordinal] != null) len = dr[column.Ordinal].ToString().Length + 5;
                sheet.SetColumnWidth(column.Ordinal, len * 256);

                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }

            // 设置数据 
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    int colunIndex = column.Ordinal;
                    dataRow.CreateCell(colunIndex).SetCellValue(row[column].ToString());

                }
                rowIndex++;
            }
            workbook.Write(ms);
            workbook.Close();
            return ms;
        }

        /// <summary>
        /// 导出Excel（生成文件保存在服务器）
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="FilePath"></param>
        public static void Export(DataTable sourceTable, string path, string fileName)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }
            else
            {
                File.Create(filePath).Close();
            }

            var ms = (MemoryStream)Export(sourceTable);

            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            ms.Close();
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="excelStream">文件流</param>
        /// <param name="sheetIndex">默认0</param>
        /// <returns></returns>
        public static DataTable Import(Stream excelStream, int sheetIndex = 0)
        {
            var table = new DataTable();

            var workbook = new HSSFWorkbook(excelStream);
            var sheet = (HSSFSheet)workbook.GetSheetAt(sheetIndex);
            var headerRow = (HSSFRow)sheet.GetRow(0);

            // 设置表头
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                var column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            // 设置数据
            int rowCount = sheet.LastRowNum;
            for (int i = (rowCount + 1); i < rowCount; i++)
            {
                var row = sheet.GetRow(i);
                var dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    dataRow[j] = row.GetCell(j).StringCellValue;
                }
            }

            excelStream.Close();
            workbook.Close();
            return table;
        }
    }
}
