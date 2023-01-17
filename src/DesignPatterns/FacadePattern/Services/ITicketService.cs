using FacadePattern.Models;
using FacadePattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{

    public record TicketParameters(string from, string to, DateTime when, byte numberOfPlaces, bool hasDog);
    

    // Facade
    public interface ITicketService
    {
        Ticket Buy(TicketParameters parameters);
    }

    public class OnlineTicketService : ITicketService
    {
        private readonly RailwayConnectionRepository railwayConnectionRepository;
        private readonly TicketCalculator ticketCalculator;
        private readonly ReservationService reservationService;
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public OnlineTicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket Buy(TicketParameters parameters)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(parameters.from, parameters.to, parameters.when);
            decimal price = ticketCalculator.Calculate(railwayConnection, parameters.numberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, parameters.numberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;
        }
    }


}
