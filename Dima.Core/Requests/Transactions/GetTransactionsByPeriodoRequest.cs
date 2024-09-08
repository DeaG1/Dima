namespace Dima.Core.Requests.Transactions;

public class GetTransactionsByPeriodoRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
