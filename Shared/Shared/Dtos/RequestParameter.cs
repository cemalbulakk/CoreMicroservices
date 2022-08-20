namespace Shared.Dtos;

public class RequestParameter
{
    public RequestParameter(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }
    public int Skip { get; set; }
    public int Take { get; set; }
}