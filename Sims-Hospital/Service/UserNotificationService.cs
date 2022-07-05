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
    public class UserNotificationService
    {
        public UserNotificationRepository userNotificationRepository;
        public LoggedInService loggedInService;
        public UserService userService;

        public UserNotificationService(UserNotificationRepository userNotificationRepository, LoggedInService loggedInService, UserService userService)
        {
            this.userNotificationRepository = userNotificationRepository;
            this.loggedInService = loggedInService;
            this.userService = userService;
        }

        public List<UserNotification> ReadAll()
        {
            var notifications = userNotificationRepository.ReadAll();

            BindUsersWithNotifications(notifications);

            return userNotificationRepository.ReadAll();
        }

        private void BindUsersWithNotifications(List<UserNotification> notifications)
        {
            notifications.ForEach(notification =>
            {
                notification.User = userService.ReadById(notification.User.Id);
            });
        }


        public Model.UserNotification ReadById(int notificationId)
        {
            return userNotificationRepository.ReadById(notificationId);
        }

        public List<UserNotification> ReadByUserId(int userId)
        {
            return userNotificationRepository.ReadByUserId(userId);
        }

        public void Create(CreateNotificationDTO newNotification)
        {
            if (loggedInService.ReadByUserId(newNotification.User.Id) != null)
            {
                return;
            }else
            {
            userNotificationRepository.Create(newNotification);
            }

        }

        public void Edit(EditNotificationDTO editNotification)
        {
            userNotificationRepository.Edit(editNotification);
        }

        public void Delete(int notificationId)
        {
            userNotificationRepository.Delete(notificationId);
        }

        public void DeleteUserNotifications(int userId)
        {
            userNotificationRepository.DeleteUserNotifications(userId);
        }
    }
}
