using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class MedicineNotificationController
    {
        public MedicineNotificationService medicineNotificationService;

        public MedicineNotificationController(MedicineNotificationService medicineNotificationService)
        {
            this.medicineNotificationService = medicineNotificationService;
        }
        public List<MedicineNotification> ReadAll()
        {
            return medicineNotificationService.ReadAll();
        }
        public MedicineNotification ReadById(int notificationId)
        {
            return medicineNotificationService.ReadById(notificationId);
        }
        public List<MedicineNotification> ReadByUserId(int userId)
        {
            return medicineNotificationService.ReadByUserId(userId);
        }

        public void Create(CreateMedicineNotificationDTO newNotification)
        {
            medicineNotificationService.Create(newNotification);
        }

        public void Edit(EditMedicineNotificationDTO editNotification)
        {
            medicineNotificationService.Edit(editNotification);
        }

        public void Delete(int notificationId)
        {
            medicineNotificationService.Delete(notificationId);
        }
    }
}
