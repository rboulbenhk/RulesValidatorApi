using System.Collections.Generic;

public class ErrorResponse
{
    public IList<ErrorModel> Errors {get; set; } = new List<ErrorModel>();
}