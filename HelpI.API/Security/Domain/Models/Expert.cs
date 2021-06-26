using System;
using System.Collections.Generic;
using HelpI.API.Games.Domain.Models;
using HelpI.API.Session.Domain.Models;
using HelpI.API.Training.Domain.Models;

namespace HelpI.API.Security.Domain.Models
{
    public class Expert : Player
    {
        public Expert()
        {
        }
        public Expert(Player player)
        {
            this.Id = player.Id;
            this.Email = player.Email;
            this.Password = player.Password;
            this.PersonalProfile = new PersonalProfile(player.PersonalProfile.FirstName, player.PersonalProfile.LastName, player.PersonalProfile.Birthdate, player.PersonalProfile.ProfilePictureUrl);
            player.PersonalProfile = null;
            foreach (var application in player.ExpertApplications)
            {
                application.Player = this;
            }

            foreach (var assistedSession in player.AssistedSessions)
            {
                assistedSession.Player = this;
            }
            foreach (var training in player.PlayerTrainingMaterials)
            {
                this.PlayerTrainingMaterials.Add(new PlayerTrainingMaterial{PlayerId = this.Id, TrainingMaterialId = training.TrainingMaterialId});
            }
            this.TrainingMaterials = new List<TrainingMaterial>();
            this.GivenSessions = new List<IndividualSession>();
        }
        public ExpertProfile ExpertProfile { get; set; }
        public int GameId { get; set; }
        public GameModel Game { get; set; }
        public IList<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
        public IList<IndividualSession> GivenSessions { get; set; } = new List<IndividualSession>();
        public void UpdateExpertProfile(ExpertProfile profile)
        {
            this.ExpertProfile = profile;
        }

        public void SetGame(GameModel game)
        {
            this.GameId = game.Id;
            this.Game = game;
        }
    }
}

