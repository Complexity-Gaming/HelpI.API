namespace HelpI.API.Application.Domain.Models
{
    public class ApplicationId
    {
        public ApplicationId()
        {
            
        }
        public ApplicationId(string expertApplicationId)
        {
            ExpertApplicationId = expertApplicationId;
        }
        public string ExpertApplicationId { get; private set; }
    }
}
