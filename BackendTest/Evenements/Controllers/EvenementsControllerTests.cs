using Moq;
using Microsoft.EntityFrameworkCore;
using Backend.Evenements.Entities;
using BackendTest;

namespace Backend.Evenements.Controllers.Tests
{
    [TestClass()]
    public class EvenementsControllerTests
    {

        [TestMethod()]
        public void EvenementsControllerTest_ctorWithNull_notOk()
        {
            // arrange => act => assert
            Assert.ThrowsException<ArgumentNullException>(() => new EvenementsController(null));
        }

        [TestMethod()]
        public void EvenementsControllerTest_ctor_ok()
        {
            // arrange
            var mockContext = new Mock<MockEvenementsContextInMemory>();

            // act
            var evenementsController = new EvenementsController(mockContext.Object);

            // assert
            Assert.IsNotNull(evenementsController);
        }


        [TestMethod()]
        public async Task GetEvenementsTest_ok()
        {
            // arrange
            var options = new DbContextOptions<MockEvenementsContextInMemory>();            

            using (var context = new MockEvenementsContextInMemory(options))
            {
                context.Evenements.Add(new Evenement());
                context.Evenements.Add(new Evenement());
                context.Evenements.Add(new Evenement());
                context.SaveChanges();


                // act
                var evenementsController = new EvenementsController(context);
                var response = (await evenementsController.GetEvenements()).Value.ToList();

                // assert
                Assert.AreEqual(3, response.Count);
            }
        }
    }
}