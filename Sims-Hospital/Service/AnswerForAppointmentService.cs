// File:    AnswerForAppointmentService.cs
// Author:  Asus
// Created: 13 May, 2022 04:49:20
// Purpose: Definition of Class AnswerForAppointmentService

using System;
using System.Collections.Generic;
using Model;
using Repository;

namespace Service
{
    public class AnswerForAppointmentService
    {
        public AnswerForAppointmentRepository AnswerForAppointmentRepository;
        public AnswerForAppointmentService(AnswerForAppointmentRepository AnswerForAppointmentRepository)
        {
            this.AnswerForAppointmentRepository = AnswerForAppointmentRepository;
        }
        public List<AnswerForAppointment> ReadAll()
        {
            return AnswerForAppointmentRepository.ReadAll();
        }

        public AnswerForAppointment ReadByAppointmentId(int AppointmentId)
        {
            return AnswerForAppointmentRepository.ReadByAppointmentId(AppointmentId);
        }

        public void Create(List<AnswerForAppointment> answerForAppointment)
        {
            AnswerForAppointmentRepository.Create(answerForAppointment);
        }

        public Repository.AnswerForAppointmentRepository answerForAppointmentRepository;

    }
}