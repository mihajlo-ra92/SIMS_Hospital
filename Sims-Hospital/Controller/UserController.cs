// File:    UserController.cs
// Author:  stani
// Created: Saturday, 16 April 2022 16:47:49
// Purpose: Definition of Class UserController

using Dto;
using Exception;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class UserController
    {

        public UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public List<User> ReadAll()
        {
            return userService.ReadAll();
        }

        public User ReadById(int userId)
        {
            return userService.ReadById(userId);
        }

        public void Create(CreateUserDTO newUser)
        {
            userService.Create(newUser);
        }

        public void Edit(EditUserDTO editUser)
        {
            userService.Edit(editUser);
        }

        public void Delete(int userId)
        {
            userService.Delete(userId);
        }

        public User ReadByUsername(string username)
        {
            return userService.ReadByUsername(username);
        }
        public bool UsernameExists(string username)
        {
            return userService.UsernameExists(username);
        }
        public bool UserIsPatient(string username)
        {
            return userService.UserIsPatient(username);
        }
    }
}
