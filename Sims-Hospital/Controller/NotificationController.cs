using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class NotificationController
    {
        public NotificationService NotificationService;

        //public NotificationController(NotificationService notificationService)
        //{
        //    NotificationService = notificationService;
        //}
        //public void Create(CreateNotificationDTO newNotification)
        //{
        //    NotificationService.Create(newNotification);
        //}
        //public void Edit(EditNotificationDTO editNotification)
        //{
        //    NotificationService.Edit(editNotification);
        //}
        //public void Delete (int notificationId)
        //{
        //    NotificationService.Delete(notificationId);
        //}
        //public List<Notification> ReadAll()
        //{
        //    return NotificationService.ReadAll();
        //}
        //public Notification ReadById(int notificationId)
        //{
        //    return NotificationService.ReadById(notificationId);
        //}
    }
}
