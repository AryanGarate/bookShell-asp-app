using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ITransactionBL
    {
        TransactionDTO CreateTransaction(TransactionDTO model);
        List<TransactionDTO> GetAllTransactions();
        TransactionDTO GetTransactionById(int id);
        TransactionDTO UpdateTransaction(int id, TransactionDTO model);
        TransactionDTO DeleteTransaction(int id);
    }
}
