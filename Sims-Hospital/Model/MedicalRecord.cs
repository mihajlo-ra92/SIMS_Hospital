// File:    MedicalRecord.cs
// Author:  stani
// Created: Monday, 28 March 2022 13:09:06
// Purpose: Definition of Class MedicalRecord

using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicalRecord : GuestMedicalRecord, ISerializable
    {
    
        public string ParentName { get; set; }
        public Address Address { get; set; }
        public Patient Patient { get; set; }

        public override void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Umcn = values[1];
                Allergies = new PatientAllergies(int.Parse(values[2]));
                BloodType = (BloodType)Enum.Parse(typeof(BloodType), values[3]);
                ParentName = values[4];
                Address = new Address(values[5].Split(";"));
                Patient = new Patient(int.Parse(values[6]));
            }
        }

        public override string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Umcn,
                Allergies.Id.ToString(),
                BloodType.ToString(),
                ParentName,
                string.Join(";",Address.toCSV()),
                Patient.Id.ToString(),
            };
            return csvValues;
        }
    }
}