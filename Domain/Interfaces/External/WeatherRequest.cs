namespace Domain.Interfaces.External;

public record WeatherRequest(int CityId)
{
    private const string _template = "https://services.gismeteo.ru/inform-service/inf_chrome/forecast/?city={0}&lang={1}";

    public string Language { private get; set; } = "ru";

    public string Url => string.Format(_template, CityId, Language);
}
