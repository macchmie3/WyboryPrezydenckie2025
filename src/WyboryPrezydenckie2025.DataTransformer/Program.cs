using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WyboryPrezydenckie2025.DataTransformer.Interfaces;
using WyboryPrezydenckie2025.DataTransformer.Models;
using WyboryPrezydenckie2025.DataTransformer.Utils;

namespace WyboryPrezydenckie2025.DataTransformer;

class Program
{
    private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
        .Build();

    static void Main()
    {
        var graphAggregationRange = int.Parse(Configuration["Graphs.AggregationRange"]);

        var executingPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var directory = Path.GetDirectoryName(executingPath);

        var firstRoundResults = ReadInputDataFromFile<WynikPierwszaTura>(directory + "/tura1.csv");
        var secondRoundResults = ReadInputDataFromFile<WynikDrugaTura>(directory + "/tura2.csv");

        var allDataCalculated = new List<AnalizaObwodu>();
        var rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywan = new Dictionary<int, int>();
        var rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywan = new Dictionary<int, int>();

        for (int i = 0; i < firstRoundResults.Length; i++)
        {
            var firstRound = firstRoundResults[i];
            var secondRound = secondRoundResults[i];

            if ((bool.Parse(Configuration["PominTypObwodu.stały"]) && firstRound.TypObszaru == "stały") ||
                (bool.Parse(Configuration["PominTypObwodu.zakładLeczniczy"]) && firstRound.TypObszaru == "zakład leczniczy") ||
                (bool.Parse(Configuration["PominTypObwodu.domPomocySpołecznej"]) && firstRound.TypObszaru == "dom pomocy społecznej") ||
                (bool.Parse(Configuration["PominTypObwodu.aresztŚledczy"]) && firstRound.TypObszaru == "areszt śledczy") ||
                (bool.Parse(Configuration["PominTypObwodu.oddziałZewnętrznyAresztuŚledczego"]) && firstRound.TypObszaru == "oddział zewnętrzny aresztu śledczego") ||
                (bool.Parse(Configuration["PominTypObwodu.zakładKarny"]) && firstRound.TypObszaru == "zakład karny") ||
                (bool.Parse(Configuration["PominTypObwodu.oddziałZewnętrznyZakładuKarnego"]) && firstRound.TypObszaru == "oddział zewnętrzny zakładu karnego") ||
                (bool.Parse(Configuration["PominTypObwodu.domStudencki"]) && firstRound.TypObszaru == "dom studencki") ||
                (bool.Parse(Configuration["PominTypObwodu.zespółDomówStudenckich"]) && firstRound.TypObszaru == "zespół domów studenckich") ||
                (bool.Parse(Configuration["PominTypObwodu.statek"]) && firstRound.TypObszaru == "statek") ||
                (bool.Parse(Configuration["PominTypObwodu.zagranica"]) && firstRound.TypObszaru == "zagranica") ||
                int.Parse(Configuration["PominObwodyWPierwszejTurzeMniejszeNiz"]) > firstRound.GłosyWażne)
            {
                continue;
            }

            var dataRow = new AnalizaObwodu
            {
                NrKomisji = firstRound.NrKomisji ?? 0,
                Gmina = firstRound.Gmina,
                TerytGminy = firstRound.TerytGminy ?? 0,
                Powiat = firstRound.Powiat,
                TerytPowiatu = firstRound.TerytPowiatu ?? 0,
                Województwo = firstRound.Województwo,
                Siedziba = firstRound.Siedziba,
                TypObwodu = firstRound.TypObwodu,
                TypObszaru = firstRound.TypObszaru,
                Nawrocki1 = firstRound.Nawrocki ?? 0,
                Nawrocki2 = secondRound.Nawrocki ?? 0,
                Trzaskowski1 = firstRound.Trzaskowski ?? 0,
                Trzaskowski2 = secondRound.Nawrocki ?? 0,
                Bartoszewicz = firstRound.Bartoszewicz ?? 0,
                Biejat = firstRound.Biejat ?? 0,
                Braun = firstRound.Braun ?? 0,
                Hołownia = firstRound.Hołownia ?? 0,
                Jakubiak = firstRound.Jakubiak ?? 0,
                Maciak = firstRound.Maciak ?? 0,
                Mentzen = firstRound.Mentzen ?? 0,
                Senyszyn = firstRound.Senyszyn ?? 0,
                Stanowski = firstRound.Stanowski ?? 0,
                Woch = firstRound.Woch ?? 0,
                Zandberg = firstRound.Zandberg ?? 0,
                GłosyWażne1 = firstRound.GłosyWażne ?? 0,
                GłosyWażne2 = secondRound.GłosyWażne ?? 0
            };

            dataRow.WspolczynnikDlaNawrockiegoExitPoll =
                (dataRow.Nawrocki1 +
                dataRow.Bartoszewicz * 0.673 +
                dataRow.Biejat * 0.098 +
                dataRow.Braun * 0.925 +
                dataRow.Hołownia * 0.138 +
                dataRow.Jakubiak * 0.903 +
                dataRow.Maciak * 0.729 +
                dataRow.Mentzen * 0.881 +
                dataRow.Senyszyn * 0.189 +
                dataRow.Stanowski * 0.512 +
                dataRow.Woch * 0.654 +
                dataRow.Zandberg * 0.162) / dataRow.GłosyWażne1;

            dataRow.WspolczynnikDlaTrzaskowskiegoExitPoll = 1 - dataRow.WspolczynnikDlaNawrockiegoExitPoll;

            dataRow.PrognozaNawrocki = (int)Math.Round(dataRow.GłosyWażne2 * dataRow.WspolczynnikDlaNawrockiegoExitPoll);
            dataRow.PrognozaTrzaskowski = dataRow.GłosyWażne2 - dataRow.PrognozaNawrocki;

            allDataCalculated.Add(dataRow);

            var rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywanRounded = (dataRow.Trzaskowski2 - dataRow.PrognozaTrzaskowski).RoundToNearestInterval(graphAggregationRange);
            
            if (rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywan.ContainsKey(rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywanRounded))
            {
                rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywan[rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywanRounded] += 1;
            }
            else
            {
                rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywan[rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywanRounded] = 1;
            }

            var rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywanRounded = (dataRow.Nawrocki2 - dataRow.PrognozaNawrocki).RoundToNearestInterval(graphAggregationRange);

            if (rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywan.ContainsKey(rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywanRounded))
            {
                rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywan[rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywanRounded] += 1;
            }
            else
            {
                rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywan[rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywanRounded] = 1;
            }
        }

        allDataCalculated = allDataCalculated.ToList();

        IWorkbook workbook = new XSSFWorkbook();
        WriteDataIntoSheet(workbook, "Dane ogólne", allDataCalculated);
        WriteDataIntoSheet(workbook, "Roznice wzg przewidywan T", rozbieznoscGlosowNaTrzaskowskiegoWzgledemPrzewidywan.Select(kvp => new Roznice<int>
        {
            LiczbaObwodow = kvp.Value,
            Roznica = kvp.Key
        }).OrderBy(x => x.Roznica).ToList());

        WriteDataIntoSheet(workbook, "Roznice wzg przewidywan N", rozbieznoscGlosowNaNawrockiegoWzgledemPrzewidywan.Select(kvp => new Roznice<int>
        {
            LiczbaObwodow = kvp.Value,
            Roznica = kvp.Key
        }).OrderBy(x => x.Roznica).ToList());

        FileStream outputStream = new FileStream(Path.Combine(@"C:\Proj\WyboryPrezydenckie2025", "Output.xlsx"), FileMode.Create, FileAccess.Write);
        workbook.Write(outputStream);
        outputStream.Close();
    }

    private static void WriteDataIntoSheet<T>(IWorkbook workbook, string sheetName, List<T> data) where T : IDaneDoWykresu, new()
    {
        ISheet sheet = workbook.CreateSheet(sheetName);

        var headerRow = new T();
        headerRow.WriteTableHeaderToSheet(sheet);
        var index = 1;
        foreach (var dataRow in data)
        {
            dataRow.WriteRowToSheet(sheet, index);
            index++;
        }

        headerRow.SetColumnSize(sheet);
    }

    private static T[] ReadInputDataFromFile<T>(string filePath)
    {
        var data = new List<T>();
        using var streamReader = new StreamReader(filePath);
        using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        });
        while (csvReader.Read())
        {
            data.Add(csvReader.GetRecord<T>());
        }
        return data.ToArray();
    }
}