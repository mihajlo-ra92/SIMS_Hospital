// File:    GuestMedicalRecord.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:07:13
// Purpose: Definition of Class GuestMedicalRecord

using System;
using System.Collections.Generic;

namespace Model
{
    public class GuestMedicalRecord : ISerializable
    {
        public int Id { get; set; }
        public string Umcn { get; set; }
        public PatientAllergies Allergies { get; set; }
        public BloodType BloodType { get; set; }
        public Patient Patient { get; set; }

        public virtual void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Umcn = values[1];
                Allergies = new PatientAllergies(int.Parse(values[2]));
                BloodType = (BloodType)Enum.Parse(typeof(BloodType), values[3]);
                Patient = new Patient(int.Parse(values[4]));
            }

        }

        public virtual string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Umcn,
                Allergies.Id.ToString(),
                BloodType.ToString(),
                Patient.Id.ToString(),
            };
            return csvValues;
        }
    }
}