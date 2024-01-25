namespace PaymentService.UnitTests.Domain.Payments;

using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = PaymentService.Exceptions.ValidationException;

public class CreatePaymentTests
{
    private readonly Faker _faker;

    public CreatePaymentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_payment()
    {
        // Arrange
        var paymentToCreate = new FakePaymentForCreation().Generate();
        
        // Act
        var payment = Payment.Create(paymentToCreate);

        // Assert
        payment.CardNumber.Should().Be(paymentToCreate.CardNumber);
        payment.CardToken.Should().Be(paymentToCreate.CardToken);
        payment.CardHolderName.Should().Be(paymentToCreate.CardHolderName);
        payment.ExpiryDate.Should().Be(paymentToCreate.ExpiryDate);
        payment.CVV.Should().Be(paymentToCreate.CVV);
        payment.TotalAmount.Should().Be(paymentToCreate.TotalAmount);
        payment.Currency.Should().Be(paymentToCreate.Currency);
        payment.Status.Should().Be(paymentToCreate.Status);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var paymentToCreate = new FakePaymentForCreation().Generate();
        
        // Act
        var payment = Payment.Create(paymentToCreate);

        // Assert
        payment.DomainEvents.Count.Should().Be(1);
        payment.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PaymentCreated));
    }
}