using System;

namespace StrategyPattern
{
    
    public interface IDiscountStrategy
    {
        bool CanDiscount(Order order);
        decimal Discount(Order order);
    }

    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);        
    }

    public interface ICalculateDiscountStrategy
    {
        decimal Discount(Order order);
    }

    public class HappyHoursCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
    }

    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly Gender gender;
        public GenderCanDiscountStrategy(Gender gender) => this.gender = gender;
        public bool CanDiscount(Order order) => order.Customer.Gender == gender;
    }

    public class PercentageCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private readonly decimal percentage;
        public PercentageCalculateDiscountStrategy(decimal percentage) => this.percentage = percentage;
        public decimal Discount(Order order) => order.Amount * percentage;
    }

    public class HappyHoursPercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal percentage;

        public HappyHoursPercentageDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        public decimal Discount(Order order) => order.Amount * percentage;
    }

    public class HappyHoursFixedDiscountStrategy : IDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal amount;

        public HappyHoursFixedDiscountStrategy(TimeSpan from, TimeSpan to, decimal amount)
        {
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        public decimal Discount(Order order) => amount;
    }

    

    public class DelegateDiscountOrderCalculator
    {
        private readonly Predicate<Order> canDiscount;
        private readonly Func<Order, decimal> discount;

        public DelegateDiscountOrderCalculator(
            Predicate<Order> canDiscount, 
            Func<Order, decimal> discount)
        {
            this.canDiscount = canDiscount;
            this.discount = discount;
        }

        public decimal CalculateDiscount(Order order)
        {   
            if (canDiscount(order))
                return discount(order);

            return decimal.Zero;
        }
    }

    public class DiscountOrderCalculator
    {
        // private readonly IDiscountStrategy discountStrategy;

        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly ICalculateDiscountStrategy calculateDiscountStrategy;

        public DiscountOrderCalculator(ICanDiscountStrategy canDiscountStrategy, ICalculateDiscountStrategy calculateDiscountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy;
            this.calculateDiscountStrategy = calculateDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order)) // Predykat
            {
                return calculateDiscountStrategy.Discount(order); // Calculate Discount
            }
            else
                return 0;
        }
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
            if (order.Customer.Gender == gender)
            {
                return order.Amount * percentage;
            }
            else
                return 0;
        }
    }
}
