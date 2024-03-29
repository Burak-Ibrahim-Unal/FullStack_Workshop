﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>, ISyncRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
