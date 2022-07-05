using Dto;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserNotificationController
    {
        public Service.UserNotificationService userNotificationService;

        public UserNotificationController(UserNotificationService userNotificationService)
        {
            this.userNotificationService = userNotificationService;
        }
        public List<UserNotification> ReadByUserId(int userId)
        {
            return userNotificationService.ReadByUserId(userId);    
        }

        public List<UserNotification> ReadAll()
        {
            return userNotificationService.ReadAll();
        }

        public Model.UserNotification ReadById(int notificationId)
        {
            return userNotificationService.ReadById(notificationId);
        }

        public void Create(CreateNotificationDTO newNotification)
        {
            userNotificationService.Create(newNotification);
        }

        public void Edit(EditNotificationDTO editNotification)
        {
            userNotificationService.Edit(editNotification);
        }

        public void Delete(int notificationId)
        {
            userNotificationService.Delete(notificationId);
        }

        public void DeleteUserNotifications(int userId)
{
            userNotificationService.DeleteUserNotifications(userId);
        }

    }
}
