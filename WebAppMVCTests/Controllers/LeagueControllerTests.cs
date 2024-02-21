using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net;
using WebAppMVC.Application.League;
using WebAppMVC.Application.League.Queries.GetAllLeagues;
using Xunit;

namespace WebAppMVC.Controllers.Tests
{
    public class LeagueControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public LeagueControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingLeague()
        {
            // arrange

            var league = new List<LeagueDto>()
            {
                new LeagueDto()
                {
                    
                    Name = "Brasilian"
                },

                new LeagueDto()
                {
                   
                    TeamNames = "French"
                },

                new LeagueDto()
                {
                    
                    TeamNames = "Albanian"
                }

            };

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLeaguesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(league);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object) ))
                .CreateClient();

            // act

            var response = await client.GetAsync("/League/Index");

            // assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            

            content.Should().Contain("<h1>Football Leagues</h1>")
               .And.Contain("Brasilian")
               .And.Contain("French")
               .And.Contain("Team3");


        }

        [Fact()]
        public async Task Index_ReturnsReturnsEmptyView_WhenNoLeaguesExist()
        {
            // arrange

            var league = new List<LeagueDto>();
           

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLeaguesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(league);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act

            var response = await client.GetAsync("/League/Index");

            // assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain("div class=\"card m-3\"");
        }

    }
}