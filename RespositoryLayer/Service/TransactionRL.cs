using Model;
using RespositoryLayer.ContextDB;
using RespositoryLayer.CustomException;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.Service
{
    public class TransactionRL : ITransactionRL
    {
        private readonly BookEcommerceContext _context;

        public TransactionRL(BookEcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Transaction CreateTransaction(TransactionDTO model)
        {
            var transaction = new Transaction
            {
                TotalAmount = model.TotalAmount,
                PaymentStatus = model.PaymentStatus,
                PaymentType = model.PaymentType,
                PaymentTransactionId = model.PaymentTransactionId,
                CreatedAt = DateTime.Now
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions.Find(id);
        }
        public Transaction DeleteTransaction(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                throw new TransactionException($"Transaction with ID {id} does not exist");
            }

            _context.Transactions.Remove(transaction);
            _context.SaveChanges();

            return transaction;
        }
        public Transaction UpdateTransaction(int id, Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            var existingTransaction = _context.Transactions.Find(id);
            if (existingTransaction == null)
            {
                throw new TransactionException($"Transaction with ID {id} does not exist");
            }

            // Update fields
            existingTransaction.TotalAmount = transaction.TotalAmount;
            existingTransaction.PaymentStatus = transaction.PaymentStatus;
            existingTransaction.PaymentType = transaction.PaymentType;
            existingTransaction.PaymentTransactionId = transaction.PaymentTransactionId;
            existingTransaction.UpdatedAt = DateTime.Now; // Update timestamp

            _context.Transactions.Update(existingTransaction);
            _context.SaveChanges();

            return existingTransaction;
        }
    }
}
