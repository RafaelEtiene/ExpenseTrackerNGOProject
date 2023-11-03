using AutoMapper;
using ExpenseTrackerAPI.Domain.Entities;
using ExpenseTrackerAPI.Domain.ViewModel;

namespace ExpenseTrackerAPI.Domain.Mapper
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionViewModel, Transaction>();
        }
    }
}
