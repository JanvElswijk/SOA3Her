using Moq;
using NUnit.Framework;

namespace AvansDevops.Test.Notifications
{
    [TestFixture]
    public class NotificationServiceTests
    {

        //----------AddNotificationAdapter----------
         [Test]
        public void AddNotificationAdapter_AddsNewAdapter()
        {
            // Arrange
            var adapter = new Mock<INotificationAdapter>();
            var service = new NotificationService(adapter.Object);

            // Act
            service.AddNotificationAdapter(adapter.Object);

            var user = new User("Jan", "jan@example.com", UserRole.Tester);
            var backlogItem = new BacklogItem("Test", "Testdesc", 3);
            service.Update(user, backlogItem, "Test message");

            // Assert
            adapter.Verify(a => a.SendNotification(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddNotificationAdapter_DoesNotAddDuplicateAdapters()
        {
          // Arrange
          var adapter = new Mock<INotificationAdapter>();
          var service = new NotificationService(adapter.Object);

          service.AddNotificationAdapter(adapter.Object); // Proberen dezelfde opnieuw toe te voegen

          var user = new User("Jan", "jan@example.com", UserRole.Tester);
          var backlogItem = new BacklogItem("Test", "Testdesc", 3);

          // Act
           service.Update(user, backlogItem, "Test message");

           // Assert
           adapter.Verify(a => a.SendNotification(It.IsAny<string>()), Times.Once);
        }

        //----------Update----------
        [Test]
        public void Update_CallsAdapter()
        {
            // Arrange
            var mockAdapter = new Mock<INotificationAdapter>();
            var service = new NotificationService(mockAdapter.Object);

            var user = new User("Jan", "jan@example.com", UserRole.Tester);

            var backlogItem = new BacklogItem("Test", "Testdesc", 3);

            // Act
            service.Update(user, backlogItem, "Test message");

            // Assert
            mockAdapter.Verify(a => a.SendNotification(It.Is<string>(s => s.Contains("Jan"))), Times.Once);


        }

        [Test]
        public void Update_CallsSendNotification_OnAllAdapters()
        {
            // Arrange
            var adapter1 = new Mock<EmailAdapter>();
            var adapter2 = new Mock<SlackAdapter>();
            var service = new NotificationService(adapter1.Object);
            service.AddNotificationAdapter(adapter2.Object);
 
            var user = new User("Jan", "jan@example.com", UserRole.Tester);

            var backlogItem = new BacklogItem("Test", "Testdesc", 3);

            // Act
            service.Update(user, backlogItem, "Test message");

            // Assert
            adapter1.Verify(a => a.SendNotification(It.Is<string>(s => s.Contains("Jan"))), Times.Once);
            adapter2.Verify(a => a.SendNotification(It.Is<string>(s => s.Contains("Jan"))), Times.Once);

        }


       
    }
}