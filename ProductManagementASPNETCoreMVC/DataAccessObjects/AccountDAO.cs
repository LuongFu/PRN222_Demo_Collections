using BusinessObjects;
using System.Linq;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountID)
        {
            using var db = new MyStoreDbContext();
            return db.AccountMembers
                     .FirstOrDefault(c => c.MemberId.Equals(accountID));
        }
        public static AccountMember GetAccountByEmail(string email)
        {
            using var db = new MyStoreDbContext();
            return db.AccountMembers
                     .FirstOrDefault(c => c.EmailAddress.Equals(email));
        }
    }
}
