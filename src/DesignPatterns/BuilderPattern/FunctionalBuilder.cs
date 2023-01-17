using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class FunctionalSalesReportBuilder : FunctionalBuilder<SalesReport, FunctionalSalesReportBuilder>, IFluentSalesReportBuilder
    {
        private readonly IEnumerable<Order> orders;

        public FunctionalSalesReportBuilder(IEnumerable<Order> orders) => this.orders = orders;

        public IFluentSalesReportBuilder AddFooter()
        {
            throw new NotImplementedException();
        }

        public IFluentSalesReportBuilder AddHeader(string title) => Do(salesReport => AddHeader(salesReport, title));

        private FunctionalSalesReportBuilder AddHeader(SalesReport salesReport, string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

     

        public IFluentSalesReportBuilder AddSectionGender()
        {
            throw new NotImplementedException();
        }

        public IFluentSalesReportBuilder AddSectionProducts()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
        where TSelf : FunctionalBuilder<TSubject, TSelf>
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(subject =>
            {
                action(subject);

                return subject;
            });

            return (TSelf)this;
        }

        protected TSelf Do(Action<TSubject> action) => AddAction(action);

        public TSubject Build() => actions.Aggregate(new TSubject(),(subject, action) => subject);
    }
}
