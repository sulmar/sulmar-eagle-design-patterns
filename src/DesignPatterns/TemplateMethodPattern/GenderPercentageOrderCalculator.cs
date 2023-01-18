using System;

namespace TemplateMethodPattern
{


    public class GenderFixedOrderCalculator
    {
        private readonly Gender gender;

        private readonly decimal amount;

        public GenderFixedOrderCalculator(Gender gender, decimal amount)
        {
            this.gender = gender;
            this.amount = amount;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.Customer.Gender == gender)
            {
                return amount;
            }
            else
                return 0;
        }
    }

    public class HappyHoursFixedOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal amount;

        public HappyHoursFixedOrderCalculator(TimeSpan from, TimeSpan to, decimal amount)
        {
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to) // Predykat
            {
                return amount; // Calculate Discount
            }

            return 0;
        }
    }

    public abstract class TemplateOrderCalculator
    {
        public abstract bool CanDiscount(Order order);
        public abstract decimal Discount(Order order);

        public virtual decimal NoDiscount => decimal.Zero;

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order)) // Predykat
            {
                return Discount(order); // Calculate Discount
            }

            return NoDiscount;
        }
    }


    public class GenderPercentageDiscountOrderCalculator : TemplateOrderCalculator
    {
        private readonly Gender gender;
        private readonly decimal percentage;

        public GenderPercentageDiscountOrderCalculator(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public override bool CanDiscount(Order order) => order.Customer.Gender == gender;
        public override decimal Discount(Order order) => order.Amount * percentage;
    }

    public class HappyHoursPercentageDiscountOrderCalculator : TemplateOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal percentage;

        public HappyHoursPercentageDiscountOrderCalculator(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public override bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        public override decimal Discount(Order order) => order.Amount * percentage;
    }


    // Gender - 20% upustu dla kobiet
    public class GenderPercentageOrderCalculator
    {
        private readonly Gender gender;

        private readonly decimal percentage;

        public GenderPercentageOrderCalculator(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.Customer.Gender == gender) // Predykat
            {
                return order.Amount * percentage; // Calculate Discount
            }
            else
                return 0;
        }
    }
}
