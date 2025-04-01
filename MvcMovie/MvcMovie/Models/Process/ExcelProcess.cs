using OfficeOpenXml;
using System.Data;

namespace MvcMovie.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string filePath)
        {
            DataTable dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                if (worksheet.Dimension == null)
                    return dt;

                // Đọc tiêu đề cột
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    dt.Columns.Add(worksheet.Cells[1, col].Text.Trim());
                }

                // Đọc dữ liệu hàng
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow newRow = dt.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        newRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dt.Rows.Add(newRow);
                }
            }
            return dt;
        }
    }
}
