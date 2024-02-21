using Xunit;
using WebAppMVC.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using WebAppMVC.Application.ApplicationUser;
using WebAppMVC.Application.League;
using FluentAssertions;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.Match;
using WebAppMVC.Application.FavouriteTeamsUser;

namespace WebAppMVC.Application.Mappings.Tests
{
    public class LeagueMappingProfileTests
    {
        // LeagueDtoToLeague and LeagueToLeagueDto
        [Fact()]
        public void LeagueMappingProfile_ShouldMapLeagueDtoToLeague()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new LeagueDto
            {
                Name = "Brasilian",
                TeamNames = "Team1;Team2;Team3;Team4;Team5"
            };

            // act

            var result = mapper.Map<Domain.Entities.League>(dto);

            // assert

            result.Should().NotBeNull();
            result.Name.Should().NotBeNull();
            result.TeamNames.Should().NotBeNull();
        }

        [Fact()]
        public void LeagueMappingProfile_ShouldMapLeagueToLeagueDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new Domain.Entities.League
            {
                Name = "Brasilian",
                TeamNames = "Team1;Team2;Team3;Team4;Team5"
            };

            // act

            var result = mapper.Map<LeagueDto>(dto);

            // assert

            result.Should().NotBeNull();
            result.Name.Should().NotBeNull();
            result.TeamNames.Should().NotBeNull();
        }

        // FootballTeamDtoFootballTeam and FootballTeamToFootballTeamDto
        [Fact()]
        public void LeagueMappingProfile_FootballTeamDtoFootballTeam()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new FootballTeamDto
            {
                LeagueName = "Brasilian",
                Name = "Team1",
                MeetingsWon = 13,
                Points = 87,
                LeagueId = 6
            };

            // act

            var result = mapper.Map<Domain.Entities.FootballTeam>(dto);

            // assert

            result.Should().NotBeNull();
            result.Name.Should().NotBeNull();
            result.LeagueName.Should().NotBeNull();
            result.MeetingsWon.Should().BePositive();
            result.Points.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }

        [Fact()]
        public void LeagueMappingProfile_FootballTeamToFootballTeamDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new Domain.Entities.FootballTeam
            {
                LeagueName = "Brasilian",
                Name = "Team1",
                MeetingsWon = 13,
                Points = 87,
                LeagueId = 6
            };

            // act

            var result = mapper.Map<FootballTeamDto>(dto);

            // assert

            result.Should().NotBeNull();
            result.Name.Should().NotBeNull();
            result.LeagueName.Should().NotBeNull();
            result.MeetingsWon.Should().BePositive();
            result.Points.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }

        // MatchDtoMatch and MatchToMatchDto
        [Fact()]
        public void LeagueMappingProfile_MatchDtoMatch()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new MatchDto
            {
                NameFirstTeam = "Team1",
                NameSecondTeam = "Team2",
                QueueName = "First",
                QueueId = 1,
                Result = 1,
                GoalScore = "1 : 0",
                LeagueId = 1
            };

            // act

            var result = mapper.Map<Domain.Entities.Match>(dto);

            // assert

            result.Should().NotBeNull();
            result.NameFirstTeam.Should().NotBeNull();
            result.NameSecondTeam.Should().NotBeNull();
            result.QueueName.Should().NotBeNull();
            result.GoalScore.Should().NotBeNull();
            result.QueueId.Should().BePositive();
            result.Result.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }

        [Fact()]
        public void LeagueMappingProfile_MatchToMatchDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new Domain.Entities.Match
            {
                NameFirstTeam = "Team1",
                NameSecondTeam = "Team2",
                QueueName = "First",
                QueueId = 1,
                Result = 1,
                GoalScore = "1 : 0",
                LeagueId = 1
            };

            // act

            var result = mapper.Map<MatchDto>(dto);

            // assert

            result.Should().NotBeNull();
            result.NameFirstTeam.Should().NotBeNull();
            result.NameSecondTeam.Should().NotBeNull();
            result.QueueName.Should().NotBeNull();
            result.GoalScore.Should().NotBeNull();
            result.QueueId.Should().BePositive();
            result.Result.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }

        // FavouriteTeamsUserDtoToFavouriteTeamsUser and FavouriteTeamsUserToFavouriteTeamsUserDto
        [Fact()]
        public void LeagueMappingProfile_FavouriteTeamsUserDtoToFavouriteTeamsUser()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new FavouriteTeamsUserDto
            {
                FootballTeamName = "Team1",
                LeagueName = "Brasilian",
                MeetingsWon = 13,
                Points = 13,
                FootballTeamId = 13,
                LeagueId = 13
            };

            // act

            var result = mapper.Map<Domain.Entities.FavouriteTeamsUser>(dto);

            // assert

            result.Should().NotBeNull();
            result.FootballTeamName.Should().NotBeNull();
            result.LeagueName.Should().NotBeNull();
            result.MeetingsWon.Should().BePositive();
            result.Points.Should().BePositive();
            result.FootballTeamId.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }

        [Fact()]
        public void LeagueMappingProfile_FavouriteTeamsUserToFavouriteTeamsUserDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new LeagueMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new Domain.Entities.FavouriteTeamsUser
            {
                FootballTeamName = "Team1",
                LeagueName = "Brasilian",
                MeetingsWon = 13,
                Points = 13,
                FootballTeamId = 13,
                LeagueId = 13
            };

            // act

            var result = mapper.Map<FavouriteTeamsUserDto>(dto);

            // assert

            result.Should().NotBeNull();
            result.FootballTeamName.Should().NotBeNull();
            result.LeagueName.Should().NotBeNull();
            result.MeetingsWon.Should().BePositive();
            result.Points.Should().BePositive();
            result.FootballTeamId.Should().BePositive();
            result.LeagueId.Should().BePositive();
        }
    }
}