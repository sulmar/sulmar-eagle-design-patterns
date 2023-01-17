using System;

namespace AdapterPattern
{
    public class Message
    {
        public string Content { get; set; }
    }


    // Abstract Adapter
    public interface IRadioAdapter
    {
        void Send(byte channel, Message message);
    }

    // Concrete Adapter
    public class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(byte channel, Message message)
        {
            radio.Init();
            radio.SendMessage(channel, message.Content);
            radio.Release();
        }
    }

    public class HyteraRadio
    {

        private RadioStatus status = RadioStatus.Off;

        public void Init()
        {
            status = RadioStatus.On;
        }

        public void SendMessage(byte channel, string content)
        {
            if (status == RadioStatus.On)
            {
                Console.WriteLine($"CHANNEL {channel}, MESSAGE {content}");
            }
        }

        public void Release()
        {
            status = RadioStatus.Off;
        }

        public enum RadioStatus
        {
            Off,
            On
            
        }

    }
}
