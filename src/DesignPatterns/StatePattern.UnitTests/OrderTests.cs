﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Xunit;

namespace StatePattern.UnitTests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WhenCreated_ShouldBePending()
        {
            // Arrange
            Order order = new OrderProxy();


            var graph = order.Graph;

            // Act
            var result = order.Status;

            // Assert
            result.Should().Be(OrderStatus.Pending);

        }

        [Fact]
        public void Confirm_WhenPending_ShouldBeSent()
        {
            // Arrange
            Order order = new OrderProxy();

            // Act
            order.Confirm();

            var result = order.Status;

            // Assert
            result.Should().Be(OrderStatus.Sent);

        }

        [Fact]
        public void Confirm_WhenSent_ShouldBeDelivered()
        {
            // Arrange
            Order order = new OrderProxy();

            // Act
            order.Confirm();
            order.Confirm();

            var result = order.Status;

            // Assert
            result.Should().Be(OrderStatus.Delivered);

        }

        [Fact]
        public void Cancel_WhenPending_ShouldBeCancelled()
        {
            // Arrange
            Order order = new OrderProxy();

            // Act
            order.Cancel();

            var result = order.Status;

            // Assert
            result.Should().Be(OrderStatus.Cancelled);

        }

        [Theory]
        [InlineData(OrderStatus.Pending, OrderStatus.Sent)]        
        [InlineData(OrderStatus.Sent, OrderStatus.Delivered)]
        [InlineData(OrderStatus.Delivered, OrderStatus.Completed)]
        public void Confirm_WhenSourceStatus_ShouldBeStatus(OrderStatus sourceStatus, OrderStatus expected)
        {
            // Arrange        
            Order order = new Order(sourceStatus);

            // Act
            order.Confirm();

            // Assert
            order.Status.Should().Be(expected);
        }

        [Theory]
        [InlineData(OrderStatus.Pending, OrderStatus.Cancelled)]
        [InlineData(OrderStatus.Delivered, OrderStatus.Cancelled)]
        public void Cancel_WhenSourceStatus_ShouldBeStatus(OrderStatus sourceStatus, OrderStatus expected)
        {
            // Arrange        
            Order order = new Order(sourceStatus);

            // Act
            order.Cancel();

            // Assert
            order.Status.Should().Be(expected);
        }

        [Fact]
        public void Cancel_WhenSentStatus_ShouldThrowInvalidOperationException()
        {
            // Arrange        
            Order order = new Order(OrderStatus.Sent);

            // Act
            var act = () => order.Cancel();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cancel_WhenCompletedStatus_ShouldThrowInvalidOperationException()
        {
            // Arrange        
            Order order = new Order(OrderStatus.Completed);

            // Act
            var act = () => order.Cancel();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }



        [Theory]
        [InlineData(OrderStatus.Pending, true)]
        [InlineData(OrderStatus.Sent, true)]
        [InlineData(OrderStatus.Delivered, true)]
        [InlineData(OrderStatus.Completed, false)]
        public void CanConfirm_WhenStatus_ShouldBe(OrderStatus sourceStatus, bool expected)
        {
            // Arrange        
            Order order = new Order(sourceStatus);

            // Act
            var result = order.CanConfirm;

            // Assert
            result.Should().Be(expected);
        }
    }
}
