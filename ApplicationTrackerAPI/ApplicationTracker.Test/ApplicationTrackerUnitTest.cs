using ApplicationTracker.Models;
using ApplicationTracker.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ApplicationTracker.Test
{
    public class ApplicationTrackerUnitTest
    {
        [Fact]
        public void Add_ApplicationObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Application();

            var context = new Mock<ApplicationContext>();
            var dbSetMock = new Mock<DbSet<Application>>();
            context.Setup(x => x.Set<Application>()).Returns(dbSetMock.Object);
            // dbSetMock.Setup(x => x.Add(It.IsAny<Application>())).Returns(testObject);

            // Act
            var repository = new RepositoryManager(context.Object);
            repository.TrackeRepository.CreateApplication(testObject);


            //Assert
            context.Verify(x => x.Set<Application>());
            dbSetMock.Verify(x => x.Add(It.Is<Application>(y => y == testObject)));
        }


        [Fact]
        public void GetAll_ApplicationObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Application() { ID = 1 };
            var testList = new List<Application>() { testObject };

            var dbSetMock = new Mock<DbSet<Application>>();
            dbSetMock.As<IQueryable<Application>>().Setup(x => x.Provider).Returns
                                                 (testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Application>>().Setup(x => x.Expression).
                                                 Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Application>>().Setup(x => x.ElementType).Returns
                                                 (testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Application>>().Setup(x => x.GetEnumerator()).Returns
                                                 (testList.AsQueryable().GetEnumerator());

            var context = new Mock<ApplicationContext>();
            context.Setup(x => x.Set<Application>()).Returns(dbSetMock.Object);

            // Act
            var repository = new RepositoryManager(context.Object);
            var result = repository.TrackeRepository.GetAllApplications();

            // Assert
            Assert.Equal(testList, result.ToList());
        }
    }
}