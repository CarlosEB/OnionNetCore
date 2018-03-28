using System;
using System.Collections.Generic;
using System.Linq;
using OnionNetCore.Core.DTOs;
using OnionNetCore.Core.Entities;
using OnionNetCore.Core.Interfaces.Repositories;
using OnionNetCore.Core.Interfaces.Services;
using OnionNetCore.Core.Interfaces.UnitOfWork;
using OnionNetCore.Core.Util;

namespace OnionNetCore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _uow;

        public UserService(IUserRepository userRepo, IUnitOfWork uow)
        {
            _userRepo = userRepo;
            _uow = uow;
        }

        public IEnumerable<UserResponse> GetUsers()
        {
            return AutoMapper.Mapper.Map<IEnumerable<UserResponse>>(_userRepo.GetAll());
        }

        public UserResponse GetUserById(string publicId)
        {
            var id = Convert.ToInt32(Encryption.Decrypt(publicId));
            var user = _userRepo.GetWhere(w => w.Id == id).FirstOrDefault();
            return user == null ? null : AutoMapper.Mapper.Map<UserResponse>(user);
        }

        public int InsertUser(UserRequest user)
        {            
            var newUser = AutoMapper.Mapper.Map<User>(user);
            newUser.CreatedAt = DateTime.Now;
            _userRepo.Create(newUser);
            _uow.Commit();

            return newUser.Id;
        }

        public bool UpdatetUser(string publicId, UserRequest user)
        {
            var id = Convert.ToInt32(Encryption.Decrypt(publicId));
            var retrievedUser = _userRepo.Details(id);
            if (retrievedUser == null)
                return false;

            retrievedUser.Address = user.Address;
            retrievedUser.Name = user.Name;
            retrievedUser.UpdatedAt = DateTime.Now;
            _userRepo.Edit(retrievedUser);
            _uow.Commit();

            return true;
        }

        public bool DeleteUser(string publicId)
        {
            var id = Convert.ToInt32(Encryption.Decrypt(publicId));
            var result = _userRepo.RemoveWhere(r => r.Id == id);
            if (!result) return false;
            _uow.Commit();

            return true;
        }
    }
}
