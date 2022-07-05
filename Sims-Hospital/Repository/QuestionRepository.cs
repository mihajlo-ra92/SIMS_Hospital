/// File:    QuestionRepository.cs
// Author:  Asus
// Created: 9 May, 2022 04:26:24
// Purpose: Definition of Class QuestionRepository

using FileHandler;
using Model;
using Sims_Hospital.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class QuestionRepository
    {
        private QuestionFileHandler QuestionFileHandler = new QuestionFileHandler();
        public List<Question> questions;


        public QuestionRepository()
        {
            questions = QuestionFileHandler.Read();
        }

        public List<Question> ReadAll()
        {
            return questions;
        }

        public Question ReadById(int questionId)
        {
            return questions.Where(x => x.Id == questionId).FirstOrDefault();
        }
        
        public List<Question> ReadByQuestionType(QuestionType questionType)
        {
            return questions.Where(x => x.TypeOfQuestion == questionType).ToList();
        }

        private List<Question> MakeListForHospitalEvaluation(List<Question> serviceQuestion, List<Question> cleanlinessQuestion)
        {
            List<Question> list = new List<Question>();
            foreach (Question question in serviceQuestion)
            {
                list.Add(question);
            }
            foreach (Question question in cleanlinessQuestion)
            {
                list.Add(question);
            }
            return list;
        }


        public List<Question> ReadAllForHospital()
        {
            List<Question> serviceQuestion = ReadAllServiceQuestion();
            List<Question> cleanlinessQuestion = ReadAllCleanlinessQuestion();
            return MakeListForHospitalEvaluation(serviceQuestion, cleanlinessQuestion);


        }
        public List<Question> ReadAllServiceQuestion()
        {
            return questions.Where(x => x.TypeOfQuestion == QuestionType.service).ToList();
        }
        public List<Question> ReadAllCleanlinessQuestion()
        {
            return questions.Where(x => x.TypeOfQuestion == QuestionType.cleanliness).ToList();
        }
        public List<Question> ReadAllForAppointment()
        {
            return questions.Where(x => x.TypeOfQuestion == QuestionType.apointment).ToList();
        }


    }
}
