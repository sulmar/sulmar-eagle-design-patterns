using Stateless;
using System;
using System.Diagnostics.Tracing;

namespace StatePattern
{
    // Maszyna Stanów Skończonych 
    // dotnet add package Stateless

    public class OrderProxy : Order
    {
        private readonly StateMachine<OrderStatus, OrderTrigger> machine;

        public override string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());

        public OrderProxy()
        {
            machine = new StateMachine<OrderStatus, OrderTrigger>(OrderStatus.Pending);

            machine.Configure(OrderStatus.Pending)
                .Permit(OrderTrigger.Confirm, OrderStatus.Sent)
                .Permit(OrderTrigger.Cancel, OrderStatus.Cancelled);

            machine.Configure(OrderStatus.Sent)
                .OnEntry(() => Console.WriteLine("Wysłano zamówienie"), "Sent Message")
                .Permit(OrderTrigger.Confirm, OrderStatus.Delivered);

            machine.Configure(OrderStatus.Delivered)
                .Permit(OrderTrigger.Confirm, OrderStatus.Completed);



        }

        public override void Confirm() => machine.Fire(OrderTrigger.Confirm);
        public override void Cancel() => machine.Fire(OrderTrigger.Cancel);

        public override OrderStatus Status => machine.State;

        public override bool CanConfirm => machine.CanFire(OrderTrigger.Confirm);
        public override bool CanCancel => machine.CanFire(OrderTrigger.Cancel);
    }


    public class Order
    {
        public virtual string Graph { get;  }

        public Order(OrderStatus initialState = OrderStatus.Pending)
        {            
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
            Status = initialState;
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual OrderStatus Status { get; private set; }

        public virtual void Confirm()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Sent;
            }
            else if (Status == OrderStatus.Sent)
            {
                Status = OrderStatus.Delivered;
            }
            else if (Status == OrderStatus.Delivered)
            {
                Status = OrderStatus.Completed;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public virtual void Cancel()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Cancelled;
            }
            else if (Status == OrderStatus.Delivered)
            {
                Status = OrderStatus.Cancelled;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override string ToString() => $"Order {Id} created on {OrderDate}{Environment.NewLine}";

        public virtual bool CanConfirm => Status == OrderStatus.Pending || Status == OrderStatus.Sent || Status == OrderStatus.Delivered;
        public virtual bool CanCancel => Status == OrderStatus.Pending || Status == OrderStatus.Delivered;
    }

    public enum OrderStatus
    {
        Pending,        
        Sent,
        Delivered,
        Completed,
        Cancelled
    }

    public enum OrderTrigger
    {
        Confirm,
        Cancel,
    }

}
