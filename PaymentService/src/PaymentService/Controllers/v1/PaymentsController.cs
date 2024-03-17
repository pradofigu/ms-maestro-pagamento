using PaymentService.Domain;

namespace PaymentService.Controllers.v1;

using Domain.Payments.Features;
using Domain.Payments.Dtos;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;

[ApiController]
[Route("api/payments")]
[ApiVersion("1.0")]
public sealed class PaymentsController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new Payment record.
    /// </summary>
    [HttpPost(Name = "AddPayment")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult<PaymentDto>> AddPayment([FromBody]PaymentForCreationDto paymentForCreation)
    {
        var command = new AddPayment.Command(paymentForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetPayment",
            new { paymentId = commandResponse.Id },
            commandResponse);
    }
    
    /// <summary>
    /// Webhook for Payment Received
    /// </summary>
    [HttpPost("webhook", Name = "WebHookPayment")]
    public async Task<ActionResult> WebHookPayment([FromBody]PaymentForWebHookCreationDto paymentForWebHookCreationDto)
    {
        var command = new CheckPayment.Command(paymentForWebHookCreationDto);
        await mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Gets a single Payment by ID.
    /// </summary>
    [HttpGet("{paymentId:guid}", Name = "GetPayment")]
    public async Task<ActionResult<PaymentDto>> GetPayment(Guid paymentId)
    {
        var query = new GetPayment.Query(paymentId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Payments.
    /// </summary>
    [HttpGet(Name = "GetPayments")]
    public async Task<IActionResult> GetPayments([FromQuery] PaymentParametersDto paymentParametersDto)
    {
        var query = new GetPaymentList.Query(paymentParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }
    
    /// <summary>
    /// Updates an entire existing Payment.
    /// </summary>
    [HttpPut("{paymentId:guid}", Name = "UpdatePayment")]
    public async Task<IActionResult> UpdatePayment(Guid paymentId, PaymentForUpdateDto payment)
    {
        var command = new UpdatePayment.Command(paymentId, payment);
        await mediator.Send(command);
        return NoContent();
    }
    
    // endpoint marker - do not delete this comment
}
