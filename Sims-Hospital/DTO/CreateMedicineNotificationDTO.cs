using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class CreateMedicineNotificationDTO : CreateNotificationDTO
    {
        public DateTime NotificationTime { get; set; }
    }
}
