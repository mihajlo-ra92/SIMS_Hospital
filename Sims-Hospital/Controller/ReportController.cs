using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ReportController
    {
        public ReportService ReportService;
        public ReportController(ReportService reportService)
        {
            ReportService = reportService;
        }
        public void Create(CreateReportDTO newReport)
        {
            ReportService.Create(newReport);
        }
        public void Edit(EditReportDTO editReport)
        {
            ReportService.Edit(editReport);
        }
        public void Delete(int reportId)
        {
            ReportService.Delete(reportId);
        }
        public List<Report> ReadAll()
        {
            return ReportService.ReadAll();
        }
        public Report ReadById(int reportId)
        {
            return ReportService.ReadById(reportId);
        }
        public List<Report> ReadByAppointmentId(int appointmentId)
        {
            return ReportService.ReadByAppointmentId(appointmentId);
        }
        public bool AppointmentHasReport(int appointmentId)
        {
            return ReportService.AppointmentHasReport(appointmentId);
        }
    }
}
