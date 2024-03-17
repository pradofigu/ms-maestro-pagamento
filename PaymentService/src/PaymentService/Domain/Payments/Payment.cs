namespace PaymentService.Domain.Payments;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using PaymentService.Exceptions;
using PaymentService.Domain.Payments.Models;
using PaymentService.Domain.Payments.DomainEvents;


public class Payment : BaseEntity
{
    public Guid CorrelationId { get; private set; }
    
    public string CardNumber { get; private set; }

    public string CardToken { get; private set; }

    public string CardHolderName { get; private set; }

    public string ExpiryDate { get; private set; }

    public string CVV { get; private set; }

    public decimal TotalAmount { get; private set; }

    public string Currency { get; private set; }

    public string Status { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    public static Payment Create(PaymentForCreation paymentForCreation)
    {
        var newPayment = new Payment();

        newPayment.CorrelationId = paymentForCreation.CorrelationId ?? Guid.NewGuid();
        newPayment.CardNumber = paymentForCreation.CardNumber;
        newPayment.CardToken = paymentForCreation.CardToken;
        newPayment.CardHolderName = paymentForCreation.CardHolderName;
        newPayment.ExpiryDate = paymentForCreation.ExpiryDate;
        newPayment.CVV = paymentForCreation.CVV;
        newPayment.TotalAmount = paymentForCreation.TotalAmount;
        newPayment.Currency = paymentForCreation.Currency;
        newPayment.Status = paymentForCreation.Status;

        newPayment.QueueDomainEvent(new PaymentCreated(){ Payment = newPayment });
        
        return newPayment;
    }

    public Payment Update(PaymentForUpdate paymentForUpdate)
    {
        CorrelationId = paymentForUpdate.CorrelationId;
        CardNumber = paymentForUpdate.CardNumber;
        CardToken = paymentForUpdate.CardToken;
        CardHolderName = paymentForUpdate.CardHolderName;
        ExpiryDate = paymentForUpdate.ExpiryDate;
        CVV = paymentForUpdate.CVV;
        TotalAmount = paymentForUpdate.TotalAmount;
        Currency = paymentForUpdate.Currency;
        Status = paymentForUpdate.Status;

        QueueDomainEvent(new PaymentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Payment() { } // For EF + Mocking
}