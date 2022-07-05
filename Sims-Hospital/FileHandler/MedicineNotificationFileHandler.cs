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
    public class MedicineNotificationFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\medicineNotifications.csv";
        private static char DELIMITER = ',';

        public List<MedicineNotification> Read()
        {
            List<MedicineNotification> medicineNotifications = new List<MedicineNotification>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                MedicineNotification medicineNotification = new MedicineNotification();
                medicineNotification.fromCSV(csvValues);
                medicineNotifications.Add(medicineNotification);
            }
            return medicineNotifications;
        }
        public void Write(List<MedicineNotification> medicineNotifications)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable notification in medicineNotifications)
            {
                string line = string.Join(DELIMITER, notification.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
