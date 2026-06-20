namespace Infrastructure.Implementations.External.Gismeteo;

internal static class Consts
{
    public const string CityUrl = "https://services.gismeteo.ru/inform-service/inf_chrome/cities/?startsWith={0}&lang=ru";
    public const string ForecastUrl = "https://services.gismeteo.ru/inform-service/inf_chrome/forecast/?city={0}&lang=ru";
}
