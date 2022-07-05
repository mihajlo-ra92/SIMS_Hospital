using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sims_Hospital;
using System;
using System.Windows;

namespace Model
{
    public class Question: ISerializable
    {
        public int Id;
        public QuestionType TypeOfQuestion;
        public string QuestionText;

        public Question()
        {

        }
        public Question(int id)
        {
            this.Id = id;
        }

        public Question(String QuestionText, QuestionType QuestionType,int Id)
        {
            this.QuestionText= QuestionText;
            this.TypeOfQuestion = QuestionType;
            this.Id= Id;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                TypeOfQuestion = (QuestionType) Enum.Parse(typeof(QuestionType),values[1]);
                QuestionText = values[2];
            }   
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                TypeOfQuestion.ToString(),
                QuestionText.ToString(),
            };
            return csvValues;
        }
    }
}
