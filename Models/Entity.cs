using System;

namespace Source.Models
{
    public abstract class Entity
    {
        public int Id { get; }

        protected Entity(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Id must be greater than 0.");
            }
            Id = id;
        }
    }
}