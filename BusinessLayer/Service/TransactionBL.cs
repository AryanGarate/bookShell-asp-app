using BusinessLayer.Interface;
using Model;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using RespositoryLayer.CustomException;

namespace BusinessLayer.Service
{
    public class TransactionBL : ITransactionBL
    {
        private readonly ITransactionRL _transactionRL;
        private readonly IMapper _mapper;

        public TransactionBL(ITransactionRL transactionRL, IMapper mapper)
        {
            _transactionRL = transactionRL;
            _mapper = mapper;
        }

        public TransactionDTO CreateTransaction(TransactionDTO model)
        {
            var transactionEntity = _mapper.Map<Transaction>(model);
            var createdTransaction = _transactionRL.CreateTransaction(transactionEntity);
            return _mapper.Map<TransactionDTO>(createdTransaction);
        }

        public List<TransactionDTO> GetAllTransactions()
        {
            var transactions = _transactionRL.GetAllTransactions();
            return _mapper.Map<List<TransactionDTO>>(transactions);
        }

        public TransactionDTO GetTransactionById(int id)
        {
            var transaction = _transactionRL.GetTransactionById(id);
            if (transaction == null)
                throw new TransactionException("Transaction not found");
            return _mapper.Map<TransactionDTO>(transaction);
        }

        public TransactionDTO UpdateTransaction(int id, TransactionDTO model)
        {
            var transactionEntity = _mapper.Map<Transaction>(model);
            var updatedTransaction = _transactionRL.UpdateTransaction(id, transactionEntity);
            if (updatedTransaction == null)
                throw new TransactionException("Transaction not found or update failed");
            return _mapper.Map<TransactionDTO>(updatedTransaction);
        }

        public TransactionDTO DeleteTransaction(int id)
        {
            var deletedTransaction = _transactionRL.DeleteTransaction(id);
            if (deletedTransaction == null)
                throw new TransactionException("Transaction not found or delete failed");
            return _mapper.Map<TransactionDTO>(deletedTransaction);
        }
    }
}
