using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserNotification : ISerializable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public User User { get; set; }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Description = values[1].Replace(';', '\n');
                User = new User(int.Parse(values[2]));
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Description.Replace('\n', ';'),
                User.Id.ToString(),
            };
            return csvValues;
        }
    }
}
