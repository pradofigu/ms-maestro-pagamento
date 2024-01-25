namespace PaymentService.Domain.Payments.Dtos;

public class PaymentForWebHookCreationDto
{
    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string Message { get; set; }
    public decimal AmountCharged { get; set; }
    public string Currency { get; set; }
    public DateTime Timestamp { get; set; }
}