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
        Task AddAsync(IndividualSession session);
        Task<IEnumerable<IndividualSession>> ListByPlayerIdAsync(int playerId);
        Task<IEnumerable<IndividualSession>> ListByExpertIdAsync(int expertId);
        Task<IEnumerable<IndividualSession>> FindByPlayerIdAndExpertId(int playerId, int expertId);
        void Update(IndividualSession session);
        void Remove(IndividualSession session);
    }
}
