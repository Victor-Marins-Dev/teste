namespace DesafiosTecnicosApi.Commons
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Data { get; private set; }
        public string? Error { get; private set; }

        public static Result<T> Success(T data)
            => new Result<T> { IsSuccess = true, Data = data };

        public static Result<T> Failure(string error)
            => new Result<T> { IsSuccess = false, Error = error };
    }
}
