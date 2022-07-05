// File:    AnswerController.cs
// Author:  Asus
// Created: 12 May, 2022 04:03:39
// Purpose: Definition of Class AnswerController

using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class AnswerController
    {
        public AnswerService AnswerService;

        public AnswerController(AnswerService AnswerService)
        {
            this.AnswerService = AnswerService;
        }
        public void Create(List<Answer> answers)
        {
            AnswerService.Create(answers);
        }

        public List<Answer> ReadAll()
        {
            return AnswerService.ReadAll();
        }


    }
}