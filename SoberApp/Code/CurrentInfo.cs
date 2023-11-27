using SoberApp.Code.Models;

namespace SoberApp.Code
{
	public class CurrentInfo
	{
		public Account currentAccount { get; private set; }


		public void SetCurrentAccount(Account account)
		{
			currentAccount = account;
		}
	}
}