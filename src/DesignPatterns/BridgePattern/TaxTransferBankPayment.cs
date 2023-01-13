using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class StandardTransferBankPayment
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {

            Console.WriteLine("Autoryzacja za pomocą login i hasła.");

            Console.WriteLine($"Przelew standardowy {Amount}");

        }
    }

    public class StandardTransferBlik
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

            Console.WriteLine($"Przelew standardowy {Amount}");
        }

    }

    public class StandardTransferCreditCard
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą PIN");

            Console.WriteLine($"Przelew standardowy {Amount}");
        }
    }

    public class TaxTransferBankPayment
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");

            Console.WriteLine($"Przelew podatkowy {Amount}");
        }
    }

    public class TaxTransferBlik
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

            Console.WriteLine($"Przelew podatkowy {Amount}");
        }
    }

    public class TaxTransferCreditCard
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą PIN");

            Console.WriteLine($"Przelew podatkowy {Amount}");
        }
    }

    public class ZusTransferBankPayment
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");

            Console.WriteLine($"Przelew ZUS {Amount}");
        }
    }

    public class ZusTransferBlik
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą kodu BLIK");

            Console.WriteLine($"Przelew ZUS {Amount}");
        }
    }

    public class ZusTransferCreditCard
    {
        public decimal Amount { get; set; }

        public void MakeTransfer()
        {
            Console.WriteLine("Autoryzacja za pomocą PIN");

            Console.WriteLine($"Przelew ZUS {Amount}");
        }
    }

}
