namespace PaymentService.FunctionalTests.FunctionalTests.Payments;

using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetPaymentTests : TestBase
{
    [Fact]
    public async Task get_payment_returns_success_when_entity_exists()
    {
        // Arrange
        var payment = new FakePaymentBuilder().Build();
        await InsertAsync(payment);

        // Act
        var route = ApiRoutes.Payments.GetRecord(payment.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}