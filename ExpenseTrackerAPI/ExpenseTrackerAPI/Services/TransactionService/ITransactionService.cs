using ExpenseTrackerAPI.Domain.Entities;
using ExpenseTrackerAPI.Domain.ViewModel;

namespace ExpenseTrackerAPI.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();

        Task InsertTransaction(TransactionViewModel transaction);

        Task UpdateTransaction(TransactionViewModel transaction);

        Task DeleteTransaction(uint idTransaction);

        Task<TransactionInfoAnalytics> GetTransactionInfoAnalytics();
    }
}
