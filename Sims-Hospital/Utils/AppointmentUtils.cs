using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_Hospital.Utils
{
    public class AppointmentUtils
    {
        public static AppointmentType ConvertStringToAppointmentType(string appointmentType)
        {
            if (appointmentType == "Operacija" || appointmentType == "Operation")
            {
                return AppointmentType.Operation;
            }
            return AppointmentType.CheckUp;
        }

        public static int ConvertAppointmentTypeToIndex(AppointmentType appointmentType)
        {
            if (appointmentType == AppointmentType.Operation)
            {
                return 0;
            }
            return 1;
        }
    }
}
