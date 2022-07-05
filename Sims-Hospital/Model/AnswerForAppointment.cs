// File:    AnswerForAppointment.cs
// Author:  Asus
// Created: 13 May, 2022 03:33:00
// Purpose: Definition of Class AnswerForAppointment

using System;

namespace Model
{
    public class AnswerForAppointment : ISerializable
    {
        public int Grade;
        public Appointment Appointment;
        public Question Question;

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Grade = int.Parse(values[0]);
                Appointment = new Appointment(int.Parse(values[1]));
                Question = new Question(int.Parse(values[2]));
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Grade.ToString(),
                Appointment.Id.ToString(),
                Question.Id.ToString(),
            };
            return csvValues;
        }
    }
}