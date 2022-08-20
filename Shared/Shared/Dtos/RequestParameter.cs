namespace Shared.Dtos;

public abstract class RequestParameter
{
    protected RequestParameter(int skip = 0, int take = 10)
    {
        Skip = skip;
        Take = take == 0 ? 10 : take;
    }

    public int Skip { get; set; }
    public int Take { get; set; }
}