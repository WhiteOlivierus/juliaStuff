public class StringValidator : IValidator<string>
{
    public bool Validate(string value)
    {
        return !string.IsNullOrEmpty(value);
    }
}

public interface IValidator<T>
{
    bool Validate(T value);
}
