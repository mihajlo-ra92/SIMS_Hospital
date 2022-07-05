// File:    AnswerRepository.cs
// Author:  Asus
// Created: 12 May, 2022 03:42:08
// Purpose: Definition of Class AnswerRepository

using FileHandler;
using System;
using Model;
using System.Collections.Generic;

namespace Repository
{
    public class AnswerRepository
    {
        public AnswerFileHandler AnswerFileHandler = new AnswerFileHandler();
        public List<Answer> Answers;

        public AnswerRepository()
        {
            Answers = AnswerFileHandler.Read();
        }
        public void Create(List<Answer> answers)
        {
           foreach(Answer answer in answers)
            {
                Answers.Add(answer);
            }
            AnswerFileHandler.Write(Answers);
        }

        public List<Answer> ReadAll()
        {
            return Answers;
        }


    }
}