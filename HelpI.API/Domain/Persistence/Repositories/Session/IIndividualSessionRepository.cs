using HelpI.API.Domain.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Persistence.Repositories.Session
{
    public interface IIndividualSessionRepository
    {
        Task<IEnumerable<IndividualSession>> ListAsync();
        Task<IndividualSession> FindById(int id);
        void Remove(IndividualSession individualSession);
    }
}
