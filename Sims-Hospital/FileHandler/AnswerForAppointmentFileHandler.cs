// File:    AnswerForAppointmentFileHandler.cs
// Author:  Asus
// Created: 17 April, 2022 22:15:15
// Purpose: Definition of Class AnswerForAppointmentFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class AnswerForAppointmentFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\answersForAppointments.csv";
        private static char DELIMITER = ',';

        public List<AnswerForAppointment> Read()
        {
            List<AnswerForAppointment> answers = new List<AnswerForAppointment>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    AnswerForAppointment answer = new AnswerForAppointment();
                    answer.fromCSV(csvValues);
                    answers.Add(answer);
                }
            }
            return answers;
        }

        public void Write(List<AnswerForAppointment> answers)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable answer in answers)
            {
                string line = string.Join(DELIMITER, answer.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}