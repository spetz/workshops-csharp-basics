using System;

namespace Source.Models
{
    public class Address
    {
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string ZipCode { get; protected set; }

        public Address(string city, string street, string zipCode)
        {
            if(string.IsNullOrWhiteSpace(city))
            {
                throw new Exception("City was not provided.");
            }
            if(string.IsNullOrWhiteSpace(street))
            {
                throw new Exception("Street was not provided.");
            }
            if(string.IsNullOrWhiteSpace(zipCode))
            {
                throw new Exception("Zip code was not provided.");
            }            
            City = city;
            Street = street;
            ZipCode = zipCode;
        }
    }
}