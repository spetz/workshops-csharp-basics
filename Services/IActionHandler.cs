using System;
using Source.Models;

namespace Source.Services
{
    public interface IActionHandler
    {
        Result<T> Handle<T>(Func<T> action, Action<Exception> onError = null) where T : class;
    }
}