// File:    UserFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:44:09
// Purpose: Definition of Class UserFileHandler

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_Hospital.FileHandler
{
    public class UserFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\users.csv";
        private static char DELIMITER = ',';

        public List<User> Read()
        {
            List<User> users = new List<User>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    User user = new User();
                    user.fromCSV(csvValues);
                    users.Add(user);
                }
            }
            return users;
        }

        public void Write(List<User> users)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable user in users)
            {
                string line = string.Join(DELIMITER, user.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
