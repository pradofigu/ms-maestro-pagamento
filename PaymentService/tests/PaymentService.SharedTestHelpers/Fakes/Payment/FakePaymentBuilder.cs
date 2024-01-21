namespace PaymentService.SharedTestHelpers.Fakes.Payment;

using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Models;

public class FakePaymentBuilder
{
    private PaymentForCreation _creationData = new FakePaymentForCreation().Generate();

    public FakePaymentBuilder WithModel(PaymentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakePaymentBuilder WithCardNumber(string cardNumber)
    {
        _creationData.CardNumber = cardNumber;
        return this;
    }
    
    public FakePaymentBuilder WithCardToken(string cardToken)
    {
        _creationData.CardToken = cardToken;
        return this;
    }
    
    public FakePaymentBuilder WithCardHolderName(string cardHolderName)
    {
        _creationData.CardHolderName = cardHolderName;
        return this;
    }
    
    public FakePaymentBuilder WithExpiryDate(string expiryDate)
    {
        _creationData.ExpiryDate = expiryDate;
        return this;
    }
    
    public FakePaymentBuilder WithCVV(string cVV)
    {
        _creationData.CVV = cVV;
        return this;
    }
    
    public FakePaymentBuilder WithTotalAmount(decimal totalAmount)
    {
        _creationData.TotalAmount = totalAmount;
        return this;
    }
    
    public FakePaymentBuilder WithCurrency(string currency)
    {
        _creationData.Currency = currency;
        return this;
    }
    
    public FakePaymentBuilder WithStatus(string status)
    {
        _creationData.Status = status;
        return this;
    }
    
    public Payment Build()
    {
        var result = Payment.Create(_creationData);
        return result;
    }
}