using System;

namespace AdapterPattern
{

    // Concrete Adapter
    // Wariant klasowy
    public class MotorolaRadioClassAdapter : MotorolaRadio, IRadioAdapter
    {
        private readonly string pincode;

        public MotorolaRadioClassAdapter(string pincode)
        {
            this.pincode = pincode;
        }

        public void Send(byte channel, Message message)
        {
            PowerOn(pincode);
            SelectChannel(channel);
            Send(message.Content);
            PowerOff();
        }
    }

    // Concrete Adapter
    // Wariant obiektowy
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly MotorolaRadio radio;
        private readonly string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();
            this.pincode = pincode;
        }

        public void Send(byte channel, Message message)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message.Content);
            radio.PowerOff();
        }
    }

    public class MotorolaRadio
    {
        private bool enabled;

        private byte? selectedChannel;

        public MotorolaRadio()
        {
            enabled = false;
        }

        public void PowerOn(string pincode)
        {
            if (pincode == "1234")
            {
                enabled = true;
            }
        }

        public void SelectChannel(byte channel)
        {
            this.selectedChannel = channel;
        }

        public void Send(string message)
        {
            if (enabled && selectedChannel!=null)
            {
                Console.WriteLine($"<Xml><Send Channel={selectedChannel}><Message>{message}</Message></xml>");
            }
        }

        public void PowerOff()
        {
            enabled = false;
        }



    }
}
