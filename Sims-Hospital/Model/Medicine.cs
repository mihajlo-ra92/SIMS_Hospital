using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sims_Hospital;

namespace Model
{
    public class Medicine : ISerializable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public bool IsValid { get; set; }
        public string Note { get; set; }

        public String IsValidString
        {
            get
            {
                var app = Application.Current as App;
                if (app.LanguageCode == "en")
                {
                    if (IsValid)
                    {
                        return "Valid";
                    }
                    return "Not valid";
                }
                else
                {
                    if (IsValid)
                    {
                        return "Validan";
                    }
                    return "Nije validan";
                }
                
            }
        }

        public Medicine(int id)
        {
            Id = id;
        }

        public Medicine(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public Medicine()
        {

        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Code = values[1];
                Name = values[2];
                Ingredients = new List<string>(values[3].Split(';'));
                IsValid = bool.Parse(values[4]);
                Note = values[5];
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Code,
                Name,
                string.Join(';', Ingredients.Select(x => x.ToString()).ToArray()),
                IsValid.ToString(),
                Note,
            };
            return csvValues;
        }
    }
}
