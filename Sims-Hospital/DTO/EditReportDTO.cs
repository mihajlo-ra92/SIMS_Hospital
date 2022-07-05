using Model;
using System;

namespace Dto
{
    public class EditReportDTO
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string Content { get; set; }
    }
}
