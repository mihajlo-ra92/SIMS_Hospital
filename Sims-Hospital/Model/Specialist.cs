// File:    Specialist.cs
// Author:  stani
// Created: Friday, 8 April 2022 18:35:18
// Purpose: Definition of Class Specialist

using System;

namespace Model
{
    public class Specialist : Doctor
    {
        public string Specialization { get; set; }

        public Specialist()
        {

        }
        public Specialist(int id)
        {
            Id = id;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Specialization = values[1];
            }
        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Specialization,
            };
            return csvValues;
        }
    }
}