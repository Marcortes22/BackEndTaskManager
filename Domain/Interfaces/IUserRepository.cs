﻿using Domain.Entities;
using Domain.Interfaces.IPatternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepostory<User,string>
    {
        Task<User> GetUserWithTaskListsAsync(string sub);

        Task<string> GetUserTimeZone(string sub);


    }
}
