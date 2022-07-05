using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class NotificationRepository
    {
        public NotificationFileHandler NotificationFileHandler = new NotificationFileHandler();
        public List<Notification> notifications;
        //public NotificationRepository()
        //{
        //    notifications = NotificationFileHandler.Read();
        //}
        //public List<Notification> ReadAll()
        //{
        //    return notifications;
        //}
        //public Notification ReadById(int notificationId)
        //{
        //    return notifications.Where(x =>x.Id == notificationId).FirstOrDefault();
        //}
        ////mozda bude trebalo read by user,timespan i content da bi uzeo pravu kada radimo edit
        ////jer ne mozemo samo da napravimo novu kada radimo edit
        //public void Create(CreateNotificationDTO NewNotification)
        //{
        //    Notification notification = new Notification()
        //    {
        //        Id = notifications.Count + 1,
        //        User = NewNotification.User,
        //        NotificationTime = NewNotification.NotificationTime,
        //        NotificationContent = NewNotification.NotificationContent,
        //    };
        //    notifications.Add(notification);
        //    NotificationFileHandler.Write(notifications);
        //}
        //public void Edit(EditNotificationDTO editNotification)
        //{
        //    Notification notification = notifications.Where(x => x.Id == editNotification.Id).First();
        //    notification.User = editNotification.User;
        //    notification.NotificationTime = editNotification.NotificationTime;
        //    notification.NotificationContent = editNotification.NotificationContent;
        //    NotificationFileHandler.Write(notifications);
        //}
        //public void Delete(int notificationId)
        //{
        //    var notification = notifications.Where(x => x.Id == notificationId).FirstOrDefault();
        //    notifications.Remove((Notification)notification);
        //    NotificationFileHandler.Write(notifications);
        //}
    }
}
