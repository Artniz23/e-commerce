namespace API.Errors;

public class ApiValidationErrorResponse : ApiResponse
{
    public ApiValidationErrorResponse() : base(400)
    {
    }
    
    public IEnumerable<char[]> Errors { get; set; }
}