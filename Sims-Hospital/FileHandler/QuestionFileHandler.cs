// File:    AppointmentFileHandler.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:22:31
// Purpose: Definition of Class AppointmentFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    internal class QuestionFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\questions.csv";
        private static char DELIMITER = '|';

        public List<Question> Read()
        {
            List<Question> questions = new List<Question>();

            foreach (var line in File.ReadLines(path))
            { 
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Question question = new Question();
                    question.fromCSV(csvValues);
                    questions.Add(question);
                }
            }

            return questions;
        }

        public void Write(List<Question> questions)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable question in questions)
            {
                string line = string.Join(DELIMITER, question.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}
