namespace $safeprojectname$.Models
{
  public class Status
  {
    public bool Success { get; set; }
    public string Message { get; set; }

    public Status() { }

    private Status(bool success, string message)
    {
      Success = success;
      Message = message;
    }

    public static Status Empty() => new Status(false, string.Empty);

    public static Status Apply(bool success, string message) => new Status(success, message);

  }
}
