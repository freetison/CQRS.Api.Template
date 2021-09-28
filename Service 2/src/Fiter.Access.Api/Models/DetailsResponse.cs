using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Models
{
  public class DetailsResponse<T>
  {
    [JsonProperty("status")]
    public Status Status { get; set; }
    [JsonProperty("data")]
    public T Data { get; set; }

    [JsonProperty("metadata")]
    List<KeyValuePair<string, object>> Metadata { get; set; }



    public DetailsResponse() { }

    public DetailsResponse(bool success, string msg, T results, List<KeyValuePair<string, object>> metadata = null)
    {
      Status = Status.Apply(success, msg);
      Data = results ?? default(T);
      Metadata = metadata ?? new List<KeyValuePair<string, object>>();
    }

    public DetailsResponse(bool state, T results, List<KeyValuePair<string, object>> metadata = null)
    {
      Status = state ? Status.Apply(true, "Successful") : Status.Apply(false, "Failed");
      Data = results ?? default(T);
      Metadata = metadata ?? new List<KeyValuePair<string, object>>();
    }

    public static DetailsResponse<T> Ok(T data) => new DetailsResponse<T>(true, data);

    public static DetailsResponse<T> Failed() => new DetailsResponse<T>(false, default);
    public static DetailsResponse<T> Failed(T data) => new DetailsResponse<T>(false, data);

    public static DetailsResponse<T> Failed(string message) => new DetailsResponse<T>(false, message, default);
  }
}
