using NPOI.SS.UserModel;

namespace WyboryPrezydenckie2025.DataTransformer.Interfaces;

public interface IDaneDoWykresu
{
    void WriteTableHeaderToSheet(ISheet sheet);
    void SetColumnSize(ISheet sheet);
    void WriteRowToSheet(ISheet sheet, int rowIndex);
}