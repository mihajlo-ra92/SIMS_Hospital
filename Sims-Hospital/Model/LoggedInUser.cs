// File:    LoggedInUser.cs
// Author:  stani
// Created: Sunday, 17 April 2022 23:04:06
// Purpose: Definition of Class LoggedInUser

using System;

namespace Model
{
    public class LoggedInUser : ISerializable
    {
        public User User { get; set; }
        public bool LoggedIn { get; set; }

        public virtual void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                User = new User(int.Parse(values[0]));
                LoggedIn = bool.Parse(values[1]);
            }
        }

        public virtual string[] toCSV()
        {
            string[] csvValues =
            {
                    User.Id.ToString(),
                    LoggedIn.ToString(),
            };

            return csvValues;
        }
    }
}