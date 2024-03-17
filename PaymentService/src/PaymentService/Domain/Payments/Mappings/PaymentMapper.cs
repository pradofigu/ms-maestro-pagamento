namespace PaymentService.Domain.Payments.Mappings;

using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class PaymentMapper
{
    public static partial PaymentForCreation ToPaymentForCreation(this PaymentForCreationDto paymentForCreationDto);
    public static partial PaymentForUpdate ToPaymentForUpdate(this PaymentForUpdateDto paymentForUpdateDto);
    public static partial PaymentForUpdate ToPaymentForWebHookUpdate(this PaymentForWebHookCreationDto paymentForUpdateDto);
    public static partial PaymentDto ToPaymentDto(this Payment payment);
    public static partial IQueryable<PaymentDto> ToPaymentDtoQueryable(this IQueryable<Payment> payment);
}