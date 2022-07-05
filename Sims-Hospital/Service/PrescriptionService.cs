using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PrescriptionService
    {
        public AppointmentRepository AppointmentRepository;
        public PatientRepository PatientRepository;
        public PrescriptionRepository PrescriptionRepository;

        public PrescriptionService(PrescriptionRepository prescriptionRepository,
            AppointmentRepository appointmentRepository, PatientRepository patientRepository)
        {
            this.PrescriptionRepository = prescriptionRepository;
            this.AppointmentRepository = appointmentRepository;
            this.PatientRepository = patientRepository;
            ReadAll();
        }
        public List<Prescription> ReadAll()
        {
            var appointments = AppointmentRepository.ReadAll();
            var patients = PatientRepository.ReadAll();
            var prescriptions = PrescriptionRepository.ReadAll();
            BindAppoinmentsWithPrescriptions(appointments, prescriptions);
            BindPatientsWithPrescriptions(patients, prescriptions);
            return PrescriptionRepository.ReadAll();
        }
        public void BindAppoinmentsWithPrescriptions(IEnumerable<Appointment> appointments, IEnumerable<Prescription> prescriptions)
        {
            prescriptions.ToList().ForEach(prescription =>
            {
                prescription.Appointment = FindAppointmentById(appointments, prescription.Appointment.Id);
            });
        }
        public Appointment FindAppointmentById(IEnumerable<Appointment> appointments, int id)
        {
            return appointments.SingleOrDefault(appointment => appointment.Id == id);
        }
        public void BindPatientsWithPrescriptions(IEnumerable<Patient> patients, IEnumerable<Prescription> prescriptions)
        {
            prescriptions.ToList().ForEach(prescription =>
            {
                prescription.Patient = FindPatientById(patients, prescription.Patient.Id);
            });
        }
        private Patient FindPatientById(IEnumerable<Patient> patients, int id)
        {
            return patients.SingleOrDefault(patient => patient.Id == id);
        }
        public Prescription ReadById(int prescriptionId)
        {
            return PrescriptionRepository.ReadById(prescriptionId);
        }
        public List<Prescription> ReadByAppointmentId(int appointmentId)
        {
            return PrescriptionRepository.ReadByAppointmentId(appointmentId);
        }
        public void Create(CreatePrescriptionDTO newPrescription)
        {
            PrescriptionRepository.Create(newPrescription);
        }
        public void Edit(EditPrescriptionDTO editPrescription)
        {
            PrescriptionRepository.Edit(editPrescription);
        }
        public void Delete(int prescriptionId)
        {
            PrescriptionRepository.Delete(prescriptionId);
        }
        public bool AppointmentHasPrescription(int appointmentId)
        {
            return PrescriptionRepository.AppointmentHasPrescription(appointmentId);
        }
    }
}
