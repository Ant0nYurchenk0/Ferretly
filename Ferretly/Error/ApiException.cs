namespace Ferretly.Error
{
  public class ApiException
  {
    public ApiException(int statusCode, string message, string details)
    {
      Error = new Error(statusCode, message, details);
    }

    public Error Error { get; set; }
  }

}
