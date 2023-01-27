using System;

namespace StrategyPattern
{
    public interface IPredicateStrategy
    {
        bool IsValid(Order order);        
    }

    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(Order order);
    }

    public class HappyHoursPredicateStrategy : IPredicateStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursPredicateStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool IsValid(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
    }

    public class GenderPredicateStrategy : IPredicateStrategy
    {
        private readonly Gender gender;
        public GenderPredicateStrategy(Gender gender) => this.gender = gender;
        public bool IsValid(Order order) => order.Customer.Gender == gender;
    }

    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal percentage;
        public PercentageDiscountStrategy(decimal percentage) => this.percentage = percentage;
        public decimal CalculateDiscount(Order order) => order.Amount * percentage;
    }

    public class FlatDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal amount;
        public FlatDiscountStrategy(decimal amount) => this.amount = amount;
        public decimal CalculateDiscount(Order order) => amount;
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
        private readonly IPredicateStrategy predicateStrategy;
        private readonly IDiscountStrategy discountStrategy;

        private readonly decimal NoDiscount = decimal.Zero;

        public DiscountOrderCalculator(IPredicateStrategy predicateStrategy, IDiscountStrategy calculateDiscountStrategy)
        {
            this.predicateStrategy = predicateStrategy;
            this.discountStrategy = calculateDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (predicateStrategy.IsValid(order)) // Predykat
            {
                return discountStrategy.CalculateDiscount(order); // Calculate Discount
            }
            else
                return NoDiscount;
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
