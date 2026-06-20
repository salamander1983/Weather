namespace Domain.Interfaces.External;

public class CityRequest(string CityName)
{
    private const string _template = "https://services.gismeteo.ru/inform-service/inf_chrome/cities/?startsWith={0}&lang={1}";

    public string Name { get; set; }

    public string Language { private get; set; } = "ru";

    public string Url => string.Format(_template, CityName, Language);
}
