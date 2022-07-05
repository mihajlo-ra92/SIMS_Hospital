using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class PrescriptionController
    {
        public PrescriptionService PrescriptionService;

        public PrescriptionController(PrescriptionService prescriptionService)
        {
            this.PrescriptionService = prescriptionService;
        }
        public void Create(CreatePrescriptionDTO newPerstcription)
        {
            PrescriptionService.Create(newPerstcription);
        }
        public void Edit(EditPrescriptionDTO editPrescription)
        {
            PrescriptionService.Edit(editPrescription);
        }
        public void Delete(int prescriptionId)
        {
            PrescriptionService.Delete(prescriptionId);
        }
        public List<Prescription> ReadAll()
        {
            return PrescriptionService.ReadAll();
        }
        public Prescription ReadById(int prescriptionId)
        {
            return PrescriptionService.ReadById(prescriptionId);
        }
        public List<Prescription> ReadByAppointmentId(int appointmentId)
        {
            return PrescriptionService.ReadByAppointmentId(appointmentId);
        }
        public bool AppointmentHasPrescription(int appointmentId)
        {
            return PrescriptionService.AppointmentHasPrescription(appointmentId);
        }
    }
}
