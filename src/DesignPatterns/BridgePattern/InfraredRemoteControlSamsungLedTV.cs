using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class InfraredRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class AppRemoteControlSamsungLedTV
    {

    }

    public class InfraredRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            IsSwitchOn = true; 
            Console.WriteLine("Sony: Switch On");
            
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");            
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            IsSwitchOn = true;
            Console.WriteLine("Sony: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }

    public class AppRemoteControlSonyLedTV
    {

    }


    // Abstract Feature
    public abstract class RemoteControl
    {
        // Implementor
        protected ILedTV device;

        protected RemoteControl(ILedTV device)
        {
            this.device = device;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(byte number);
    }

    // Refined Abstraction
    public class BluetoothRemoteControl : RemoteControl
    {
        public BluetoothRemoteControl(ILedTV device) : base(device)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            device.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            device.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            device.SwitchOn();
        }
    }

    // Refined Abstraction
    public class InfraredRemoteControl : RemoteControl
    {
        public InfraredRemoteControl(ILedTV device) : base(device)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            device.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            device.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            device.SwitchOn();
        }
    }

    // Abstract Implementation (Implementor)
    public interface ILedTV
    {
        bool IsOn { get;  }
        byte CurrentChannel { get; }

        void SwitchOn();
        void SwitchOff();
        void SetChannel(byte number);
    }

    public class SonyLedTV : ILedTV
    {
        public bool IsOn { get; private set; }

        public byte CurrentChannel { get; private set; }

        public void SetChannel(byte number)
        {
            CurrentChannel = number;
            Console.WriteLine($"Sony: set channel {number}");
        }

        public void SwitchOff()
        {
            IsOn = false;
            Console.WriteLine("Sony: switch off");
        }

        public void SwitchOn()
        {
            IsOn = true;
            Console.WriteLine("Sony: switch on");
        }
    }

    public class SamsungLedTV : ILedTV
    {
        public bool IsOn { get; private set; }

        public byte CurrentChannel { get; private set; }

        public void SetChannel(byte number)
        {
            CurrentChannel = number;
            Console.WriteLine($"Samsung: set channel {number}");
        }

        public void SwitchOff()
        {
            IsOn = false;
            Console.WriteLine("Samsung: switch off");
        }

        public void SwitchOn()
        {
            IsOn = true;
            Console.WriteLine("Samsung: switch on");
        }
    }
}
