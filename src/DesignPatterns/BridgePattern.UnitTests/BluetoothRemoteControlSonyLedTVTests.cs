using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    
    [TestClass]
    public class BluetoothRemoteControlSonyLedTVTests
    {
        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Arrange
            ILedTV ledTV = new SonyLedTV();
            RemoteControl remoteControl = new BluetoothRemoteControl(ledTV);

            // Act
            remoteControl.SwitchOn();

            //
            Assert.IsTrue(ledTV.IsOn);
        }

        [TestMethod]
        public void SwitchOff_ShouldOnFalse()
        {
            // Arrange
            ILedTV ledTV = new SonyLedTV();
            RemoteControl remoteControl = new BluetoothRemoteControl(ledTV);

            // Act
            remoteControl.SwitchOff();

            // Assert
            Assert.IsFalse(ledTV.IsOn);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Arrange
            ILedTV ledTV = new SonyLedTV();
            RemoteControl remoteControl = new BluetoothRemoteControl(ledTV);

            // Act
            remoteControl.SetChannel(10);

            // Assert
            Assert.AreEqual(10, ledTV.CurrentChannel);
        }
    }
}
