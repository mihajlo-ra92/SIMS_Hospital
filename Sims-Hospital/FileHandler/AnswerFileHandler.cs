// File:    AnswerFileHandler.cs
// Author:  Asus
// Created: 17 April, 2022 22:15:15
// Purpose: Definition of Class AnswerFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class AnswerFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\answers.csv";
        private static char DELIMITER = ',';

        public List<Answer> Read()
        {
            List<Answer> answers = new List<Answer>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Answer answer = new Answer();
                    answer.fromCSV(csvValues);
                    answers.Add(answer);
                }
            }
            return answers;
        }

        public void Write(List<Answer> answers)
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