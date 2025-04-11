using OfficeOpenXml;
using System.Data;

namespace MvcMovie.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            DataTable dt = new DataTable();
            foreach (var headerCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                dt.Columns.Add(headerCell.Text);
            }

            for (int rowNum = 2; rowNum <= worksheet.Dimension.End.Row; rowNum++)
            {
                var wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                DataRow row = dt.NewRow();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
