namespace SharedKernel.Messages
{
    using System;

    public interface IOrderCreated
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string DiscountCode { get; set; }
        public string CardNumber { get; set; }
        public string CardToken { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string Currency { get; set; }
    }

    public class OrderCreated : IOrderCreated
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string DiscountCode { get; set; }
        public string CardNumber { get; set; }
        public string CardToken { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string Currency { get; set; }
    }
}