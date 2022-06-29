using Backend.Evenements.Entities;
using Backend.Evenements.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Backend.Evenements.Controllers.Tests
{
    [TestClass()]
    public class EvenementsControllerTest
    {
        private Mock<IRepository<Evenement>> _mockRepo  = new Mock<IRepository<Evenement>>();

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

            // act
            var evenementsController = new EvenementsController(_mockRepo.Object);

            // assert
            Assert.IsNotNull(evenementsController);
        }


        [TestMethod()]
        public async Task GetEvenementsTest_ok()
        {
            // arrange
            IEnumerable<Evenement> evenements = new List<Evenement>
            {
                new Evenement(),
                new Evenement(),
                new Evenement()
            };

            //_mockRepo.Setup(p => p.GetAll()).Returns(Task.FromResult(evenements));
            _mockRepo.Setup(p => p.GetAll()).Returns(async () =>
            {                
                return evenements;
            });

            // act
            var evenementsController = new EvenementsController(_mockRepo.Object);
            var actionResult = await evenementsController.GetEvenements();


            // assert
            var result = actionResult.Result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, (result.Value as List<Evenement>).Count);

        }
    }
}