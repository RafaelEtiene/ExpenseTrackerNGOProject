namespace ExpenseTrackerAPI.Domain.Entities;

public class Transaction
{
    public uint IdTransaction { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public int Type { get; set; }
}
