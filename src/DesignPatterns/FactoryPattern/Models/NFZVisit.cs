using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
    public class VisitFactory
    {
        public static Visit Create(string visitType) => visitType switch
        {
            "N" => new NFZVisit(),
            "P" => new PrivateVisit(100),
            "F" => new CompanyVisit(100, 0.1m),
            "T" => new TeleVisit(),
            _ => throw new NotSupportedException()
        };





        //if (visitType == "N")
        //{
        //    return new NFZVisit();
        //}
        //else if (visitType == "P")
        //{
        //    return new PrivateVisit(100);
        //}
        //else if (visitType == "F")
        //{
        //    return new CompanyVisit(100, 0.1m);
        //}
        //else if (visitType == "T")
        //{
        //    return new TeleVisit();
        //}
        //else
        //{
        //    throw new NotSupportedException();
        //}
    }
}

// Abstract Product
public abstract class Visit
{
    public abstract decimal CalculateCost(TimeSpan duration);
}

// Concrete Product
public class NFZVisit : Visit
{
    private const decimal AmountPerHour = decimal.Zero;
    public override decimal CalculateCost(TimeSpan duration)
    {
        return AmountPerHour;
    }
}

public class PrivateVisit : Visit
{
    private readonly decimal _amountPerHour;

    public PrivateVisit(decimal amountPerHour)
    {
        _amountPerHour = amountPerHour;
    }

    public override decimal CalculateCost(TimeSpan duration)
    {
        return (decimal)duration.TotalHours * _amountPerHour;
    }
}

public class TeleVisit : Visit
{
    public override decimal CalculateCost(TimeSpan duration)
    {
        return 50;
    }
}

public class CompanyVisit : Visit
{
    private readonly decimal _amountPerHour;
    private readonly decimal _discount;

    public CompanyVisit(decimal amountPerHour, decimal discount)
    {
        _amountPerHour = amountPerHour;
        _discount = discount;
    }

    public override decimal CalculateCost(TimeSpan duration)
    {
        return (1 - _discount) * (decimal)duration.TotalHours * _amountPerHour;
    }
}

