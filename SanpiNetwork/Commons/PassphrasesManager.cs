using SubSonic;
using SweetCMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SanpiNetwork.Commons
{
    public class PassphrasesManager
    {
        public static TblPassphrase GetPassphraseById(object PassphraseId)
        {
            try
            {
                Select select = new Select();
                select.From(TblPassphrase.Schema);
                select.Where(TblPassphrase.IdColumn).IsEqualTo(PassphraseId);
                return select.ExecuteSingle<TblPassphrase>();
            }
            catch
            {
                return null;
            }
        }
        public static TblPassphrase Insert(TblPassphrase objPassphrase)
        {
            return new TblPassphraseController().Insert(objPassphrase);
        }

        public static TblPassphrase Update(TblPassphrase objPassphrase)
        {
            return new TblPassphraseController().Update(objPassphrase);
        }
    }
}