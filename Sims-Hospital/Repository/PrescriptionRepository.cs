using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PrescriptionRepository
    {
        public PrescriptionFileHandler PrescriptionFileHandler = new PrescriptionFileHandler();
        public List<Prescription> prescriptions;
        public PrescriptionRepository()
        {
            prescriptions = PrescriptionFileHandler.Read();
        }
        public List<Prescription> ReadAll()
        {
            return prescriptions;
        }
        public Prescription ReadById(int prescriptionId)
        {
            return prescriptions.Where(x => x.Id == prescriptionId).FirstOrDefault();
        }
        public List<Prescription> ReadByAppointmentId(int appointmentId)
        {
            return prescriptions.Where(x => x.Appointment.Id == appointmentId).ToList();
        }
        public void Create(CreatePrescriptionDTO NewPrescription)
        {
            Prescription prescription = new Prescription()
            {
                Id = prescriptions.Count + 1,
                Appointment = NewPrescription.Appointment,
                Patient = NewPrescription.Patient,
                Medicine = NewPrescription.Medicine,
                Ammount = NewPrescription.Ammount,
                StartDate = NewPrescription.StartDate,
                EndDate = NewPrescription.EndDate,
                TimesADay = NewPrescription.TimesADay,
            };
            prescriptions.Add(prescription);
            PrescriptionFileHandler.Write(prescriptions);
        }
        public void Edit(EditPrescriptionDTO editPrescription)
        {
            Prescription prescription = prescriptions.Where(x => x.Id == editPrescription.Id).First();
            prescription.Appointment = editPrescription.Appointment;
            prescription.Patient = editPrescription.Patient;
            prescription.Medicine = editPrescription.Medicine;
            prescription.Ammount = editPrescription.Ammount;
            prescription.StartDate = editPrescription.StartDate;
            prescription.EndDate = editPrescription.EndDate;
            prescription.TimesADay = editPrescription.TimesADay;
            PrescriptionFileHandler.Write(prescriptions);
        }
        public void Delete(int prescriptionId)
        {
            var prescription = prescriptions.Where(x => x.Id == prescriptionId).FirstOrDefault();
            prescriptions.Remove((Prescription)prescription);
            PrescriptionFileHandler.Write(prescriptions);
        }
        public void DeleteByAppointmentId(int appointmentId)
        {
            var prescription = prescriptions.Where(x => x.Appointment.Id == appointmentId).FirstOrDefault();
            prescriptions.Remove((Prescription)prescription);
            PrescriptionFileHandler.Write(prescriptions);
        }
        public bool AppointmentHasPrescription(int appointmentId)
        {
            return prescriptions.Any(x => x.Appointment.Id == appointmentId);
        }

        public List<Prescription> ReadByPatientId(int id)
        {
            return prescriptions.Where(x => x.Patient.Id == id).ToList();
        }
    }
}
