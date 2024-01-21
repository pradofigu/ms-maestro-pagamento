namespace PaymentService.IntegrationTests.FeatureTests.Payments;

using PaymentService.Domain.Payments.Dtos;
using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.Domain.Payments.Features;
using Domain;
using System.Threading.Tasks;

public class PaymentListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_payment_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var paymentOne = new FakePaymentBuilder().Build();
        var paymentTwo = new FakePaymentBuilder().Build();
        var queryParameters = new PaymentParametersDto();

        await testingServiceScope.InsertAsync(paymentOne, paymentTwo);

        // Act
        var query = new GetPaymentList.Query(queryParameters);
        var payments = await testingServiceScope.SendAsync(query);

        // Assert
        payments.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}