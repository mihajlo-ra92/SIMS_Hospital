using Controller;
using Sims_Hospital;
using System;
using System.Windows;

namespace Model
{
    public class Notification : ISerializable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime NotificationTime { get; set; }
        public string NotificationContent { get; set; }
        public Notification()
        {
        }
        public Notification(int id)
        {
            Id = id;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                User = new User(int.Parse(values[1]));
                //NotificationTime = DateTime.Parse(values[5]);
                NotificationTime = DateTime.ParseExact(values[5], "dd/MM/yyyy HH:mm:ss", null);
                NotificationContent = values[6];
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                User.Id.ToString(),
                NotificationTime.ToString(),
                NotificationContent,
            };
            return csvValues;
        }
    }
}
