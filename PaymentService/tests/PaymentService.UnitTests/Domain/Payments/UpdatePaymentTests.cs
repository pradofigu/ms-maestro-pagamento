namespace PaymentService.UnitTests.Domain.Payments;

using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = PaymentService.Exceptions.ValidationException;

public class UpdatePaymentTests
{
    private readonly Faker _faker;

    public UpdatePaymentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_payment()
    {
        // Arrange
        var payment = new FakePaymentBuilder().Build();
        var updatedPayment = new FakePaymentForUpdate().Generate();
        
        // Act
        payment.Update(updatedPayment);

        // Assert
        payment.CardNumber.Should().Be(updatedPayment.CardNumber);
        payment.CardToken.Should().Be(updatedPayment.CardToken);
        payment.CardHolderName.Should().Be(updatedPayment.CardHolderName);
        payment.ExpiryDate.Should().Be(updatedPayment.ExpiryDate);
        payment.CVV.Should().Be(updatedPayment.CVV);
        payment.TotalAmount.Should().Be(updatedPayment.TotalAmount);
        payment.Currency.Should().Be(updatedPayment.Currency);
        payment.Status.Should().Be(updatedPayment.Status);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var payment = new FakePaymentBuilder().Build();
        var updatedPayment = new FakePaymentForUpdate().Generate();
        payment.DomainEvents.Clear();
        
        // Act
        payment.Update(updatedPayment);

        // Assert
        payment.DomainEvents.Count.Should().Be(1);
        payment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PaymentUpdated));
    }
}