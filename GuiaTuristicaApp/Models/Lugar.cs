using System.Text.Json.Serialization;

namespace GuiaTuristicaApp.Models;

public class Lugar
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [JsonPropertyName("imagen")]
    public Uri Imagen { get; set; }

    [JsonPropertyName("ubicacion")]
    public string Ubicacion { get; set; }

    [JsonPropertyName("tipoLugarId")]
    public long TipoLugarId { get; set; }

    [JsonPropertyName("tipoLugar")]
    public object TipoLugar { get; set; }
}