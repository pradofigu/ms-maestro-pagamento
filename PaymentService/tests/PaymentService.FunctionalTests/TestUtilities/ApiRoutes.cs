namespace PaymentService.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Payments
    {
        public static string GetList => $"{Base}/payments";
        public static string GetAll => $"{Base}/payments/all";
        public static string GetRecord(Guid id) => $"{Base}/payments/{id}";
        public static string Delete(Guid id) => $"{Base}/payments/{id}";
        public static string Put(Guid id) => $"{Base}/payments/{id}";
        public static string Create => $"{Base}/payments";
        public static string CreateBatch => $"{Base}/payments/batch";
    }
}
