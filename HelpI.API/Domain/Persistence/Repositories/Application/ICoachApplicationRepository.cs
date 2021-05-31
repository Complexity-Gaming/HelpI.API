using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Domain.Models.Application;

namespace HelpI.API.Domain.Persistence.Repositories.Application
{
    public interface ICoachApplicationRepository
    {
        Task<IEnumerable<CoachApplication>> ListAsync();
        Task<CoachApplication> FindById(int id);
        void Remove(CoachApplication coachApplication);
    }
}
