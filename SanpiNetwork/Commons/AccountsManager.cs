using SubSonic;
using SweetCMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanpiNetwork.Commons
{
    public class AccountsManager
    {
        public static TblAccount GetAccountById(object AccountId)
        {
            try
            {
                Select select = new Select();
                select.From(TblAccount.Schema);
                select.Where(TblAccount.IdColumn).IsEqualTo(AccountId);
                return select.ExecuteSingle<TblAccount>();
            }
            catch
            {
                return null;
            }
        }
        public static TblAccount GetAccountByEmail(object email)
        {
            try
            {
                Select select = new Select();
                select.From(TblAccount.Schema);
                select.Where(TblAccount.EmailColumn).IsEqualTo(email);
                return select.ExecuteSingle<TblAccount>();
            }
            catch
            {
                return null;
            }
        }
        public static TblAccount Insert(TblAccount objAccount)
        {
            return new TblAccountController().Insert(objAccount);
        }

        public static TblAccount Update(TblAccount objAccount)
        {
            return new TblAccountController().Update(objAccount);
        }
    }
}