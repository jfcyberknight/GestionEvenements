using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RichardSzalay.MockHttp;
using Moq;

namespace FrontendTest.Evenements.Pages
{
    public class EvenementCreateTest
    {
        [Fact]
        public void NewEvenementShouldDisplaySuccessfully()
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
            var component = ctx.RenderComponent<Frontend.Evenements.Pages.EvenementCreate>();


            // Assert
            component.MarkupMatches("<h1>Événement</h1> <p>Planifier un événement</p> <form > <div class=\"mb-3\"> <label for=\"Nom\" class=\"form-label\">Nom</label> <input id=\"nom\" class=\"form-control valid\" > </div> <div class=\"mb-3\"> <label for=\"Description\" class=\"form-label\">Description</label> <input id=\"Description\" class=\"form-control valid\" > </div> <div class=\"mb-3\"> <label for=\"DateDebut\" class=\"form-label\">Date Début</label> <input type=\"date\" class=\"form-control valid\" value=\"\" > </div> <div class=\"mb-3\"> <label for=\"DateFin\" class=\"form-label\">Date Fin</label> <input type=\"date\" class=\"form-control valid\" value=\"\" > </div> <button type=\"submit\" class=\"btn btn-primary mb-3\"> Planifier </button> </form>");
        }

        [Fact]
        public void NewEvenementWithNoValuesShouldShowErrorMessage()
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
            var component = ctx.RenderComponent<Frontend.Evenements.Pages.EvenementCreate>();

            var buttonElement = component.Find("button");
            buttonElement.Click();


            // Assert
            component.MarkupMatches("<h1>Événement</h1> <p>Planifier un événement</p> <form > <ul class=\"validation-errors\"> <li class=\"validation-message\">Le nom est requis.</li> <li class=\"validation-message\">La description est requise.</li> <li class=\"validation-message\">La date de début est requise.</li> <li class=\"validation-message\">La date de fin est requise.</li> </ul> <div class=\"mb-3\"> <label for=\"Nom\" class=\"form-label\">Nom</label> <input id=\"nom\" aria-invalid=\"true\" class=\"form-control invalid\" > </div> <div class=\"mb-3\"> <label for=\"Description\" class=\"form-label\">Description</label> <input id=\"Description\" aria-invalid=\"true\" class=\"form-control invalid\" > </div> <div class=\"mb-3\"> <label for=\"DateDebut\" class=\"form-label\">Date Début</label> <input aria-invalid=\"true\" type=\"date\" class=\"form-control invalid\" value=\"\" > </div> <div class=\"mb-3\"> <label for=\"DateFin\" class=\"form-label\">Date Fin</label> <input aria-invalid=\"true\" type=\"date\" class=\"form-control invalid\" value=\"\" > </div> <button type=\"submit\" class=\"btn btn-primary mb-3\"> Planifier </button> </form>");
        }
    }
}
