﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateNotificationDTO
    {
        public string Description { get; set; }
        public User User{ get; set; }
    }
}
