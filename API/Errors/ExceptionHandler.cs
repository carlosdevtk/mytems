namespace API.Errors
{
  public class ExceptionHandler : ErrorResponse
  {
    public ExceptionHandler(int statusCode, string message = null, string details = null) : base(statusCode, message)
    {
      Details = details;
    }

    public string Details { get; set; }
  }
}