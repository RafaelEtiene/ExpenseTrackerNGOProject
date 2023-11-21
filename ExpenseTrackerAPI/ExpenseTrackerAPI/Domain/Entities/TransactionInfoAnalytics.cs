namespace ExpenseTrackerAPI.Domain.Entities
{
    public class TransactionInfoAnalytics
    {
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Balance { get; set; }
        public List<AmountInMonth> AmountInMonths { get; set; } = new List<AmountInMonth>();
        public List<Transaction> LastTransactions { get; set; } = new List<Transaction>();
    }

    public class AmountInMonth
    {
        public decimal? Expenses { get; set; }
        public decimal? Incomes { get; set; }
        public string? Month { get; set; }
    }
}
