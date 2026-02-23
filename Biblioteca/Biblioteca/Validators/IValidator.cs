namespace ConsoleApp1.Validators;

public interface IValidator<T>
{
    T Validate(T item);
}