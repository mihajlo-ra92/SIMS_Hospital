// File:    Ansver.cs
// Author:  Asus
// Created: 9 May, 2022 03:27:05
// Purpose: Definition of Class Ansver

using System;

namespace Model
{
    public class Answer: ISerializable
    {
        public int Grade;

        public Patient Patient;
        public Question Question;

        
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Grade = int.Parse(values[0]);
                Patient = new Patient(int.Parse(values[1]));
                Question = new Question(int.Parse(values[2]));
            }
        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Grade.ToString(),
                Patient.Id.ToString(),
                Question.Id.ToString(),
            };
            return csvValues;
        }
    }
}