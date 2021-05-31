using HelpI.API.Domain.Models.Application;
using HelpI.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Services.Application
{
    public interface ICoachApplicationService
    {
        Task<IEnumerable<CoachApplication>> ListAsync();
        Task<CoachApplicationRespose> GetByIdAsync(int id);
        Task<CoachApplicationRespose> DeleteAsync(int id);
    }
}
