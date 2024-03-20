namespace SharedKernel.Messages
{
    using System;

    public interface IPaymentRefused
    {
        public Guid PaymentId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Status { get; set; }
    }

    public class PaymentRefused : IPaymentRefused
    {
        public Guid PaymentId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Status { get; set; }
    }
}