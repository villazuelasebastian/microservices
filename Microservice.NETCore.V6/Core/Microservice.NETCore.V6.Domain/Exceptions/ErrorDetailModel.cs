using Newtonsoft.Json;

namespace Microservice.NETCore.V6.Domain.Exceptions;

[JsonObject(Title = "error")]
public class Error
{
    /// <summary>
    /// Código asociado
    /// </summary>
    /// <example>10025</example>
    [JsonProperty(PropertyName = "codigo")]
    public int Code { get; set; }

    /// <summary>
    /// Detalle
    /// </summary>
    /// <example></example>
    [JsonProperty(PropertyName = "detalle")]
    public string? Detail { get; set; }

    /// <summary>
    /// Origen
    /// </summary>
    /// <example>Spv.Sidom.DataAccess.CuentasVista</example>
    [JsonProperty(PropertyName = "origen")]
    public string? Source { get; set; }

    /// <summary>
    /// TrackId
    /// </summary>
    /// <example>0HM5LPIH804S1:00000001</example>
    [JsonProperty(PropertyName = "spvtrack_id")]
    public string? SpvTrackId { get; set; }

    /// <summary>
    /// Titulo
    /// </summary>
    /// <example>Ha ocurrido un error al obtener los balances de cuentas.</example>
    [JsonProperty(PropertyName = "titulo")]
    public string? Title { get; set; }
}

[JsonObject(Title = "detalle_error_model")]
public class ErrorDetailModel
{
    /// <summary>
    /// ErrorDetailModel
    /// </summary>
    public ErrorDetailModel()
    {
        Errors = new List<Error>();
    }

    /// <summary>
    /// Código del error HTTP (StatusCode)
    /// </summary>
    /// <example>500</example>
    [JsonProperty(PropertyName = "codigo")]
    public int Code { get; set; }

    /// <summary>
    /// Detalle del error asociado
    /// </summary>
    /// <example>Ha ocurrido un error al obtener los balances de cuentas.</example>
    [JsonProperty(PropertyName = "detalle")]
    public string? Detail { get; set; }

    /// <summary>
    /// Lista de errores
    /// </summary>
    [JsonProperty(PropertyName = "errores")]
    public List<Error> Errors { get; set; }

    /// <summary>
    /// Descripción del código de error HTTP
    /// </summary>
    /// <example>InternalServerError</example>
    [JsonProperty(PropertyName = "estado")]
    public string? State { get; set; }

    /// <summary>
    /// Tipo de error devuelto, valores posibles: negocio|tecnico
    /// </summary>
    /// <example>negocio</example>
    [JsonProperty(PropertyName = "tipo")]
    public string? Type { get; set; }
}