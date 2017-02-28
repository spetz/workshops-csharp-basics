using System;
using Source.Models;

namespace Source.Services
{
    public class ActionHandler : IActionHandler
    {
        public Result<T> Handle<T>(Func<T> action, Action<Exception> onError = null) where T : class
        {
            try
            {
                Console.WriteLine("Executing action...");
                var result = action();

                return Result<T>.Success(result);
            }
            catch(Exception exception)
            {
                onError?.Invoke(exception);
                
                return Result<T>.Error(exception.Message);
            }
        }
    }
}