﻿namespace PaymentService.Domain.Payments.Dtos;

public class PaymentForWebHookCreationDto
{
    public Guid TransactionId { get; set; }
    public string Message { get; set; }
    public decimal AmountCharged { get; set; }
    public DateTime Timestamp { get; set; }
    public bool Success { get; set; }
}