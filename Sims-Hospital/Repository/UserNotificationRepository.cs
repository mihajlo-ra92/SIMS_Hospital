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
    public class UserNotificationRepository
    {
        private List<UserNotification> userNotifications;

        public NotificationFileHandler notificationFileHandler;

        public UserNotificationRepository(NotificationFileHandler notificationFileHandler)
        {
            this.notificationFileHandler = notificationFileHandler;
            userNotifications = notificationFileHandler.Read();
        }

        public List<UserNotification> ReadAll()
        {
            return userNotifications;
        }

        public Model.UserNotification ReadById(int notificationId)
        {
            return userNotifications.Where(x => x.Id == notificationId).First();
        }

        public List<UserNotification> ReadByUserId(int userId)
        {
            return userNotifications.Where(x => x.User.Id == userId).ToList();
        }

        public void Create(CreateNotificationDTO newNotification)
        {
            int id = 0;
            if (userNotifications.Count > 0)
            {
                id = userNotifications.Max(x => x.Id) + 1;
            }

            UserNotification userNotification = new UserNotification()
            {
                Id = id,
                Description = newNotification.Description,
                User = newNotification.User
            };

            userNotifications.Add(userNotification);

            notificationFileHandler.Write(userNotifications);
        }

        public void Edit(EditNotificationDTO editNotification)
        {
            UserNotification userNotification = userNotifications.Where(x => x.Id == editNotification.Id).First();

            userNotification.Description = editNotification.Description;
            userNotification.User = editNotification.User;

            notificationFileHandler.Write(userNotifications);
        }

        public void Delete(int id)
        {
            UserNotification userNotification = userNotifications.Where(x => x.Id == id).First();

            userNotifications.Remove(userNotification);

            notificationFileHandler.Write(userNotifications);
        }

        public void DeleteUserNotifications(int userId)
        {
            userNotifications.RemoveAll(x => x.User.Id == userId);

            notificationFileHandler.Write(userNotifications);
        }
    }
}
