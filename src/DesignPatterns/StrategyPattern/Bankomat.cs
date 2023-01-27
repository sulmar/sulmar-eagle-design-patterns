using System;

namespace StrategyPattern
{
    public interface IBankomat
    {
        void Wplata(decimal amount);
        void Wyplata(decimal amount);
    }

    public interface IWplatomat
    {
        void Wplata(decimal amount);
    }

    public interface IWyplatomat
    {
        void Wyplata(decimal amount);

    }

    public class SantanderBankomat : IWyplatomat, IWplatomat
    {
        public void Wplata(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Wyplata(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public class PkoBankomat : IBankomat
    {
        decimal saldo;

        public void Wplata(decimal amount)
        {
            throw new NotSupportedException();
        }

        public void Wyplata(decimal amount)
        {
            saldo -= amount;
        }
    }

}
