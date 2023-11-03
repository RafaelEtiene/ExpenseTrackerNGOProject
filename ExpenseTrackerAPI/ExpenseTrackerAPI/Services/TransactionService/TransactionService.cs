using AutoMapper;
using ExpenseTrackerAPI.Domain.Data;
using ExpenseTrackerAPI.Domain.Entities;
using ExpenseTrackerAPI.Domain.Mapper;
using ExpenseTrackerAPI.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public Task<TransactionInfoAnalytics> GetTransactionInfoAnalytics()
        {
            throw new NotImplementedException();
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

        public Task UpdateTransaction(TransactionViewModel transaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTransaction(uint idTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
