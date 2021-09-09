using System;

namespace API.Errors
{
  public class ErrorResponse
  {
    public ErrorResponse(int statusCode, string message = null)
    {
      StatusCode = statusCode;
      Message = message ?? DefaultMessage(statusCode);
    }


    public int StatusCode { get; set; }
    public string Message { get; set; }
    private string DefaultMessage(int statusCode)
    {
      return statusCode switch
      {
        400 => "Algo está errado com a sua requisição",
        401 => "Você não tem autorização",
        404 => "Conteúdo não encontrado",
        500 => "Houve um erro interno no servidor",
        _ => "Algo deu errado na requisição"
      };
    }
  }
}