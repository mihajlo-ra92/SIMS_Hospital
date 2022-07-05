using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class InvalidationRequestFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\invalidationRequests.csv";
        private static char DELIMITER = '|';

        public List<InvalidationRequest> Read()
        {
            List<InvalidationRequest> invalidationRequests = new List<InvalidationRequest>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    InvalidationRequest invalidationRequest = new InvalidationRequest();
                    invalidationRequest.fromCSV(csvValues);
                    invalidationRequests.Add(invalidationRequest);
                }
            }
            return invalidationRequests;
        }
        public void Write(List<InvalidationRequest> invalidationRequests)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable invalidationRequest in invalidationRequests)
            {
                string line = string.Join(DELIMITER, invalidationRequest.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
