﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetByEmail(string email);
    }
}
