using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HelpI.API.Application.Domain.Models;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Training.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpI.API.Security.Domain.Models
{
    public class Player
    {  
        public int Id { get; set; }
        public PersonalProfile PersonalProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<IndividualSession> AssistedSessions { get; set; } = new List<IndividualSession>();
        public IList<PlayerTrainingMaterial> PlayerTrainingMaterials { get; set; } = new List<PlayerTrainingMaterial>();
        public IList<ExpertApplication> ExpertApplications { get; set; } = new List<ExpertApplication>();

        public void AddApplication(ExpertApplication application)
        {
            this.ExpertApplications.Add(application);
        }
    }
}
