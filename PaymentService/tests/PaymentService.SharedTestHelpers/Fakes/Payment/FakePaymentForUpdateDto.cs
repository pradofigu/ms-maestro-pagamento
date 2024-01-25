namespace PaymentService.SharedTestHelpers.Fakes.Payment;

using AutoBogus;
using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Dtos;

public sealed class FakePaymentForUpdateDto : AutoFaker<PaymentForUpdateDto>
{
    public FakePaymentForUpdateDto()
    {
    }
}