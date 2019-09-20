using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DtoAdapters
{
    public static class TransactionsAdapter
    {
        public static TransactionsDTO ToDTO(this Transactions transaction)
        {
            TransactionsDTO transactionDto = new TransactionsDTO();

            transactionDto.Sku = transaction.Sku;
            transactionDto.Amount = transaction.Amount;
            transactionDto.Currency = transaction.Currency;

            return transactionDto;
        }

        public static IEnumerable<TransactionsDTO> ToDTO(this IEnumerable<Transactions> transactions)
        {
            List<TransactionsDTO> transactionsDTO = new List<TransactionsDTO>();

            foreach (var transaction in transactions)
            {
                transactionsDTO.Add(transaction.ToDTO());
            }

            return transactionsDTO;
        }

        public static decimal[] ToAmounts(this IEnumerable<Transactions> transactions)
        {
            decimal[] amounts = new decimal[transactions.Count()];

            for (int i = 0; i < transactions.Count(); i++)
            {
                amounts[i] = transactions.ElementAt(i).Amount;
            }

            return amounts;
        }
    }
}
