namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IPaymentRefused
    {
        public Guid OrderId { get; set; }

public Guid PaymentId { get; set; }
    }

    public class PaymentRefused : IPaymentRefused
    {
        public Guid OrderId { get; set; }

public Guid PaymentId { get; set; }
    }
}