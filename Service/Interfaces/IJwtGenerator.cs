using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(AppUser user);
    }
}
