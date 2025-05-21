namespace GuiaTuristicaApp.Services;

public interface IAPIService
{
    Task<T?> GetAsync<T>(string endpoint);
}