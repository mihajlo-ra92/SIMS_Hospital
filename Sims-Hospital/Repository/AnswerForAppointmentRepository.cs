// File:    AnswerForAppointmentRepository.cs
// Author:  Asus
// Created: 13 May, 2022 04:22:51
// Purpose: Definition of Class AnswerForAppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AnswerForAppointmentRepository
    {
        public AnswerForAppointmentFileHandler AnswerForAppointmentFileHandler = new AnswerForAppointmentFileHandler();
        public List<AnswerForAppointment> AnswersForAppointment;

        public AnswerForAppointmentRepository()
        {
            AnswersForAppointment = AnswerForAppointmentFileHandler.Read();
        }
        public List<AnswerForAppointment> ReadAll()
        {
            return AnswersForAppointment;
        }

        public AnswerForAppointment ReadByAppointmentId(int AppointmentId)
        {
            return AnswersForAppointment.Where(x => x.Appointment.Id == AppointmentId).FirstOrDefault();
        } 
        public void Create(List<AnswerForAppointment> answersForAppointment)
        {
            foreach (AnswerForAppointment answer in answersForAppointment)
            {
                AnswersForAppointment.Add(answer);
            }
            AnswerForAppointmentFileHandler.Write(AnswersForAppointment);
        }

    }
}
