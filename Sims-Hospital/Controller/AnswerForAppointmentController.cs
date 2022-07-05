// File:    AnswerForAppointmentController.cs
// Author:  Asus
// Created: 13 May, 2022 05:05:47
// Purpose: Definition of Class AnswerForAppointmentController

using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class AnswerForAppointmentController
    {
        public AnswerForAppointmentService AnswerForAppointmentService;
        public AnswerForAppointmentController(AnswerForAppointmentService AnswerForAppointmentService)
        {
            this.AnswerForAppointmentService = AnswerForAppointmentService;
        }
        public List<AnswerForAppointment> ReadAll()
        {
            return AnswerForAppointmentService.ReadAll();
        }

        public Model.AnswerForAppointment ReadByAppointmentId(int AppointmentId)
        {
            return AnswerForAppointmentService.ReadByAppointmentId(AppointmentId);
        }

        public void Create(List<AnswerForAppointment> answerForAppointment)
        {
            AnswerForAppointmentService.Create(answerForAppointment);
        }

    }
}