using HelpI.API.Application.Domain.Models;
using HelpI.API.SeedWork.Communications;

namespace HelpI.API.Application.Domain.Services.Communications
{
    public class ExpertApplicationResponse : BaseResponse<ExpertApplication>
    {
        public ExpertApplicationResponse(ExpertApplication resource) : base(resource)
        {
        }

        public ExpertApplicationResponse(string message) : base(message)
        {
        }
    }
}
