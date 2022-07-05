// File:    QuestionService.cs
// Author:  Asus
// Created: 9 May, 2022 05:09:42
// Purpose: Definition of Class QuestionService

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class QuestionService
    {
        public QuestionRepository questionRepository;

        public QuestionService(QuestionRepository QuestionRepository)
        {
            this.questionRepository = QuestionRepository;
        } 
        public List<Question> ReadAll()
        {
            return questionRepository.ReadAll();
        }

        public Question ReadById(int questionId)
        {
            return questionRepository.ReadById(questionId);
        }

        public List<Question> ReadByQuestionType(QuestionType questionType)
        {
            return questionRepository.ReadByQuestionType(questionType);
        }
        public List<Question> ReadAllForHospital()
        {
            return questionRepository.ReadAllForHospital();
        }
        public List<Question> ReadAllForAppointment()
        {
            return questionRepository.ReadAllForAppointment();
        }
    }
}