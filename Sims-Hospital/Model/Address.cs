// File:    Address.cs
// Author:  stani
// Created: Friday, 8 April 2022 16:56:18
// Purpose: Definition of Class Address

using System;

namespace Model
{
    public class Address : ISerializable
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address()
        {

        }

        public Address(string[] address)
        {
            Street = address[0];
            StreetNumber = address[1];
            City = address[2];
            Country = address[3];
        }

        public override string ToString()
        {
            return Street + " " + StreetNumber + ", " + City + ", " + Country;
        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Street,
                StreetNumber,
                City,
                Country,
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Street = values[1];
                StreetNumber = values[2];
                City = values[3];
                Country = values[4];
            }
        }
    }
}