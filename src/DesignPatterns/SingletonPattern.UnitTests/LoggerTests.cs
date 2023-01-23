using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonPattern.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Create_CallTwice_ShouldBeTheSameInstance()
        {
            // Arrange

            // Act
            MessageService messageService = new MessageService(Logger.Instance);
            PrintService printService = new PrintService(Logger.Instance);

            // Assert
            Assert.AreSame(messageService._logger, printService._logger, "Different instances");

        }
    }
}
