// File:    LoggedInRepository.cs
// Author:  stani
// Created: Sunday, 17 April 2022 23:07:27
// Purpose: Definition of Class LoggedInRepository

using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class LoggedInRepository
    {
        public LoggedInUserFileHandler loggedInUserFileHandler;
        private List<LoggedInUser> loggedInUsers;

        public LoggedInRepository(LoggedInUserFileHandler loggedInFileHandler)
        {
            this.loggedInUserFileHandler = loggedInFileHandler;
            loggedInUsers = loggedInUserFileHandler.Read();
        }

        public List<LoggedInUser> ReadAll()
        {
            return loggedInUsers;
        }

        public LoggedInUser ReadByUserId(int userId)
        {
            return loggedInUsers.Where(x => x.User.Id == userId).DefaultIfEmpty(null).First();
        }

        public void Create(User user)
        {

            LoggedInUser loggedInUser = new LoggedInUser()
            {
                LoggedIn = true,
                User = user
            };

            loggedInUsers.Add(loggedInUser);

            loggedInUserFileHandler.Write(loggedInUsers);
        }

        public void Delete(int userId)
        {
            LoggedInUser user = loggedInUsers.Where(x => x.User.Id == userId).First();
            loggedInUsers.Remove(user);

            loggedInUserFileHandler.Write(loggedInUsers);
        }

    }
}