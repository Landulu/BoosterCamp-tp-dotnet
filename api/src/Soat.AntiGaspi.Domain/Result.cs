namespace Soat.AntiGaspi.Domain;

public record Result<T>
{
    public bool Success { get; }
    
    private readonly string _error;
    public string Error =>
        !Success ? 
            _error : 
            throw new InvalidOperationException("cannot get error of success result");
    
    private readonly T _value;
    public T Value => 
        Success? 
            _value : 
            throw new InvalidOperationException( "cannot get value of null result");

    public Result(string error)
    {
        _error = error;
        Success = false;
    }
    
    public Result(T value)
    {
        _value = value;
        Success = true;
    }
    
    
    
}