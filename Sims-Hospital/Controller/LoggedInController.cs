// File:    LoggedInController.cs
// Author:  stani
// Created: Sunday, 17 April 2022 23:17:15
// Purpose: Definition of Class LoggedInController

using Dto;
using Exception;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class LoggedInController
    {
        public LoggedInService loggedInService;

        public LoggedInController(LoggedInService loggedInService)
        {
            this.loggedInService = loggedInService;
        }

        public List<LoggedInUser> ReadAll()
        {
            return loggedInService.ReadAll();
        }

        public LoggedInUser ReadByUserId(int userId)
        {
            return loggedInService.ReadByUserId(userId);
        }

        public void Create(UserLoginDTO userLogin)
        {
            try
            {
                loggedInService.Create(userLogin);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public void Delete(int userId)
        {
            loggedInService.Delete(userId);
        }

    }
}