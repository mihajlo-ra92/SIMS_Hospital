// File:    User.cs
// Author:  stani
// Created: Monday, 28 March 2022 08:34:14
// Purpose: Definition of Class User

using Sims_Hospital.Utils;
using System;

namespace Model
{
    public class User : ISerializable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        public string Role { get; set; }

        public string NameLastName { get { return Name + " " + LastName; } }
        public User()
        {

        }
        public User(int id)
        {
            Id = id;
        }

        public virtual void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Username = values[1];
                Password = values[2];
                Email = values[3];
                Name = values[4];
                LastName = values[5];
                //BirthDate = DateTime.Parse(values[6]);
                BirthDate = DateTime.ParseExact(values[6], "dd/MM/yyyy HH:mm:ss", null);
                Gender = (Gender)Enum.Parse(typeof(Gender), values[7]);
                Role = values[8];
            }
        }

        public virtual string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Username,
                Password,
                Email,
                Name,
                LastName,
                DateUtils.DateToString(BirthDate),
                Gender.ToString(),
                Role,
            };
            return csvValues;
        }
    }
}