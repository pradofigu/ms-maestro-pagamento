namespace PaymentService.Domain.Payments.DomainEvents;

public sealed class PaymentCreated : DomainEvent
{
    public Payment Payment { get; set; } 
}
            