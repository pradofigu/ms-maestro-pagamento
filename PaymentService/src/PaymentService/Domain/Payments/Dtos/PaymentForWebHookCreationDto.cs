namespace PaymentService.Domain.Payments.Dtos;

public class PaymentForWebHookCreationDto
{
    public bool Success { get; set; }
    public Guid TransactionId { get; set; }
    public string Message { get; set; }
    public decimal AmountCharged { get; set; }
    public DateTime Timestamp { get; set; }
    public string CardNumber { get; set; }
    public string CardToken { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
}