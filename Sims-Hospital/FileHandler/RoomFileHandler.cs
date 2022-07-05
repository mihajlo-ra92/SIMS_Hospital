// File:    RoomFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 15:41:50
// Purpose: Definition of Class RoomFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class RoomFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\rooms.csv";
        private static char DELIMITER = ',';
        public List<Room> Read()
        {
            List<Room> rooms = new List<Room>();
            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Room room = new Room();
                    room.fromCSV(csvValues);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public void Write(List<Room> rooms)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable room in rooms)
            {
                string line = string.Join(DELIMITER, room.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}