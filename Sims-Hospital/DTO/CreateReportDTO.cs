using Model;
using System;

namespace Dto
{
    public class CreateReportDTO
    {
        public Appointment Appointment { get; set; }
        public string Content { get; set; }
    }
}
