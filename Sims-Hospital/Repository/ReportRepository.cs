using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ReportRepository
    {
        public ReportFileHandler ReportFileHandler = new ReportFileHandler();
        public List<Report> reports;
        public ReportRepository()
        {
            reports = ReportFileHandler.Read();
        }
        public List<Report> ReadAll()
        {
            return reports;
        }
        public Report ReadById(int reportId)
        {
            return reports.Where(x => x.Id == reportId).FirstOrDefault();
        }
        public List<Report> ReadByAppointmentId(int appointmentId)
        {
            return reports.Where(x => x.Appointment.Id== appointmentId).ToList();
        }
        public bool AppointmentHasReport(int appointmentId)
        {
            return reports.Any(x => x.Appointment.Id == appointmentId);
        }
        public void Create(CreateReportDTO NewReport)
        {
            Report report = new Report()
            {
                Id = reports.Count + 1,
                Appointment = NewReport.Appointment,
                Content = NewReport.Content,
            };
            reports.Add(report);
            ReportFileHandler.Write(reports);
        }
        public void Edit(EditReportDTO editReport)
        {
            Report report = reports.Where(x => x.Id == editReport.Id).First();
            report.Appointment = editReport.Appointment;
            report.Content = editReport.Content;
            ReportFileHandler.Write(reports);
        }
        public void Delete(int reportId)
        {
            var report = reports.Where(x => x.Id == reportId).FirstOrDefault();
            reports.Remove((Report)report);
            ReportFileHandler.Write(reports);
        }
        public void DeleteByAppointmentId(int appointmentId)
        {
            var report = reports.Where(x => x.Appointment.Id == appointmentId).FirstOrDefault();
            reports.Remove((Report)report);
            ReportFileHandler.Write(reports);
        }
    }
}
