﻿using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Exception.ExceptionBase;
using MiniBankApp.Exception;

namespace MiniBankApp.Application.UseCases.Transactions.History
{
    public class TransactionHistoryUseCase : ITransactionHistoryUseCase
    {
        private readonly ITransactionHistoryRepository _repository;
        public TransactionHistoryUseCase(ITransactionHistoryRepository repository)
        {
            _repository = repository;
        }

        public ResponseTransactionHistoryJson Execute(int accountId)
        {
            var account = _repository.GetAccount(accountId);

            if (account == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            var transactions = _repository.GetTransactionsFromAccount(accountId);
            var response = new ResponseTransactionHistoryJson();

            if (transactions != null && transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    response.Transactions.Add(new TransactionHistoryItem
                    {
                        Value = transaction.Value,
                        Date = transaction.CreateDate,
                        OperationType = (OperationType)transaction.OperationType
                    });
                }
            }

            return response;
        }
    }
}
