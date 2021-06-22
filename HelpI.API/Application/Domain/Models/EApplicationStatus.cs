using System.ComponentModel;

namespace HelpI.API.Application.Domain.Models
{
    public enum EApplicationStatus
    {
        [Description("Passed")] 
        Passed = 1,
        [Description("Rejected")]
        Rejected = 2,
        [Description("Pending")]
        Pending = 3,
    }
}