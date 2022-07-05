using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicineNotificationRepository
    {
        private List<MedicineNotification> medicineNotifications;
        public MedicineNotificationFileHandler notificationFileHandler;

        public MedicineNotificationRepository(MedicineNotificationFileHandler notificationFileHandler)
        {
            this.notificationFileHandler = notificationFileHandler;
            medicineNotifications = notificationFileHandler.Read();
        }
        public List<MedicineNotification> ReadAll()
        {
            return medicineNotifications;
        }
        public MedicineNotification ReadById(int notificationId)
        {
            return medicineNotifications.Where(x => x.Id == notificationId).First();
        }
        
        public List<MedicineNotification> ReadByUserId(int userId)
        {
            return medicineNotifications.Where(x => x.User.Id == userId).ToList();
        }
        public void Create(CreateMedicineNotificationDTO newNotification)
        {
            int id = 0;
            if (medicineNotifications.Count > 0)
            {
                id = medicineNotifications.Max(x => x.Id) + 1;
            }
            MedicineNotification medicineNotification = new MedicineNotification()
            {
                Id = id,
                Description = newNotification.Description,
                User = newNotification.User,
                NotificationTime = newNotification.NotificationTime,
            };
            medicineNotifications.Add(medicineNotification);
            notificationFileHandler.Write(medicineNotifications);
        }
        public void Edit(EditMedicineNotificationDTO editNotification)
        {
            MedicineNotification medicineNotification = medicineNotifications.Where(x => x.Id == editNotification.Id).First();
            medicineNotification.Description = editNotification.Description;
            medicineNotification.User = editNotification.User;
            medicineNotification.NotificationTime = editNotification.NotificationTime;

            notificationFileHandler.Write(medicineNotifications);
        }
        public void Delete(int id)
        {
            MedicineNotification medicineNotification = medicineNotifications.Where(x => x.Id == id).First();

            medicineNotifications.Remove(medicineNotification);
            notificationFileHandler.Write(medicineNotifications);
        }
    }
}
