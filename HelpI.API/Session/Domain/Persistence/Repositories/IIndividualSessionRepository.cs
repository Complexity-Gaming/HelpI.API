using System.Collections.Generic;
using System.Threading.Tasks;
using HelpI.API.Session.Domain.Models;

namespace HelpI.API.Session.Domain.Repositories
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
