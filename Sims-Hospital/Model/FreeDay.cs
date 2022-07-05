using Controller;
using Sims_Hospital;
using Sims_Hospital.Utils;
using System;
using System.Windows;

namespace Model
{
    public class FreeDay : ISerializable
    {
        public int Id { get; set; }
        public Doctor Doctor{ get; set; }//mozda bude trebalo da se pretvori u Employee
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public bool IsEmergency { get; set; }
        public RequestStateType RequestState { get; set; }
        public String RequestStateString
        {
            get
            {
                var app = Application.Current as App;
                if (app.LanguageCode == "en")
                {
                    if (RequestState == RequestStateType.Accepted)
                    {
                        return "Accepted";
                    }
                    else if (RequestState == RequestStateType.Waiting) {
                        return "Waiting";
                    }
                    return "Declined";
                }
                else
                {
                    if (RequestState == RequestStateType.Accepted)
                    {
                        return "Prihvaćen";
                    }
                    else if (RequestState == RequestStateType.Waiting)
                    {
                        return "Čeka se";
                    }
                    return "Odbijen";
                }
            }
        }
        public string DecisionNote { get; set; }
        
        public FreeDay()
        {
        }
        public FreeDay(int id)
        {
            Id = id;
        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Doctor = new Doctor(int.Parse(values[1]));
                StartDate = DateTime.ParseExact(values[2], "dd/MM/yyyy HH:mm:ss", null);
                EndDate = DateTime.ParseExact(values[3], "dd/MM/yyyy HH:mm:ss", null);
                Note = values[4];
                IsEmergency = bool.Parse(values[5]);
                RequestState = (RequestStateType)Enum.Parse(typeof(RequestStateType), values[6]);
                DecisionNote = values[7];
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Doctor.Id.ToString(),
                DateUtils.DateToString(StartDate),
                DateUtils.DateToString(EndDate),
                Note,
                IsEmergency.ToString(),
                RequestState.ToString(),
                DecisionNote,
            };
            return csvValues;
        }
    }
}
