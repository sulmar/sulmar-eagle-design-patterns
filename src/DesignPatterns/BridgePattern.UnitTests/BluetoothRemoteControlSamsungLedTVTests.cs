using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class BluetoothRemoteControlSamsungLedTVTests
    {
        private ILedTV ledTV;
        private RemoteControl remoteControl;

        [TestInitialize]
        public void Init()
        {
            // Arrange
            ledTV = new SamsungLedTV();
            remoteControl = new BluetoothRemoteControl(ledTV);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Act
            remoteControl.SwitchOn();

            //
            Assert.IsTrue(ledTV.IsOn);
        }

        [TestMethod]
        public void SwitchOff_ShouldOnFalse()
        {
            // Act
            remoteControl.SwitchOff();

            // Assert
            Assert.IsFalse(ledTV.IsOn);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Act
            remoteControl.SetChannel(10);

            // Assert
            Assert.AreEqual(10, ledTV.CurrentChannel);
        }
    }
}
