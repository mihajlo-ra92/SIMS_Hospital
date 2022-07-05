using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    public class NotificationFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\notifications.csv";
        private static char DELIMITER = ',';

        public List<UserNotification> Read()
        {
            List<UserNotification> userNotifications = new List<UserNotification>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                UserNotification userNotification = new UserNotification();
                userNotification.fromCSV(csvValues);
                userNotifications.Add(userNotification);
            }
            return userNotifications;
        }

        public void Write(List<UserNotification> userNotifications)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable notification in userNotifications)
            {
                string line = string.Join(DELIMITER, notification.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
