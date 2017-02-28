namespace Source.Models
{
    public class Result<T> where T : class
    {
        public T Value { get; }
        public string ErrorMessage { get; }
        public bool IsSuccessful => Value != null;

        protected Result(T value)
        {
            Value = value;
        }

        protected Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => new Result<T>(value);
        public static Result<T> Error(string errorMessage) => new Result<T>(errorMessage);
    }
}