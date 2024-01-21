namespace PaymentService.Domain.Payments.DomainEvents;

public sealed class PaymentUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            