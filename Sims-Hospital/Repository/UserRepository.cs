// File:    UserRepository.cs
// Author:  stani
// Created: Saturday, 16 April 2022 16:42:41
// Purpose: Definition of Class UserRepository

using Dto;
using Exception;
using Model;
using Sims_Hospital.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        public List<User> users;
        public UserFileHandler userFileHandler;

        public UserRepository(UserFileHandler userFileHandler)
        {
            this.userFileHandler = userFileHandler;
            users = userFileHandler.Read();
        }

        public List<User> ReadAll()
        {
            return users;
        }

        public User ReadById(int userId)
        {
            return (User)users.Where(x => x.Id == userId);
        }

        public void Create(CreateUserDTO newUser)
        {
            int id = 0;
            if (users.Count > 0)
            {
                id = users.Max(x => x.Id) + 1;
            }

            User user = new User()
            {
                Id = id,
                Username = newUser.Username,
                Password = newUser.Password,
                Email = newUser.Email,
                Name = newUser.Name,
                LastName = newUser.LastName,
                BirthDate = newUser.BirthDate,
                Gender = newUser.Gender,
            };
            users.Add(user);

            userFileHandler.Write(users);
        }

        public void Edit(EditUserDTO editUser)
        {
            User user = users.Where(x => x.Id == editUser.Id).First();

            user.Username = editUser.Username;
            user.Password = editUser.Password;
            user.Email = editUser.Email;
            user.Name = editUser.Name;
            user.LastName = editUser.LastName;
            user.BirthDate = editUser.BirthDate;
            user.Gender = editUser.Gender;

            userFileHandler.Write(users);
        }

        public void Delete(int userId)
        {
            User user = users.Where(x => x.Id == userId).First();
            users.Remove(user);

            userFileHandler.Write(users);
        }

        public User ReadByUsername(string username)
        {
            return users.Where(x => x.Username == username).First();
        }
        public bool UsernameExists(string username)
        {
            return users.Any(x => x.Username == username);
        }
        public bool UserIsPatient(string username)
        {
            foreach(User userIt in users)
            {
                if(userIt.Username == username & userIt.Role == "Patient")
                {
                    return true;
                }
            }
            return false;
        }

    }
}
