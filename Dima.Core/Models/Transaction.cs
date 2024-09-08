using Dima.Core.Enums;

namespace Dima.Core.Models;

public class Transaction
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidOrReceiveAt { get; set; }
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw; //colocando qual é o valor mais usado como padrão
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!; // isso significa que o .Net sabe que ele pode ser nulo, mas também estou avisando ele que eu (usuário) não
    //deixarei ser nulo
    public string UserId { get; set; } = string.Empty;
}
