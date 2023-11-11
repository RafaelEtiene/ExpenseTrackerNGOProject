using AutoMapper;
using ExpenseTrackerAPI.Domain.Data;
using ExpenseTrackerAPI.Domain.Entities;
using ExpenseTrackerAPI.Domain.Enums;
using ExpenseTrackerAPI.Domain.Mapper;
using ExpenseTrackerAPI.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace ExpenseTrackerAPI.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly OngfinanceContext _context;
        private readonly IMapper _mapper;

        public TransactionService(OngfinanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            try
            {
                return await _context.Transactions.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while searched the registers." + e.Message);
            }
        }

        public async Task<TransactionInfoAnalytics> GetTransactionInfoAnalytics()
        {
            try
            {
                var transactions = await _context.Transactions.ToListAsync();
                var transactionInfoAnalytics = new TransactionInfoAnalytics();

                transactionInfoAnalytics.TotalExpenses = (
                        from transaction in transactions
                        where transaction.Type == (int)TransactionType.Expense
                        select transaction.Amount
                    ).Sum();

                transactionInfoAnalytics.TotalIncome = (
                        from transaction in transactions
                        where transaction.Type == (int)TransactionType.Income
                        select transaction.Amount
                    ).Sum();

                transactionInfoAnalytics.LastTransactions = (
                        from transaction in transactions
                        where transaction.Date >= DateTime.Now.AddDays(-10)
                        select transaction
                    ).ToList();

                transactionInfoAnalytics.Balance = transactionInfoAnalytics.TotalIncome - transactionInfoAnalytics.TotalExpenses;

                var amountInMonth = new AmountInMonth();
                CultureInfo cultureInfo = new CultureInfo("en-US");

                for (int i = 1; i <= 12; i++)
                {
                    amountInMonth.Expenses = transactions.Where(t => t.Date.Month == i && t.Type == (int)TransactionType.Expense).Sum(s => s.Amount);
                    amountInMonth.Income = transactions.Where(t => t.Date.Month == i && t.Type == (int)TransactionType.Income).Sum(s => s.Amount);
                    amountInMonth.Month = cultureInfo.DateTimeFormat.GetMonthName(i);

                    transactionInfoAnalytics.AmountInMonths.Append(amountInMonth);
                }

                return transactionInfoAnalytics;
            }
            catch(Exception e)
            {
                throw new Exception("An error occurred while searched the info analytics." + e.Message);
            }
        }

        public async Task InsertTransaction(TransactionViewModel transaction)
        {
            try
            {
                if (transaction is null)
                    throw new Exception("An error occurred while inserted the register.");

                var entity = _mapper.Map<TransactionViewModel, Transaction>(transaction);

                _context.Transactions.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("An error occurred while inserted the register. " + e.Message);
            }
            

        }

        public async Task UpdateTransaction(TransactionViewModel transaction)
        {
            try
            {
                if (transaction is null)
                    throw new Exception("The object is null.");

                var register = await _context.Transactions.SingleAsync(t => t.IdTransaction == transaction.IdTransaction);

                if (!string.IsNullOrEmpty(transaction.Description))
                {
                    register.Description = transaction.Description;
                }

                if (transaction.Amount.HasValue)
                {
                    register.Amount = transaction.Amount.Value;
                }

                register.Date = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updated the register. " + e.Message);
            }
        }

        public async Task DeleteTransaction(uint idTransaction)
        {
            try
            {
                var register = await _context.Transactions.SingleAsync(t => t.IdTransaction == idTransaction);

                if (register is null)
                    throw new Exception("The transaction don't was finded.");

                _context.Remove(register);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deleted the register. " + e.Message);
            }
        }
    }
}
