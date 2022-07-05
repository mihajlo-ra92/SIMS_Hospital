using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicineNotificationService
    {
        public MedicineNotificationRepository medicineNotificationRepository;

        public MedicineNotificationService(MedicineNotificationRepository medicineNotificationRepository)
        {
            this.medicineNotificationRepository = medicineNotificationRepository;
        }
        public List<MedicineNotification> ReadAll()
        {
            var notifications = medicineNotificationRepository.ReadAll();
            return notifications;
        }
        public MedicineNotification ReadById(int notificationId)
        {
            return medicineNotificationRepository.ReadById(notificationId);
        }
        public List<MedicineNotification> ReadByUserId(int userId)
        {
            return medicineNotificationRepository.ReadByUserId(userId);
        }
        public void Create(CreateMedicineNotificationDTO newNotification)
        {
            medicineNotificationRepository.Create(newNotification);
        }

        public void Edit(EditMedicineNotificationDTO editNotification)
        {
            medicineNotificationRepository.Edit(editNotification);
        }

        public void Delete(int notificationId)
        {
            medicineNotificationRepository.Delete(notificationId);
        }
    }
}
