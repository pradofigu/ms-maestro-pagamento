namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IOrderCreated
    {
        public Guid OrderId { get; set; }
    }

    public class OrderCreated : IOrderCreated
    {
        public Guid OrderId { get; set; }
    }
}