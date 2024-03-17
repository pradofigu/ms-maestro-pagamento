namespace SharedKernel.Messages
{
    using System;

    public interface IPaymentCompleted
    {
        public Guid CorrelationId { get; set; }
    }

    public class PaymentCompleted : IPaymentCompleted
    {
        public Guid CorrelationId { get; set; }
    }
}