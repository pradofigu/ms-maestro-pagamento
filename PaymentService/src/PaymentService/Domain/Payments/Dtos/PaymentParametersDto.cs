namespace PaymentService.Domain.Payments.Dtos;

using PaymentService.Resources;

public sealed class PaymentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
