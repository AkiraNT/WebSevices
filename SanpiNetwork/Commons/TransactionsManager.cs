using SubSonic;
using SweetCMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanpiNetwork.Commons
{
    public class TransactionsManager
    {
        public static TblTransaction GetTransactionById(object TransactionId)
        {
            try
            {
                Select select = new Select();
                select.From(TblTransaction.Schema);
                select.Where(TblTransaction.IdColumn).IsEqualTo(TransactionId);
                return select.ExecuteSingle<TblTransaction>();
            }
            catch
            {
                return null;
            }
        }
        public static TblTransaction GetTransactionByCode(object code)
        {
            try
            {
                Select select = new Select();
                select.From(TblTransaction.Schema);
                select.Where(TblTransaction.CodeColumn).IsEqualTo(code);
                return select.ExecuteSingle<TblTransaction>();
            }
            catch
            {
                return null;
            }
        }
        public static TblTransaction Insert(TblTransaction objTransaction)
        {
            return new TblTransactionController().Insert(objTransaction);
        }

        public static TblTransaction Update(TblTransaction objTransaction)
        {
            return new TblTransactionController().Update(objTransaction);
        }
    }
}