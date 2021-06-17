﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;

namespace HelpI.API.Security.Domain.Persistence.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> ListAsync();
        Task AddAsync(Player player);
        Task<Player> FindById(int id);
        void Update(Player player);
        void Remove(Player player);
    }
}