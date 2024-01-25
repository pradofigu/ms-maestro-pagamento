namespace PaymentService.Domain.Payments.Models;

using Destructurama.Attributed;

public sealed record PaymentForUpdate
{
    public string CardNumber { get; set; }
    public string CardToken { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
}
