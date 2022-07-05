using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InvalidationRequest : ISerializable
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public string Note { get; set; }
        public RequestStateType RequestState { get; set; }

        public InvalidationRequest()
        {

        }
        public InvalidationRequest(int id)
        {
            Id = id;
        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Medicine = new Medicine(int.Parse(values[1]));
                Note = values[1];
                RequestState = (RequestStateType)Enum.Parse(typeof(RequestStateType), values[3]);
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Medicine.Id.ToString(),
                Note,
                RequestState.ToString(),
            };
            return csvValues;
        }
    }
}
