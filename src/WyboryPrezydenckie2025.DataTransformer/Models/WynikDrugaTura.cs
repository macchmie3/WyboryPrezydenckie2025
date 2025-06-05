namespace WyboryPrezydenckie2025.DataTransformer.Models;

public class WynikDrugaTura
{
    public int? NrKomisji { get; set; }
    public string Gmina { get; set; }
    public int? TerytGminy { get; set; }
    public string Powiat { get; set; }
    public int? TerytPowiatu { get; set; }
    public string Województwo { get; set; }
    public string Siedziba { get; set; }
    public string TypObwodu { get; set; }
    public string TypObszaru { get; set; }
    public int? KartyDoGłosowaniaPrzeGłosowaniem { get; set; }
    public int? WyborcyWSpisie { get; set; }
    public int? NiewykorzystaneKarty { get; set; }
    public int? WydaneKartyWLokalu { get; set; }
    public int? KartyWysłanePocztą { get; set; }
    public int? KartyWydaneWSumie { get; set; }
    public int? GłosyPrzezPełnomocnika { get; set; }
    public int? GłosyNaZaświadczenie { get; set; }
    public int? KopertyZwrotne { get; set; }
    public int? KopertyZwrotneBezOświadczenia { get; set; }
    public int? KopertyBezPodpisanegoOświadczenia { get; set; }
    public int? KopertyZwrotneBezKarty { get; set; }
    public int? KoperytyZwrotneNiezaklejone { get; set; }
    public int? KopertyZwrotneWUrnie { get; set; }
    public int? KartyWyjęteZUrny { get; set; }
    public int? KartyWyjęteZUrnyKoperty { get; set; }
    public int? KartyNiewazne { get; set; }
    public int? KartyWazne { get; set; }
    public int? GłosyNieważne { get; set; }
    public int? GłosyNieważneZaDuzoX { get; set; }
    public int? GłosyNieważneBrakX { get; set; }
    public int? GłosyWażne { get; set; }
    public int? Nawrocki { get; set; }
    public int? Trzaskowski { get; set; }
}