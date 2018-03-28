using System.Collections.Generic;
using OnionNetCore.Core.DTOs;

namespace OnionNetCore.Core.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UserResponse> GetUsers();

        UserResponse GetUserById(string publicId);

        int InsertUser(UserRequest user);

        bool UpdatetUser(string publicId, UserRequest user);

        bool DeleteUser(string publicId);
    }
}
