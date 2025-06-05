using NPOI.SS.UserModel;
using WyboryPrezydenckie2025.DataTransformer.Interfaces;

namespace WyboryPrezydenckie2025.DataTransformer.Models;

public class Roznice<T> : IDaneDoWykresu
{
    public T Roznica { get; set; }
    public int LiczbaObwodow { get; set; }
    public void WriteTableHeaderToSheet(ISheet sheet)
    {
        var headerRow = sheet.CreateRow(0);

        var cell = headerRow.CreateCell(0);
        cell.SetCellValue(nameof(Roznica));
        cell = headerRow.CreateCell(1);
        cell.SetCellValue(nameof(LiczbaObwodow));
    }

    public void SetColumnSize(ISheet sheet)
    {
        for (int i = 0; i < 2; i++)
        {
            sheet.SetColumnWidth(i, 20 * 256);
        }
    }

    public void WriteRowToSheet(ISheet sheet, int rowIndex)
    {
        var row = sheet.CreateRow(rowIndex);

        var cell = row.CreateCell(0);
        cell.SetCellValue(Roznica.ToString());
        cell = row.CreateCell(1);
        cell.SetCellValue(LiczbaObwodow);
    }
}