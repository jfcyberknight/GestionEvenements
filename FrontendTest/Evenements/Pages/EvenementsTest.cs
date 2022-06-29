using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RichardSzalay.MockHttp;
using Moq;

namespace FrontendTest.Evenements.Pages
{
    public class EvenementsTest
    {
        [Fact]
        public void WithNoEvenementShouldRendersSuccessfully()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new Bunit.TestContext();

            // Mock configuration
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"SectionName:SomeKey", "SectionValue"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            ctx.Services.AddSingleton(configuration);

            // Mock httpClient
            var mock = ctx.Services.AddMockHttpClient();
            var evenements = new List<Frontend.Evenements.Model.Evenement>();
            mock.When("/evenements").RespondJson(evenements.ToArray());

            // Act
            var component = ctx.RenderComponent<Frontend.Evenements.Pages.Evenements>();

            // Assert
            try
            {
                component.MarkupMatches(" <h1>Événements</h1> <p>Liste des événements planifiés</p> <p> <em>Chargement...</em> </p>");
            }
            catch (HtmlEqualException ex)
            {
                component.MarkupMatches("<h1>Événements</h1> <p>Liste des événements planifiés</p><table class=\"table\"><thead><tr><th>Nom</th> <th>Description</th> <th>Date de début</th> <th>Date de fin</th></tr></thead> <tbody><tr><td>Aucun événement</td> <td></td> <td></td> <td></td></tr></tbody></table>");
            }                        
        }

        [Fact]
        public void WithEvenementsShouldRendersSuccessfully()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new Bunit.TestContext();

            // Mock configuration
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"SectionName:SomeKey", "SectionValue"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            ctx.Services.AddSingleton(configuration);

            // Mock httpClient
            var mock = ctx.Services.AddMockHttpClient();
            var evenements = new List<Frontend.Evenements.Model.Evenement>();
            evenements.Add(new Frontend.Evenements.Model.Evenement()
            {
                Nom = "Event1",
                Description = "Description1",
                Datedebut = new DateTime(2015, 12, 31),
                Datefin = new DateTime(2015, 12, 31),
            });


            mock.When("/evenements").RespondJson(evenements.ToArray());

        // Act
        var component = ctx.RenderComponent<Frontend.Evenements.Pages.Evenements>();

            // Assert
            try
            {
                component.MarkupMatches(" <h1>Événements</h1> <p>Liste des événements planifiés</p> <p> <em>Chargement...</em> </p>");
            }
            catch (HtmlEqualException ex)
            {
                component.MarkupMatches("<h1>Événements</h1> <p>Liste des événements planifiés</p> <table class=\"table\"> <thead> <tr> <th>Nom</th> <th>Description</th> <th>Date de début</th> <th>Date de fin</th> </tr> </thead> <tbody> <tr> <td>Event1</td> <td>Description1</td> <td>2015-12-31</td> <td>2015-12-31</td> </tr> </tbody> </table>");
            }
    }
}
}
