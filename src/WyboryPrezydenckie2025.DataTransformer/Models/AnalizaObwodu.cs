using NPOI.SS.UserModel;
using WyboryPrezydenckie2025.DataTransformer.Interfaces;

namespace WyboryPrezydenckie2025.DataTransformer.Models;

public class AnalizaObwodu : IDaneDoWykresu
{
    public int NrKomisji { get; set; }
    public string Gmina { get; set; }
    public int TerytGminy { get; set; }
    public string Powiat { get; set; }
    public int TerytPowiatu { get; set; }
    public string Województwo { get; set; }
    public string Siedziba { get; set; }
    public string TypObwodu { get; set; }
    public string TypObszaru { get; set; }
    public int Nawrocki1 { get; set; }
    public int Nawrocki2 { get; set; }
    public int Trzaskowski1 { get; set; }
    public int Trzaskowski2 { get; set; }
    public int Bartoszewicz { get; set; }
    public int Biejat { get; set; }
    public int Braun { get; set; }
    public int Hołownia { get; set; }
    public int Jakubiak { get; set; }
    public int Maciak { get; set; }
    public int Mentzen { get; set; }
    public int Senyszyn { get; set; }
    public int Stanowski { get; set; }
    public int Woch { get; set; }
    public int Zandberg { get; set; }
    public int GłosyWażne1 { get; set; }
    public int GłosyWażne2 { get; set; }
    public double WspolczynnikDlaTrzaskowskiegoExitPoll { get; set; }
    public double WspolczynnikDlaNawrockiegoExitPoll { get; set; }
    public int PrognozaTrzaskowski { get; set; }
    public int PrognozaNawrocki { get; set; }
    public void WriteTableHeaderToSheet(ISheet sheet)
    {
        var headerRow = sheet.CreateRow(0);

        var cell = headerRow.CreateCell(0);
        cell.SetCellValue(nameof(NrKomisji));
        cell = headerRow.CreateCell(1);
        cell.SetCellValue(nameof(Gmina));
        cell = headerRow.CreateCell(2);
        cell.SetCellValue(nameof(TerytGminy));
        cell = headerRow.CreateCell(3);
        cell.SetCellValue(nameof(Powiat));
        cell = headerRow.CreateCell(4);
        cell.SetCellValue(nameof(TerytPowiatu));
        cell = headerRow.CreateCell(5);
        cell.SetCellValue(nameof(Województwo));
        cell = headerRow.CreateCell(6);
        cell.SetCellValue(nameof(Siedziba));
        cell = headerRow.CreateCell(7);
        cell.SetCellValue(nameof(TypObwodu));
        cell = headerRow.CreateCell(8);
        cell.SetCellValue(nameof(TypObszaru));
        cell = headerRow.CreateCell(9);
        cell.SetCellValue(nameof(Nawrocki1));
        cell = headerRow.CreateCell(10);
        cell.SetCellValue(nameof(Nawrocki2));
        cell = headerRow.CreateCell(11);
        cell.SetCellValue(nameof(Trzaskowski1));
        cell = headerRow.CreateCell(12);
        cell.SetCellValue(nameof(Trzaskowski2));
        cell = headerRow.CreateCell(13);
        cell.SetCellValue(nameof(Bartoszewicz));
        cell = headerRow.CreateCell(14);
        cell.SetCellValue(nameof(Biejat));
        cell = headerRow.CreateCell(15);
        cell.SetCellValue(nameof(Braun));
        cell = headerRow.CreateCell(16);
        cell.SetCellValue(nameof(Hołownia));
        cell = headerRow.CreateCell(17);
        cell.SetCellValue(nameof(Jakubiak));
        cell = headerRow.CreateCell(18);
        cell.SetCellValue(nameof(Maciak));
        cell = headerRow.CreateCell(19);
        cell.SetCellValue(nameof(Mentzen));
        cell = headerRow.CreateCell(21);
        cell.SetCellValue(nameof(Senyszyn));
        cell = headerRow.CreateCell(22);
        cell.SetCellValue(nameof(Stanowski));
        cell = headerRow.CreateCell(23);
        cell.SetCellValue(nameof(Woch));
        cell = headerRow.CreateCell(24);
        cell.SetCellValue(nameof(Zandberg));
        cell = headerRow.CreateCell(25);
        cell.SetCellValue(nameof(GłosyWażne1));
        cell = headerRow.CreateCell(26);
        cell.SetCellValue(nameof(GłosyWażne2));
        cell = headerRow.CreateCell(27);
        cell.SetCellValue(nameof(WspolczynnikDlaTrzaskowskiegoExitPoll));
        cell = headerRow.CreateCell(28);
        cell.SetCellValue(nameof(WspolczynnikDlaNawrockiegoExitPoll));
        cell = headerRow.CreateCell(29);
        cell.SetCellValue(nameof(PrognozaTrzaskowski));
        cell = headerRow.CreateCell(30);
        cell.SetCellValue(nameof(PrognozaNawrocki));
    }

    public void SetColumnSize(ISheet sheet)
    {
        for (int i = 0; i < 31; i++)
        {
            sheet.SetColumnWidth(i, 20*256);
        }
    }

    public void WriteRowToSheet(ISheet sheet, int rowIndex)
    {
        var row = sheet.CreateRow(rowIndex);

        var cell = row.CreateCell(0);
        cell.SetCellValue(NrKomisji);
        cell = row.CreateCell(1);
        cell.SetCellValue(Gmina);
        cell = row.CreateCell(2);
        cell.SetCellValue(TerytGminy);
        cell = row.CreateCell(3);
        cell.SetCellValue(Powiat);
        cell = row.CreateCell(4);
        cell.SetCellValue(TerytPowiatu);
        cell = row.CreateCell(5);
        cell.SetCellValue(Województwo);
        cell = row.CreateCell(6);
        cell.SetCellValue(Siedziba);
        cell = row.CreateCell(7);
        cell.SetCellValue(TypObwodu);
        cell = row.CreateCell(8);
        cell.SetCellValue(TypObszaru);
        cell = row.CreateCell(9);
        cell.SetCellValue(Nawrocki1);
        cell = row.CreateCell(10);
        cell.SetCellValue(Nawrocki2);
        cell = row.CreateCell(11);
        cell.SetCellValue(Trzaskowski1);
        cell = row.CreateCell(12);
        cell.SetCellValue(Trzaskowski2);
        cell = row.CreateCell(13);
        cell.SetCellValue(Bartoszewicz);
        cell = row.CreateCell(14);
        cell.SetCellValue(Biejat);
        cell = row.CreateCell(15);
        cell.SetCellValue(Braun);
        cell = row.CreateCell(16);
        cell.SetCellValue(Hołownia);
        cell = row.CreateCell(17);
        cell.SetCellValue(Jakubiak);
        cell = row.CreateCell(18);
        cell.SetCellValue(Maciak);
        cell = row.CreateCell(19);
        cell.SetCellValue(Mentzen);
        cell = row.CreateCell(21);
        cell.SetCellValue(Senyszyn);
        cell = row.CreateCell(22);
        cell.SetCellValue(Stanowski);
        cell = row.CreateCell(23);
        cell.SetCellValue(Woch);
        cell = row.CreateCell(24);
        cell.SetCellValue(Zandberg);
        cell = row.CreateCell(25);
        cell.SetCellValue(GłosyWażne1);
        cell = row.CreateCell(26);
        cell.SetCellValue(GłosyWażne2);
        cell = row.CreateCell(27);
        cell.SetCellValue(WspolczynnikDlaTrzaskowskiegoExitPoll);
        cell = row.CreateCell(28);
        cell.SetCellValue(WspolczynnikDlaNawrockiegoExitPoll);
        cell = row.CreateCell(29);
        cell.SetCellValue(PrognozaTrzaskowski);
        cell = row.CreateCell(30);
        cell.SetCellValue(PrognozaNawrocki);
    }
}