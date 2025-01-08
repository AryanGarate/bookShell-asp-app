using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.Interface
{
    public interface ITransactionRL
    {
        Transaction CreateTransaction(TransactionDTO model);
        Transaction GetTransactionById(int id);
        List<Transaction> GetAllTransactions();

        //
        Transaction UpdateTransaction(int id, Transaction transaction);
        Transaction DeleteTransaction(int id);
    }
}