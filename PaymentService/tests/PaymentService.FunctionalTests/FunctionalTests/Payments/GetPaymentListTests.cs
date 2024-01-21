namespace PaymentService.FunctionalTests.FunctionalTests.Payments;

using PaymentService.SharedTestHelpers.Fakes.Payment;
using PaymentService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetPaymentListTests : TestBase
{
    [Fact]
    public async Task get_payment_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Payments.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}