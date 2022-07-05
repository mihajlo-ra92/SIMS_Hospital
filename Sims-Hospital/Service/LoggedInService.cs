// File:    LoggedInService.cs
// Author:  stani
// Created: Sunday, 17 April 2022 23:14:11
// Purpose: Definition of Class LoggedInService

using Dto;
using Exception;
using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class LoggedInService
    {
        public LoggedInRepository loggedInRepository;
        public UserService userService;

        public LoggedInService(LoggedInRepository loggedInRepository, UserService userService)
        {
            this.loggedInRepository = loggedInRepository;
            this.userService = userService;
            ReadAll();
        }

        public List<LoggedInUser> ReadAll()
        {
            return loggedInRepository.ReadAll();
        }

        public LoggedInUser ReadByUserId(int userId)
        {
            return loggedInRepository.ReadByUserId(userId);
        }

        public void Create(UserLoginDTO userLogin)
        {
            User user = userService.ReadByUsername(userLogin.Username);

            if (user == null)
            {
                throw new UsernameNotExistsException("Username");
            }
            else if (user.Password != userLogin.Password)
            {
                throw new WrongPasswordException("Password");
            }
            
            LoggedInUser loggedInUser = loggedInRepository.ReadByUserId(user.Id);
            if (loggedInUser != null)
            {
                throw new UserAlreadyLoggedIn("Already Logged In");
            }
            loggedInRepository.Create(user);

        }

        public void Delete(int userId)
        {
            loggedInRepository.Delete(userId);
        }

    }
}