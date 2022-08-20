namespace Shared.Dtos;

public class RequestParameter
{
    public RequestParameter(int skip = 0, int take = 10)
    {
        Skip = skip;
        Take = take;
    }

    public int Skip { get; set; }
    public int Take { get; set; }
}