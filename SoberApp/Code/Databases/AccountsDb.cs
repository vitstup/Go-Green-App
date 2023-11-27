using SoberApp.Code.Models;
using SQLite;

namespace SoberApp.Code.Databases
{
	public class AccountsDb
	{
		private readonly SQLiteAsyncConnection db;

		public AccountsDb(string connectionString)
		{
			db = new SQLiteAsyncConnection(connectionString);

			db.CreateTableAsync<Account>().Wait();
		}

		public async Task<IEnumerable<Account>> GetAccounts()
		{
			return await db.Table<Account>().ToListAsync();
		}

		public async Task<Account> GetAccountById(int id)
		{
			return await db.Table<Account>().Where(i => i.id == id).FirstOrDefaultAsync();
		}

		public async Task<Account> GetAccountByLoginAndPass(string login, string pass)
		{
			var account = await db.Table<Account>().Where(i => (i.login == login || i.email == login) && i.password == pass).FirstOrDefaultAsync();
			return account;
		}

		public async Task<bool> AlreadyHaveThisLogin(string login)
		{
			var account = await db.Table<Account>().Where(i => i.login == login).FirstOrDefaultAsync();
			return account != null;
		}

		public async Task SaveAccount(Account account)
		{
			if (account == null) return;

			if (account.id != 0) await db.UpdateAsync(account);
			else await db.InsertAsync(account);
		}

		public async Task RemoveAccountById(int id)
		{
			var account = await GetAccountById(id);
			await db.DeleteAsync(account);
		}

		public async Task RemoveAccount(Account account)
		{
			await db.DeleteAsync(account);
		}
	}
}
