// File:    Patient.cs
// Author:  stani
// Created: Monday, 28 March 2022 15:32:44
// Purpose: Definition of Class Patient

namespace Model
{
    public interface ISerializable
    {
        public string[] toCSV();

        public void fromCSV(string[] values);
    }
}