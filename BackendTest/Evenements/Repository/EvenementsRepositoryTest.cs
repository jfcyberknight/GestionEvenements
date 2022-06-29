using Backend.Evenements.Entities;
using Backend.Evenements.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Evenements.Repository
{
    [TestClass()]
    public class EvenementsRepositoryTest
    {

        [TestMethod()]
        public void EvenementsRepositoryTest_ctorWithNull_notOk()
        {
            // arrange => act => assert
            Assert.ThrowsException<ArgumentNullException>(() => new EvenementsRepository(null));
        }

        [TestMethod()]
        public void EvenementsRepositoryTest_ctor_ok()
        {
            // arrange
            var mockContext = new Mock<MockEvenementsContextInMemory>();

            // act
            var evenementsRepository = new EvenementsRepository(mockContext.Object);

            // assert
            Assert.IsNotNull(evenementsRepository);
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
                var evenementsRepository = new EvenementsRepository(context);
                var response = await evenementsRepository.GetAll();

                // assert
                Assert.IsNotNull(response);
                Assert.AreEqual(3, response.Count());
            }
        }
    }
}
