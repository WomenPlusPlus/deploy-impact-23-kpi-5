namespace KPI5.Domain.Entities;

public class ResultViewEntity<T>
{
    public ResultViewEntity(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }
    public ResultViewEntity(T data)
    {
        Data = data;
    }

    public ResultViewEntity(List<string> errors)
    {
        Errors = errors;
    }
    public ResultViewEntity(string error)
    {
        Errors.Add(error);
    }
    public T Data { get; private set; }
    public List<string> Errors { get; private set; } = new();
}
