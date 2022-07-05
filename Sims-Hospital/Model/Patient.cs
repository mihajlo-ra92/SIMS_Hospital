// File:    Patient.cs
// Author:  stani
// Created: Monday, 28 March 2022 15:32:44
// Purpose: Definition of Class Patient

using System;

namespace Model
{
    public class Patient : User
    {
        public bool IsGuest { get; set; }

        public Patient()
        {

        }
        public Patient(int id)
        {
            Id = id;
        }

        public override void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                IsGuest = bool.Parse(values[1]);
            }
        }

        public override string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IsGuest.ToString()
            };
            return csvValues;
        }
    }
}