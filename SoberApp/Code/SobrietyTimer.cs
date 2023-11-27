using SoberApp.Code.Models;

namespace SoberApp.Code
{
	public class SobrietyTimer
	{
		private Account account;

		public int years { get; private set; }
		public int days { get; private set; }
		public int hours { get; private set; }
		public int minutes { get; private set; }
		public int seconds { get; private set; }

		public SobrietyTimer(Account account)
		{
			this.account = account;
		}

		public void UpdateInfo()
		{
			TimeSpan timePassed = DateTime.Now - account.sobrietyDate;

			years = timePassed.Days / 365;

			days = timePassed.Days % 365;

			hours = timePassed.Hours;

			minutes = timePassed.Minutes;

			seconds = timePassed.Seconds;
		}
	}
}