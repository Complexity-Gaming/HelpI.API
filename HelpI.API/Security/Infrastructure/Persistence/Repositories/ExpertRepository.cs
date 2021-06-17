﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Security.Domain.Models;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Security.Infrastructure.Repositories
{
    public class ExpertRepository : BaseRepository, IExpertRepository
    {
        public ExpertRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Expert expert)
        {
            await _context.Experts.AddAsync(expert);
        }

        public async Task<Expert> FindById(int id)
        {
            return await _context.Experts.FindAsync(id);
        }

        public async Task<IEnumerable<Expert>> ListAsync()
        {
            return await _context.Experts.ToListAsync();
        }

        public void Remove(Expert expert)
        {
            _context.Experts.Remove(expert);
        }

        public void Update(Expert expert)
        {
            _context.Experts.Update(expert);
        }
    }
}