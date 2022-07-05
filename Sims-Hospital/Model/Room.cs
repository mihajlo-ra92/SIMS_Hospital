// File:    Room.cs
// Author:  stani
// Created: Sunday, 3 April 2022 15:29:52
// Purpose: Definition of Class Room
using Controller;
using Sims_Hospital;
using Sims_Hospital.Utils;
using System;
using System.Windows;

namespace Model
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public String RoomTypeString
        {
            get
            {
                var app = Application.Current as App;
                {
                    if (app.LanguageCode == "sr")
                    {
                        if (RoomType == "Operation")
                        {
                            return "Operaciona soba";
                        }
                        else
                        {
                            return "Soba za pregled";
                        }
                    }
                    else
                    {
                        return RoomType;
                    }
                }
            }
        }

        public Room()
        {

        }
        public Room(int id)
        {
            Id = id;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                RoomName = values[1];
                RoomType = values[2];
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                RoomName,
                RoomType
            };
            return csvValues;
        }

    }
}