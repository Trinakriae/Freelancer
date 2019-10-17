using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;

namespace Freelancer.Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
    }
}
