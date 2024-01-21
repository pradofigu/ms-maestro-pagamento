namespace PaymentService.Domain.Payments.Services;

using PaymentService.Domain.Payments;
using PaymentService.Databases;
using PaymentService.Services;

public interface IPaymentRepository : IGenericRepository<Payment>
{
}

public sealed class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    private readonly PaymentDbContext _dbContext;

    public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
