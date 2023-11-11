namespace ExpenseTrackerAPI.Domain.Entities
{
    public class TransactionInfoAnalytics
    {
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Balance { get; set; }
        public List<AmountInMonth> AmountInMonths { get; set; } = null!;
        public List<Transaction> LastTransactions { get; set; } = null!;
    }

    public class AmountInMonth
    {
        public Nullable<decimal> Expenses { get; set; }
        public Nullable<decimal> Income { get; set; }
        public string? Month { get; set; }
    }
}
