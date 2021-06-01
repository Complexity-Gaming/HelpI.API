using System.ComponentModel;

namespace HelpI.API.Domain.Models.Application
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