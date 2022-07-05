// File:    LoggedInUserFileHandler.cs
// Author:  stani
// Created: Sunday, 17 April 2022 22:15:15
// Purpose: Definition of Class LoggedInUserFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class LoggedInUserFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\loggedInUsers.csv";
        private static char DELIMITER = ',';

        public List<LoggedInUser> Read()
        {
            List<LoggedInUser> loggedInUsers = new List<LoggedInUser>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                LoggedInUser loggedIn = new LoggedInUser();
                loggedIn.fromCSV(csvValues);
                loggedInUsers.Add(loggedIn);
            }
            return loggedInUsers;
        }

        public void Write(List<LoggedInUser> users)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable loggedIn in users)
            {
                string line = string.Join(DELIMITER, loggedIn.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}