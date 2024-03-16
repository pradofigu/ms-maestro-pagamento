namespace SharedKernel.Messages
{
    using System;

    public interface IPaymentCompleted
    {
        public Guid OrderId { get; set; }

        public Guid PaymentId { get; set; }
    }

    public class PaymentCompleted : IPaymentCompleted
    {
        public Guid OrderId { get; set; }

        public Guid PaymentId { get; set; }
    }
}