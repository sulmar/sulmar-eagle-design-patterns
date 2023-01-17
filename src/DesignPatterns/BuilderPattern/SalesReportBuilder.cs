using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Abstract Builder
    public interface ISalesReportBuilder
    {
        void AddHeader();
        void AddSectionGender();
        void AddSectionProducts();
        void AddFooter();
        SalesReport Build();
    }

    // Abstract Builder
    public interface IFluentSalesReportBuilder
    {
        IFluentSalesReportBuilder AddHeader(string title);
        IFluentSalesReportBuilder AddSectionGender();
        IFluentSalesReportBuilder AddSectionProducts();
        IFluentSalesReportBuilder AddFooter();
        SalesReport Build();
    }

    // Concrete Builder
    public class LazyFluentSalesReportBuilder : IFluentSalesReportBuilder
    {
        // private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        private readonly List<Func<SalesReport, SalesReport>> actions = new();

        // private readonly List<Action<SalesReport>> actions = new();


        public LazyFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }


        private LazyFluentSalesReportBuilder AddAction(Action<SalesReport> action)
        {
            actions.Add(subject =>
            {
                action(subject);

                return subject;
            });

            return this;
        }

        private LazyFluentSalesReportBuilder Do(Action<SalesReport> action) => AddAction(action);

        public IFluentSalesReportBuilder AddHeader(string title) =>
            Do(salesReport => AddHeader(salesReport, title));

        private LazyFluentSalesReportBuilder AddHeader(SalesReport salesReport, string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }


        public IFluentSalesReportBuilder AddSectionGender() => Do(salesReport => AddSectionGender(salesReport));
        private LazyFluentSalesReportBuilder AddSectionGender(SalesReport salesReport)
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }

        public IFluentSalesReportBuilder AddFooter() => Do(salesReport => AddFooter(salesReport));

        private LazyFluentSalesReportBuilder AddFooter(SalesReport salesReport)
        {

            return this;
        }

        public IFluentSalesReportBuilder AddSectionProducts() => Do((salesReport => AddSectionProducts(salesReport)));
        private LazyFluentSalesReportBuilder AddSectionProducts(SalesReport salesReport)
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public SalesReport Build()
        {
            // SalesReport salesReport = new SalesReport();
            //foreach (var action in actions)
            //{
            //    action(salesReport);
            //}

            SalesReport salesReport = actions.Aggregate(new SalesReport(), (subject, action) => action(subject));

            return salesReport;
        }
    }

    // Concrete Builder
    public class EagerFluentSalesReportBuilder : IFluentSalesReportBuilder
    {
        private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        public EagerFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            salesReport = new SalesReport();
            this.orders = orders;
        }

        public IFluentSalesReportBuilder AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public IFluentSalesReportBuilder AddSectionGender()
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }

        public IFluentSalesReportBuilder AddFooter()
        {

            return this;
        }

        public IFluentSalesReportBuilder AddSectionProducts()
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public SalesReport Build()
        {
            return salesReport;
        }
    }

    // Concrete Builder
    internal class SalesReportBuilder : ISalesReportBuilder
    {
        private readonly SalesReport salesReport;
        private readonly IEnumerable<Order> orders;

        public SalesReportBuilder(IEnumerable<Order> orders)
        {
            salesReport = new SalesReport();
            this.orders = orders;
        }

        public void AddHeader()
        {
            salesReport.Title = "Raport sprzedaży";
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);
        }

        public void AddSectionGender()
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));
        }

        public void AddFooter()
        {

        }

        public void AddSectionProducts()
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
        }

        public SalesReport Build()
        {
            return salesReport;
        }
    }
}
