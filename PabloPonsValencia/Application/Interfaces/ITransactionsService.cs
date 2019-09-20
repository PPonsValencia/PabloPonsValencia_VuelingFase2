using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionsService
    {
        Task<IEnumerable<TransactionsDTO>> GetAsync();
        Task<TotalTransactionDTO> GetTotalTransactionAsync(string sku);
    }
}
