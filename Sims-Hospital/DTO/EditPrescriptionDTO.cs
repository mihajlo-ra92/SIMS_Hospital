using Model;
using System;

namespace Dto
{
    public class EditPrescriptionDTO
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public Patient Patient { get; set; }
        public string Medicine { get; set; }
        public int Ammount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimesADay { get; set; }
    }
}
