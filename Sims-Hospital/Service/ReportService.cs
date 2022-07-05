using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ReportService
    {
        public AppointmentRepository appointmentRepository;
        public ReportRepository reportRepository;

        public ReportService(ReportRepository reportRepository, AppointmentRepository appointmentRepository)
        {
            this.reportRepository = reportRepository;
            this.appointmentRepository = appointmentRepository;
            ReadAll();
        }
        public void Create(CreateReportDTO newReport)
        {
            reportRepository.Create(newReport);
        }
        public void Edit(EditReportDTO editReport)
        {
            reportRepository.Edit(editReport);
        }
        public void Delete(int reportId)
        {
            reportRepository.Delete(reportId);
        }
        public List<Report> ReadAll()
        {
            var appointments = appointmentRepository.ReadAll();
            var reports = reportRepository.ReadAll();
            BindAppointmentsWithReports(appointments, reports);
            return reportRepository.ReadAll();
        }
        public void BindAppointmentsWithReports(IEnumerable<Appointment> appointments, IEnumerable<Report> reports)
        {
            reports.ToList().ForEach(report =>
            {
                report.Appointment = FindAppointmentById(appointments, report.Appointment.Id);
            });
        }
        public Appointment FindAppointmentById(IEnumerable<Appointment> appointments, int id)
        {
            return appointments.SingleOrDefault(appointment => appointment.Id == id);
        }
        public Report ReadById(int reportId)
        {
            return reportRepository.ReadById(reportId);
        }
        public List<Report> ReadByAppointmentId(int appointmentId)
        {
            //proveravati posle ali msm da ne mora ponovo da se
            //cita i binduje
            var appointments = appointmentRepository.ReadAll();
            var reports = reportRepository.ReadAll();
            BindAppointmentsWithReports(appointments, reports);
            return reportRepository.ReadByAppointmentId(appointmentId);
        }
        public bool AppointmentHasReport(int appointmentId)
        {
            return reportRepository.AppointmentHasReport(appointmentId);
        }
    }
}
