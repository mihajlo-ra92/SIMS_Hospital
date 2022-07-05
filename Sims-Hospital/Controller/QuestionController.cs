// File:    QuestionController.cs
// Author:  Asus
// Created: 9 May, 2022 05:15:38
// Purpose: Definition of Class QuestionController

using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
    public class QuestionController
    {
        public QuestionService questionService;

        public QuestionController(QuestionService QuestionService)
        {
            this.questionService = QuestionService;
        }
        public List<Question> ReadAll()
        {
            return questionService.ReadAll();
        }

        public Question ReadById(int questionId)
        {
            return questionService.ReadById(questionId);
        }

        public List<Question> ReadByQuestionType(QuestionType questionType)
        {
            return questionService.ReadByQuestionType(questionType);
        }
        public List<Question> ReadAllForHospital()
        {
            return questionService.ReadAllForHospital();
        }
        public List<Question> ReadAllForAppointmeent()
        {
            return questionService.ReadAllForAppointment();
        }
    }
}