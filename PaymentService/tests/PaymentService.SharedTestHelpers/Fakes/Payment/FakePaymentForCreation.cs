namespace PaymentService.SharedTestHelpers.Fakes.Payment;

using AutoBogus;
using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Models;

public sealed class FakePaymentForCreation : AutoFaker<PaymentForCreation>
{
    public FakePaymentForCreation()
    {
    }
}