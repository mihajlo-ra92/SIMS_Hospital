using Dto;
using Model;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class NotificationService
    {
        public NotificationRepository NotificationRepository;
        public UserRepository UserRepository;

        //public NotificationService(NotificationRepository notificationRepository,
        //    UserRepository userRepository)
        //{
        //    this.NotificationRepository = notificationRepository;
        //    this.UserRepository = userRepository;
        //    //ReadAll();
        //}
        //public List<Notification> ReadAll()
        //{
        //    var users = UserRepository.ReadAll();
        //    var notifications = NotificationRepository.ReadAll();
        //    BindUsersWithNotifications(users, notifications);
        //    return NotificationRepository.ReadAll();
        //}
        //public void BindUsersWithNotifications(IEnumerable<User> users, IEnumerable<Notification> notifications)
        //{
        //    notifications.ToList().ForEach(notification =>
        //    {
        //        notification.User = FindUserById(users, notification.User.Id);
        //    });
        //}
        //public User FindUserById(IEnumerable<User> users, int id)
        //{
        //    return users.SingleOrDefault(user => user.Id == id);
        //}
        //public void Create(CreateNotificationDTO newNotification)
        //{
        //    NotificationRepository.Create(newNotification);
        //}
        //public void Edit(EditNotificationDTO editNotification)
        //{
        //    NotificationRepository.Edit(editNotification);
        //}
        //public void Delete(int notificationId)
        //{
        //    NotificationRepository.Delete(notificationId);
        //}
        //public Notification ReadById(int notificationId)
        //{
        //    return NotificationRepository.ReadById(notificationId);
        //}
    }
}
