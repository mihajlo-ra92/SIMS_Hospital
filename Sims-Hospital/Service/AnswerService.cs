// File:    AnswerService.cs
// Author:  Asus
// Created: 12 May, 2022 03:56:58
// Purpose: Definition of Class AnswerService

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AnswerService
    {
        public AnswerRepository answerRepository;
        public AnswerService(AnswerRepository AnswerRepository)
        {
            this.answerRepository = AnswerRepository;
        }
        public void Create(List<Answer> answers)
        {
            answerRepository.Create(answers);
        }

        public List<Answer> ReadAll()
        {
           return answerRepository.ReadAll();
        }


    }
}