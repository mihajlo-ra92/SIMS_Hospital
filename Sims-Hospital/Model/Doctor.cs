// File:    Doctor.cs
// Author:  stani
// Created: Friday, 25 March 2022 20:58:09
// Purpose: Definition of Class Doctor

using System;

namespace Model
{
    public class Doctor : Employee
    {
        public bool isSpecialist { get; set; }
        public Doctor()
        {

        }
        public Doctor(int id)
        {
            Id = id;
        }
        public override void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Salary = int.Parse(values[1]);
                isSpecialist = bool.Parse(values[2]);

            }
        }
        public override string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Salary.ToString(),
                isSpecialist.ToString(),
            };
            return csvValues;
        }
    }
}