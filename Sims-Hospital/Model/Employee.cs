// File:    Employee.cs
// Author:  stani
// Created: Monday, 28 March 2022 08:37:09
// Purpose: Definition of Class Employee

using Sims_Hospital.Utils;
using System;

namespace Model
{
    public class Employee : User
    {
        public decimal Salary { get; set; }

        public override void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Username = values[1];
                Password = values[2];
                Email = values[3];
                Name = values[4];
                LastName = values[5];
                //BirthDate = DateTime.Parse(values[6]);
                BirthDate = DateTime.ParseExact(values[6], "dd/MM/yyyy HH:mm:ss", null);
                Role = values[7];
                Salary = Convert.ToDecimal(values[8]);
            }
        }

        public override string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Username,
                Password,
                Email,
                Name,
                LastName,
                DateUtils.DateToString(BirthDate),
                Role,
                Salary.ToString()
            };
            return csvValues;
        }

    }
}