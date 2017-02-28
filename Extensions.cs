using System.Collections.Generic;
using Source.Models;

namespace Source
{
    public static class Extensions
    {
        public static T GetById<T>(this IEnumerable<T> values, int id) where T : Entity
        {
            foreach(T value in values)
            {
                if(value.Id == id)
                {
                    return value;
                }
            }
            return null;
        }
    }
}