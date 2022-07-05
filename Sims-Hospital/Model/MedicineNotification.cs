using Sims_Hospital.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MedicineNotification : UserNotification, ISerializable
    {
        public DateTime NotificationTime { get; set; }
        public MedicineNotification()
        {

        }
        public MedicineNotification(int id)
        {
            Id = id;
        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Description = values[1].Replace(';', '\n');
                User = new User(int.Parse(values[2]));
                //NotificationTime = DateTime.Parse(values[3]);
                NotificationTime = DateTime.ParseExact(values[3], "dd/MM/yyyy HH:mm:ss", null);
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Description.Replace('\n', ';'),
                User.Id.ToString(),
                DateUtils.DateToString(NotificationTime),
            };
            return csvValues;
        }
    }
}
