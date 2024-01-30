namespace PaymentService.IntegrationTests.FeatureTests.Payments;

using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.Domain.Payments.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PaymentQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_payment_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var paymentOne = new FakePaymentBuilder().Build();
        await testingServiceScope.InsertAsync(paymentOne);

        // Act
        var query = new GetPayment.Query(paymentOne.Id);
        var payment = await testingServiceScope.SendAsync(query);

        // Assert
        payment.CardNumber.Should().Be(paymentOne.CardNumber);
        payment.CardToken.Should().Be(paymentOne.CardToken);
        payment.CardHolderName.Should().Be(paymentOne.CardHolderName);
        payment.ExpiryDate.Should().Be(paymentOne.ExpiryDate);
        payment.CVV.Should().Be(paymentOne.CVV);
        payment.TotalAmount.Should().BeApproximately(paymentOne.TotalAmount, 0.001M);
        payment.Currency.Should().Be(paymentOne.Currency);
        payment.Status.Should().Be(paymentOne.Status);
    }

    [Fact]
    public async Task get_payment_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetPayment.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}