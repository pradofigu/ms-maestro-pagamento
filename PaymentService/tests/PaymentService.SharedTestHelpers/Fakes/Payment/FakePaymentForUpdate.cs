namespace PaymentService.SharedTestHelpers.Fakes.Payment;

using AutoBogus;
using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Models;

public sealed class FakePaymentForUpdate : AutoFaker<PaymentForUpdate>
{
    public FakePaymentForUpdate()
    {
    }
}