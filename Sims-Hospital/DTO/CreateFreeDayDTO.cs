using Model;
using System;

namespace Dto
{
    public class CreateFreeDayDTO
    {
        public Doctor Doctor { get; set; }//mozda bude trebalo da se pretvori u Employee
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public bool IsEmergency { get; set; }
        public RequestStateType RequestState { get; set; }
        public string DecisionNote { get; set; }
    }
}
