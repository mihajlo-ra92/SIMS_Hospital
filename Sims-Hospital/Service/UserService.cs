using Dto;
using Exception;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        public UserRepository userRepository { get; set; }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            ReadAll();
        }

        public List<User> ReadAll()
        {
            return userRepository.ReadAll();
        }

        public User ReadById(int userId)
        {
            return userRepository.ReadById(userId);
        }

        public void Create(CreateUserDTO newUser)
        {
            userRepository.Create(newUser);
        }

        public void Edit(EditUserDTO editUser)
        {
            userRepository.Edit(editUser);
        }

        public void Delete(int userId)
        {
            userRepository.Delete(userId);
        }

        public User ReadByUsername(string username)
        {
            return userRepository.ReadByUsername(username);
        }
        public bool UsernameExists(string username)
        {
            return userRepository.UsernameExists(username);
        }
        public bool UserIsPatient(string username)
        {
            return userRepository.UserIsPatient(username);
        }

    }
}
