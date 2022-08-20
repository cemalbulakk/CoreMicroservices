namespace Shared.Dtos;

public class NoContent
{
    public NoContent(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}